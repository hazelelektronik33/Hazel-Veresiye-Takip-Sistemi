using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Veresiye
{
    public static class BackupHelper
    {
        private const int KeepLastN = 30;
        private static readonly TimeSpan MinInterval = TimeSpan.FromDays(1);

        public static void TryAutoBackup()
        {
            try
            {
                string backupDir = GetBackupDir();
                Directory.CreateDirectory(backupDir);

                string stampFile = Path.Combine(backupDir, "last_backup.txt");
                DateTime last = ReadLastBackup(stampFile);

                if (DateTime.Now - last < MinInterval)
                    return;

                BackupNow(backupDir);

                File.WriteAllText(stampFile, DateTime.Now.ToString("o", CultureInfo.InvariantCulture));
                CleanupOldBackups(backupDir, KeepLastN);
            }
            catch
            {
                // sessiz
            }
        }

        public static bool TryAutoBackup(out string message)
        {
            string backupDir = null;

            try
            {
                backupDir = GetBackupDir();
                Directory.CreateDirectory(backupDir);

                string stampFile = Path.Combine(backupDir, "last_backup.txt");
                DateTime last = ReadLastBackup(stampFile);

                if (DateTime.Now - last < MinInterval)
                {
                    message = "ℹ️ Yedek bugün zaten alındı.";
                    return false;
                }

                BackupNow(backupDir);

                File.WriteAllText(stampFile, DateTime.Now.ToString("o", CultureInfo.InvariantCulture));
                CleanupOldBackups(backupDir, KeepLastN);

                message = "✅ Yedek alındı: " + backupDir;
                return true;
            }
            catch (Exception ex)
            {
                message = "❌ Yedek hatası: " + ex.Message;
                return false;
            }
        }


        public static void BackupNow(string backupDir = null)
        {
            if (backupDir == null) backupDir = GetBackupDir();
            if (!Directory.Exists(backupDir)) Directory.CreateDirectory(backupDir);

            var efConn = ConfigurationManager.ConnectionStrings["VeresiyedbEntities"]?.ConnectionString;
            string sqlConn = ExtractSqlConnectionString(efConn);

            var csb = new SqlConnectionStringBuilder(sqlConn);
            string backupFileName = $"Veresiye_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            string bakPath = Path.Combine(backupDir, backupFileName);

            // 1. Önce veritabanının SQL içindeki gerçek adını öğrenelim
            string realDbName = "";
            using (var con = new SqlConnection(sqlConn))
            {
                con.Open();
                // Bu komut o an bağlı olduğun DB'nin adını verir (LocalDB'nin atadığı karmaşık isim dahil)
                using (var cmd = new SqlCommand("SELECT DB_NAME()", con))
                {
                    realDbName = cmd.ExecuteScalar()?.ToString();
                }
            }

            if (string.IsNullOrEmpty(realDbName))
                throw new Exception("Veritabanı adı alınamadı.");

            // 2. Master'a bağlanıp yedeği alalım
            csb.InitialCatalog = "master";
            csb.AttachDBFilename = "";

            using (var con = new SqlConnection(csb.ToString()))
            {
                con.Open();
                // realDbName değişkenini [] içine alarak gönderiyoruz
                string sql = $"BACKUP DATABASE [{realDbName}] TO DISK = @p WITH INIT, NAME = 'HazelBackup';";

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@p", bakPath);
                    cmd.CommandTimeout = 300;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void RestoreBackup(string bakFilePath)
        {
            var efConn = ConfigurationManager.ConnectionStrings["VeresiyedbEntities"]?.ConnectionString;
            string sqlConn = ExtractSqlConnectionString(efConn);
            var csb = new SqlConnectionStringBuilder(sqlConn);

            // 1. Veritabanı adını öğren (Backup'taki ile aynı mantık)
            string dbName = "";
            using (var con = new SqlConnection(sqlConn))
            {
                con.Open();
                using (var cmd = new SqlCommand("SELECT DB_NAME()", con))
                {
                    dbName = cmd.ExecuteScalar()?.ToString();
                }
            }

            // 2. Master'a bağlan (Restore işlemi asla hedef DB üzerinden yapılamaz)
            csb.InitialCatalog = "master";
            csb.AttachDBFilename = "";

            using (var con = new SqlConnection(csb.ToString()))
            {
                con.Open();

                // 3. Bağlantıları kopar, Yedeği yükle ve Multi-user moduna geri dön
                string sql = $@"
            ALTER DATABASE [{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
            RESTORE DATABASE [{dbName}] FROM DISK = @p WITH REPLACE;
            ALTER DATABASE [{dbName}] SET MULTI_USER;";

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@p", bakFilePath);
                    cmd.CommandTimeout = 300;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private static string ExtractAttachDbFileName(string sqlConnectionString)
        {
            // SqlConnectionStringBuilder AttachDBFilename alanını verir
            try
            {
                var csb = new SqlConnectionStringBuilder(sqlConnectionString);
                var attach = csb.AttachDBFilename;

                if (string.IsNullOrWhiteSpace(attach))
                    return null;

                // |DataDirectory| çöz
                if (attach.Contains("|DataDirectory|"))
                {
                    string dataDir = AppDomain.CurrentDomain.GetData("DataDirectory") as string;
                    if (string.IsNullOrWhiteSpace(dataDir))
                        dataDir = AppDomain.CurrentDomain.BaseDirectory;

                    attach = attach.Replace("|DataDirectory|", dataDir.TrimEnd('\\'));
                }

                return attach;
            }
            catch
            {
                return null;
            }
        }

        private static string FindDatabaseNameByMdf(string masterConn, string mdfFullPath)
        {
            if (string.IsNullOrWhiteSpace(mdfFullPath))
                return null;

            // sys.master_files üzerinden physical_name -> database_id -> name
            const string q = @"
SELECT TOP 1 d.name
FROM sys.master_files mf
JOIN sys.databases d ON d.database_id = mf.database_id
WHERE mf.type_desc = 'ROWS' AND mf.physical_name = @p
ORDER BY d.database_id DESC;";

            using (var con = new SqlConnection(masterConn))
            using (var cmd = new SqlCommand(q, con))
            {
                cmd.Parameters.AddWithValue("@p", mdfFullPath);
                con.Open();
                var obj = cmd.ExecuteScalar();
                return obj == null ? null : obj.ToString();
            }
        }


        public static string GetBackupDir()
        {
            try
            {
                // Öncelik: D:\HazelVeresiye\Backups
                if (Directory.Exists(@"D:\") || DriveInfo.GetDrives().Any(d => d.Name.Equals(@"D:\", StringComparison.OrdinalIgnoreCase)))
                {
                    return @"D:\HazelVeresiye\Backups";
                }
            }
            catch
            {
                // hiç sorun değil, fallback'e geç
            }

            // Fallback: Belgelerim\HazelVeresiye\Backups
            string docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return Path.Combine(docs, "HazelVeresiye", "Backups");
        }


        private static DateTime ReadLastBackup(string stampFile)
        {
            try
            {
                if (!File.Exists(stampFile)) return DateTime.MinValue;
                var s = File.ReadAllText(stampFile).Trim();
                DateTime dt;
                if (DateTime.TryParse(s, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out dt))
                    return dt;
                return DateTime.MinValue;
            }
            catch { return DateTime.MinValue; }
        }

        private static void CleanupOldBackups(string dir, int keepLastN)
        {
            var files = new DirectoryInfo(dir)
                .GetFiles("Veresiye_*.bak")
                .OrderByDescending(f => f.CreationTimeUtc)
                .ToList();

            foreach (var f in files.Skip(keepLastN))
            {
                try { f.Delete(); } catch { }
            }
        }

        private static string ExtractSqlConnectionString(string efConnectionString)
        {
            const string key = "provider connection string=&quot;";
            int i = efConnectionString.IndexOf(key, StringComparison.OrdinalIgnoreCase);
            if (i >= 0)
            {
                i += key.Length;
                int j = efConnectionString.IndexOf("&quot;", i, StringComparison.OrdinalIgnoreCase);
                if (j > i)
                {
                    string inner = efConnectionString.Substring(i, j - i);
                    inner = inner.Replace("&quot;", "\"");
                    return inner;
                }
            }

            const string key2 = "provider connection string=\"";
            i = efConnectionString.IndexOf(key2, StringComparison.OrdinalIgnoreCase);
            if (i >= 0)
            {
                i += key2.Length;
                int j = efConnectionString.IndexOf("\"", i, StringComparison.OrdinalIgnoreCase);
                if (j > i) return efConnectionString.Substring(i, j - i);
            }

            const string key3 = "provider connection string='";
            i = efConnectionString.IndexOf(key3, StringComparison.OrdinalIgnoreCase);
            if (i >= 0)
            {
                i += key3.Length;
                int j = efConnectionString.IndexOf("'", i, StringComparison.OrdinalIgnoreCase);
                if (j > i) return efConnectionString.Substring(i, j - i);
            }

            return efConnectionString;
        }
    }
}
