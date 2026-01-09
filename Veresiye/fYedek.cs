using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Veresiye
{
    public partial class fYedek : Form
    {
        public fYedek()
        {
            InitializeComponent();
        }

        private void fYedek_Load(object sender, EventArgs e)
        {
            YedekleriListele();
        }

        // Listeyi tazeleme fonksiyonu
        private void YedekleriListele()
        {
            try
            {
                string path = BackupHelper.GetBackupDir();
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                var files = Directory.GetFiles(path, "*.bak")
                    .Select(f => new FileInfo(f))
                    .OrderByDescending(f => f.CreationTime)
                    .Select(f => new { DosyaAdi = f.Name, Tarih = f.CreationTime, Boyut = (f.Length / 1024).ToString() + " KB" })
                    .ToList();

                lstBackups.DataSource = files; // DataGridView kullanıyorsan en temizi budur
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            // DataGridView'de seçili satırı alma
            if (lstBackups.CurrentRow == null) return;

            string secilenDosya = lstBackups.CurrentRow.Cells["DosyaAdi"].Value.ToString();
            string tamYol = Path.Combine(BackupHelper.GetBackupDir(), secilenDosya);

            var cevap = MessageBox.Show($"{secilenDosya} yedeği geri yüklenecek. Emin misiniz?", "ONAY", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (cevap == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    BackupHelper.RestoreBackup(tamYol);
                    MessageBox.Show("Yedek başarıyla yüklendi!");
                }
                catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
                finally { this.Cursor = Cursors.Default; }
            }
        }

        private void btnYedekSil_Click(object sender, EventArgs e)
        {
            if (lstBackups.CurrentRow == null) return;

            string dosya = lstBackups.CurrentRow.Cells["DosyaAdi"].Value.ToString();
            if (MessageBox.Show("Silinsin mi?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                File.Delete(Path.Combine(BackupHelper.GetBackupDir(), dosya));
                YedekleriListele();
            }
        }

        private void bYedekAl_Click(object sender, EventArgs e)
        {
            string mesaj;
            if (BackupHelper.TryAutoBackup(out mesaj))
            {
                MessageBox.Show(mesaj, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                YedekleriListele();
            }
            else
            {
                MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnKlasoruAc_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", BackupHelper.GetBackupDir());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Klasör açılamadı: " + ex.Message);
            }
        }

        private void lstBackups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}