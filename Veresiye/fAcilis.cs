using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Veresiye
{
    public partial class fAcilis : Form
    {
        private readonly VeresiyedbEntities db = new VeresiyedbEntities();
        private readonly PrintDocument _pd = new PrintDocument();
        private int _printRowIndex = 0;
        private int _printPageNo = 1;
        private string _printHeaderText = "";
        private string _printSummaryText = "";
        private readonly string[] _printCols = new[] { "CariKodu", "CariUnvani", "Sehir", "SonIslem", "Bakiye" };



    public fAcilis()
        {
            InitializeComponent();
            bHesapla.Click -= bHesapla_Click;
            bHesapla.Click += bHesapla_Click;
            _pd.BeginPrint -= Pd_BeginPrint_Rapor;
            _pd.BeginPrint += Pd_BeginPrint_Rapor;

            _pd.PrintPage -= Pd_PrintPage_Rapor;
            _pd.PrintPage += Pd_PrintPage_Rapor;




        }

        private void fAcilis_Load(object sender, EventArgs e)
        {
            _pd.PrintPage -= Pd_PrintPage;
            _pd.PrintPage += Pd_PrintPage;
            dGridListe.AutoGenerateColumns = true;
            dGridListe.AllowUserToAddRows = false;
            dGridListe.ReadOnly = true;

            ComboDoldur();

            // Eventleri bağla
            comboBox1.SelectedIndexChanged += (_, __) => ListeFiltrele();
            comboBox2.SelectedIndexChanged += (_, __) => ListeFiltrele();

            // 1. ÖNCE LİSTEYİ DOLDUR (Veri burda geliyor)
            ListeFiltrele();

            // 2. SONRA SEÇİM YAP
            if (dGridListe.Rows.Count > 0)
            {
                dGridListe.ClearSelection();
                dGridListe.Rows[0].Selected = true;
                // CurrentCell ataması bazen Load anında hata verebilir, 
                // o yüzden try-catch içine almak veya sadece Selected kullanmak daha güvenlidir.
                try { dGridListe.CurrentCell = dGridListe.Rows[0].Cells[0]; } catch { }
            }
          

            Task.Run(() =>
            {
                string msg;
                BackupHelper.TryAutoBackup(out msg);

                this.BeginInvoke(new Action(() =>
                {
                    tslDurum.Text = msg;
                    tslDurum.Visible = true;
                }));
            });
        }
        
        private void Pd_BeginPrint(object sender, PrintEventArgs e)
        {
            _printRowIndex = 0;
            _printPageNo = 1;

            _printHeaderText = "VERESİYE RAPORU";
            _printSummaryText = lHesapla.Text ?? "";
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            var g = e.Graphics;

            // Fontlar
            Font fontTitle = new Font("Arial", 14, FontStyle.Bold);
            Font fontSmall = new Font("Arial", 9, FontStyle.Regular);
            Font fontBody = new Font("Arial", 10, FontStyle.Regular);
            Font fontBold = new Font("Arial", 10, FontStyle.Bold);

            

            float left = e.MarginBounds.Left;
            float top = e.MarginBounds.Top;
            float right = e.MarginBounds.Right;
            float y = top;

            // Başlık
            g.DrawString(_printHeaderText, fontTitle, Brushes.Black, left, y);
            y += 26;

            // Tarih + Sayfa
            string meta = $"Tarih: {DateTime.Now:dd.MM.yyyy HH:mm}    Sayfa: {_printPageNo}";
            g.DrawString(meta, fontSmall, Brushes.Black, left, y);
            y += 18;

            // Özet (lHesapla)
            if (!string.IsNullOrWhiteSpace(_printSummaryText))
            {
                g.DrawString(_printSummaryText, fontBody, Brushes.Black,
                    new RectangleF(left, y, e.MarginBounds.Width, 60));
                y += 60;
            }

            // Çizgi
            g.DrawLine(Pens.Black, left, y, right, y);
            y += 10;

            // Grid yoksa sadece özet bas
            if (dGridListe == null || dGridListe.Rows.Count == 0)
            {
                e.HasMorePages = false;
                return;
            }

            // Basılacak kolonları gridde var olanlardan seç
            var cols = dGridListe.Columns
                .Cast<DataGridViewColumn>()
                .Where(c => c.Visible && _printCols.Contains(c.Name))
                .OrderBy(c => Array.IndexOf(_printCols, c.Name))
                .ToList();

            if (cols.Count == 0)
            {
                // Hiç kolon yoksa sadece özet bas
                e.HasMorePages = false;
                return;
            }

            // Kolon genişlikleri (oransal)
            // CariKodu 15% | Unvan 35% | Sehir 15% | SonIslem 20% | Bakiye 15%
            float w = e.MarginBounds.Width;
            float wCariKodu = w * 0.15f;
            float wUnvan = w * 0.35f;
            float wSehir = w * 0.15f;
            float wSonIslem = w * 0.20f;
            float wBakiye = w * 0.15f;

            float GetColWidth(string name)
            {
                if (name == "CariKodu") return wCariKodu;
                if (name == "CariUnvani") return wUnvan;
                if (name == "Sehir") return wSehir;
                if (name == "SonIslem") return wSonIslem;
                if (name == "Bakiye") return wBakiye;
                return w / cols.Count;
            }


            // Tablo başlığı (header row)
            float x = left;
            float rowH = 22;

            // Header background
            g.FillRectangle(Brushes.LightGray, left, y, w, rowH);
            g.DrawRectangle(Pens.Black, left, y, w, rowH);

            foreach (var c in cols)
            {
                float cw = GetColWidth(c.Name);
                string head = c.HeaderText;

                g.DrawRectangle(Pens.Black, x, y, cw, rowH);
                g.DrawString(head, fontBold, Brushes.Black, new RectangleF(x + 4, y + 4, cw - 8, rowH - 8));
                x += cw;
            }
            y += rowH;

            // Satırlar
            while (_printRowIndex < dGridListe.Rows.Count)
            {
                var gridRow = dGridListe.Rows[_printRowIndex];
                if (gridRow.IsNewRow) { _printRowIndex++; continue; }

                // Sayfa bitti mi?
                if (y + rowH > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    _printPageNo++;
                    return;
                }

                x = left;

                // satır çerçevesi
                g.DrawRectangle(Pens.Black, left, y, w, rowH);

                foreach (var c in cols)
                {
                    float cw = GetColWidth(c.Name);
                    object valObj = null;

                    // gridde kolon adıyla hücreye eriş
                    if (dGridListe.Columns.Contains("Id"))
                    {
                        var v = dGridListe.CurrentRow.Cells["Id"].Value;
                    }


                    string val = valObj?.ToString() ?? "";

                    // Bakiye sağa hizalı olsun
                    var format = new StringFormat { LineAlignment = StringAlignment.Center };
                    if (c.Name == "Bakiye")
                        format.Alignment = StringAlignment.Far;
                    else
                        format.Alignment = StringAlignment.Near;

                    g.DrawRectangle(Pens.Black, x, y, cw, rowH);

                    // biraz padding
                    var rect = new RectangleF(x + 4, y, cw - 8, rowH);
                    g.DrawString(val, fontBody, Brushes.Black, rect, format);

                    x += cw;
                }

                y += rowH;
                _printRowIndex++;
            }

            e.HasMorePages = false;
            fontTitle.Dispose();
            fontSmall.Dispose();
            fontBody.Dispose();
            fontBold.Dispose();
        }
        private void Pd_PrintPage_Rapor(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            Font fontTitle = new Font("Arial", 14, FontStyle.Bold);
            Font fontSmall = new Font("Arial", 9, FontStyle.Regular);
            Font fontBody = new Font("Arial", 10, FontStyle.Regular);
            Font fontBold = new Font("Arial", 10, FontStyle.Bold);

            float left = e.MarginBounds.Left;
            float top = e.MarginBounds.Top;
            float right = e.MarginBounds.Right;
            float y = top;

            g.DrawString(_printHeaderText, fontTitle, Brushes.Black, left, y);
            y += 26;

            string meta = "Tarih: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "    Sayfa: " + _printPageNo;
            g.DrawString(meta, fontSmall, Brushes.Black, left, y);
            y += 18;

            if (!string.IsNullOrWhiteSpace(_printSummaryText))
            {
                RectangleF sumRect = new RectangleF(left, y, e.MarginBounds.Width, 60);
                g.DrawString(_printSummaryText, fontBody, Brushes.Black, sumRect);
                y += 60;
            }

            g.DrawLine(Pens.Black, left, y, right, y);
            y += 10;

            if (dGridListe == null || dGridListe.Rows.Count == 0)
            {
                e.HasMorePages = false;
                fontTitle.Dispose(); fontSmall.Dispose(); fontBody.Dispose(); fontBold.Dispose();
                return;
            }

            // kolonları seç (gridde var olan ve visible olan)
            var cols = dGridListe.Columns
                .Cast<DataGridViewColumn>()
                .Where(c => c.Visible && _printCols.Contains(c.Name))
                .OrderBy(c => Array.IndexOf(_printCols, c.Name))
                .ToList();

            if (cols.Count == 0)
            {
                e.HasMorePages = false;
                fontTitle.Dispose(); fontSmall.Dispose(); fontBody.Dispose(); fontBold.Dispose();
                return;
            }

            float w = e.MarginBounds.Width;
            float wCariKodu = w * 0.15f;
            float wUnvan = w * 0.35f;
            float wSehir = w * 0.15f;
            float wSonIslem = w * 0.20f;
            float wBakiye = w * 0.15f;

            Func<string, float> GetColWidth = (name) =>
            {
                if (name == "CariKodu") return wCariKodu;
                if (name == "CariUnvani") return wUnvan;
                if (name == "Sehir") return wSehir;
                if (name == "SonIslem") return wSonIslem;
                if (name == "Bakiye") return wBakiye;
                return w / cols.Count;
            };

            float rowH = 22;
            float x = left;

            // header row
            g.FillRectangle(Brushes.LightGray, left, y, w, rowH);
            g.DrawRectangle(Pens.Black, left, y, w, rowH);

            foreach (var c in cols)
            {
                float cw = GetColWidth(c.Name);
                g.DrawRectangle(Pens.Black, x, y, cw, rowH);
                g.DrawString(c.HeaderText, fontBold, Brushes.Black, new RectangleF(x + 4, y + 4, cw - 8, rowH - 8));
                x += cw;
            }
            y += rowH;

            while (_printRowIndex < dGridListe.Rows.Count)
            {
                var gridRow = dGridListe.Rows[_printRowIndex];
                if (gridRow.IsNewRow) { _printRowIndex++; continue; }

                if (y + rowH > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    _printPageNo++;
                    fontTitle.Dispose(); fontSmall.Dispose(); fontBody.Dispose(); fontBold.Dispose();
                    return;
                }

                x = left;
                g.DrawRectangle(Pens.Black, left, y, w, rowH);

                foreach (var c in cols)
                {
                    float cw = GetColWidth(c.Name);

                    // ✅ CS1503 fix: Cells.Contains string almaz!
                    object valObj = null;
                    if (gridRow.Cells[c.Index] != null)
                        valObj = gridRow.Cells[c.Index].Value;

                    string val = valObj != null ? valObj.ToString() : "";

                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = (c.Name == "Bakiye") ? StringAlignment.Far : StringAlignment.Near;

                    g.DrawRectangle(Pens.Black, x, y, cw, rowH);
                    g.DrawString(val, fontBody, Brushes.Black, new RectangleF(x + 4, y, cw - 8, rowH), sf);

                    sf.Dispose();
                    x += cw;
                }

                y += rowH;
                _printRowIndex++;
            }

            e.HasMorePages = false;

            fontTitle.Dispose(); fontSmall.Dispose(); fontBody.Dispose(); fontBold.Dispose();
        }

        private void bEkle_Click(object sender, EventArgs e)
        {
            using (var f = new fCariEkle())
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                    ListeFiltrele();
            }
        }

        private void bDegistir_Click(object sender, EventArgs e)
        {
            if (dGridListe.CurrentRow == null) return;

            int id = Convert.ToInt32(dGridListe.CurrentRow.Cells["Id"].Value);

            using (var f = new fCariEkle())
            {
                f.EditCariId = id;
                if (f.ShowDialog(this) == DialogResult.OK)
                    ListeFiltrele();
            }
        }

        private void bSil_Click(object sender, EventArgs e)
        {
            if (dGridListe.CurrentRow == null) return;

            int id = Convert.ToInt32(dGridListe.CurrentRow.Cells["Id"].Value);
            var kayit = db.CariHesap.FirstOrDefault(x => x.Id == id);
            if (kayit == null) return;

            if (MessageBox.Show("Seçili cariyi silmek istiyor musun?", "Onay",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            db.CariHesap.Remove(kayit);
            db.SaveChanges();

            ListeFiltrele();
        }

        private void bCariAc_Click(object sender, EventArgs e)
        {
            if (dGridListe.CurrentRow == null)
            {
                MessageBox.Show("Kullanıcı Seçiniz");
                return;
            }

            int id = Convert.ToInt32(dGridListe.CurrentRow.Cells["Id"].Value);

            var getir = db.CariHesap.FirstOrDefault(x => x.Id == id);
            if (getir == null)
            {
                MessageBox.Show("Kayıt bulunamadı.");
                return;
            }

            using (var f = new fCariAc())
            {
                f.CariId = id;                 // ✅ label ile değil property ile
                f.bCariAdi.Text = getir.Unvan;

                // Hareket ekranı kapanınca OK dönerse listeyi yenile
                if (f.ShowDialog(this) == DialogResult.OK)
                    ListeFiltrele();
            }
        }

        private void tCariAra_TextChanged(object sender, EventArgs e)
        {
            ListeFiltrele();
        }

        private void ComboDoldur()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Tümü");
            comboBox1.Items.Add("Müşteri");    // Tur = true
            comboBox1.Items.Add("Tedarikçi");  // Tur = false
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Clear();
            comboBox2.Items.Add("Tümü");
            comboBox2.Items.Add("Borçlu");
            comboBox2.Items.Add("Alacaklı");
            comboBox2.Items.Add("Sıfır");
            comboBox2.SelectedIndex = 0;
        }

        private void ListeFiltrele()
        {
            string unvanQ = (tCariAra.Text ?? "").Trim();
            string secTur = comboBox1.SelectedItem?.ToString() ?? "Tümü";
            string secFiltre = comboBox2.SelectedItem?.ToString() ?? "Tümü";

            bool? turFiltre = null;
            if (secTur == "Müşteri") turFiltre = true;
            else if (secTur == "Tedarikçi") turFiltre = false;

            var hg = db.CariHareket
                .GroupBy(h => h.CariId)
                .Select(g => new
                {
                    CariId = g.Key,
                    SonIslem = g.Max(x => (DateTime?)x.Tarih),
                    Borc = g.Where(x => x.Tur == "BORC").Sum(x => (decimal?)x.Tutar),
                    Alacak = g.Where(x => x.Tur == "ALACAK" || x.Tur == "TAHSILAT" || x.Tur == "ODEME")
                              .Sum(x => (decimal?)x.Tutar)
                });

            var q = from c in db.CariHesap
                    join h in hg on c.Id equals h.CariId into j
                    from h in j.DefaultIfEmpty()
                    select new
                    {
                        c.Id,
                        c.CariKodu,
                        SonIslem = h.SonIslem,
                        Unvan = c.Unvan,
                        Sehir = c.Il,
                        Tur = c.Tur,
                        Borc = (decimal?)(h.Borc ?? 0),
                        Alacak = (decimal?)(h.Alacak ?? 0)
                    };

            if (unvanQ.Length >= 2)
                q = q.Where(x => x.Unvan.Contains(unvanQ));

            if (turFiltre.HasValue)
                q = q.Where(x => x.Tur == turFiltre.Value);

            var q2 = q.Select(x => new
            {
                x.Id,
                x.CariKodu,
                x.SonIslem,
                x.Unvan,
                x.Sehir,
                Bakiye = (x.Borc ?? 0) - (x.Alacak ?? 0)
            });

            if (secFiltre == "Borçlu") q2 = q2.Where(x => x.Bakiye > 0);
            else if (secFiltre == "Alacaklı") q2 = q2.Where(x => x.Bakiye < 0);
            else if (secFiltre == "Sıfır") q2 = q2.Where(x => x.Bakiye == 0);

            var liste = q2
                .OrderByDescending(x => x.SonIslem.HasValue)
                .ThenByDescending(x => x.SonIslem)
                .ThenByDescending(x => x.Id)
                .ToList();

            // Grid reset
            dGridListe.DataSource = null;
            dGridListe.Columns.Clear();
            dGridListe.AutoGenerateColumns = true;

            dGridListe.DataSource = liste.Select(x => new
            {
                x.Id,
                x.CariKodu,
                SonIslem = x.SonIslem.HasValue ? x.SonIslem.Value.ToString("dd.MM.yyyy HH:mm") : "-",
                CariUnvani = x.Unvan,
                Sehir = x.Sehir,
                Bakiye = x.Bakiye
            }).ToList();

            Islemler.Gridduzenle(dGridListe);
            lSay.Text = liste.Count.ToString();
            dGridListe.ClearSelection();
        }
        private void ListeyiYenile()
        {
            ListeFiltrele();
        }

        private void dGridListe_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dGridListe.Rows.Count > 0)
            {
                // Önce temizle
                dGridListe.ClearSelection();

                // İlk satırı hem seç hem de "Aktif Hücre" yap
                // CurrentCell set edildiğinde CurrentRow otomatik dolar.
                dGridListe.CurrentCell = dGridListe.Rows[0].Cells[1]; // 0. hücre Id ise 1. hücreyi seçmek daha garantidir
                dGridListe.Rows[0].Selected = true;
            }
            if (!dGridListe.Columns.Contains("Bakiye")) return;

            foreach (DataGridViewRow row in dGridListe.Rows)
            {
                if (row.IsNewRow) continue;

                var v = row.Cells["Bakiye"].Value;
                if (v == null) continue;

                if (!decimal.TryParse(v.ToString(), out var bakiye)) continue;

                if (bakiye > 0)
                {
                    row.DefaultCellStyle.BackColor = Color.MistyRose;
                    row.DefaultCellStyle.ForeColor = Color.Maroon;
                }
                else if (bakiye < 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Honeydew;
                    row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void bHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new VeresiyedbEntities())
                {
                    // Hareketleri cariye göre grupla -> borç/alacak/net çıkar
                    var ozet = db.CariHareket
                        .GroupBy(h => h.CariId)
                        .Select(g => new
                        {
                            CariId = g.Key,
                            Borc = g.Where(x => x.Tur == "BORC").Sum(x => (decimal?)x.Tutar) ?? 0m,
                            Alacak = g.Where(x =>
                                        x.Tur == "ALACAK" ||
                                        x.Tur == "TAHSILAT" ||
                                        x.Tur == "ODEME")
                                      .Sum(x => (decimal?)x.Tutar) ?? 0m
                        })
                        .ToList()
                        .Select(x => new
                        {
                            x.CariId,
                            x.Borc,
                            x.Alacak,
                            Net = x.Borc - x.Alacak
                        })
                        .ToList();

                    // ✅ Toplamlar
                    decimal toplamBorc = ozet.Sum(x => x.Borc);
                    decimal toplamAlacak = ozet.Sum(x => x.Alacak);
                    decimal netToplam = toplamBorc - toplamAlacak;

                    // ✅ Sayılar
                    int borcluSay = ozet.Count(x => x.Net > 0);
                    int alacakliSay = ozet.Count(x => x.Net < 0);
                    int sifirSay = ozet.Count(x => x.Net == 0);

                    // ✅ Hiç hareketi olmayan cariler de “sıfır” sayılacak mı?
                    // Evet diyorsan:
                    int toplamCari = db.CariHesap.Count();
                    int hareketliCari = ozet.Count;
                    int hareketsizCari = toplamCari - hareketliCari;
                    sifirSay += hareketsizCari; // hareketsiz = bakiye 0 kabul

                    // Label
                    lHesapla.Text =
                        $"Toplam Cari: {toplamCari} | Borçlu: {borcluSay} | Alacaklı: {alacakliSay} | Sıfır: {sifirSay}\n" +
                        $"Toplam Borç: {toplamBorc:N2} ₺  |  Toplam Alacak: {toplamAlacak:N2} ₺  |  Net: {netToplam:N2} ₺";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hesaplama hatası: " + ex.Message);
            }
            lHesapla.Visible = true;
        }

        private void Pd_BeginPrint_Rapor(object sender, PrintEventArgs e)
        {
            _printRowIndex = 0;
            _printPageNo = 1;

            _printHeaderText = "VERESİYE RAPORU";
            _printSummaryText = lHesapla.Text ?? "";
        }

        private void dGridListe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dGridListe.CurrentRow != null)
            {
                e.SuppressKeyPress = true; // Bip sesini engeller
                bCariAc_Click(null, null); // Mevcut butonu tetikler
            }
        }

        private void bYazdir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lHesapla.Text))
                bHesapla_Click(null, EventArgs.Empty);

            PrintDialog dlg = new PrintDialog();
            dlg.Document = _pd;
            if (dlg.ShowDialog(this) == DialogResult.OK)
                _pd.Print();

            dlg.Dispose();
        }

        private void bOnizleme_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lHesapla.Text))
                bHesapla_Click(null, EventArgs.Empty);

            PrintPreviewDialog prev = new PrintPreviewDialog();
            prev.Document = _pd;
            prev.Width = 1100;
            prev.Height = 800;
            prev.ShowDialog(this);
            prev.Dispose();
        }

        private void bYedekAl_Click(object sender, EventArgs e)
        {
            try
            {
                BackupHelper.BackupNow();
                tslDurum.Text = "✅ Manuel yedek alındı (D:\\HazelVeresiye\\Backups)";
            }
            catch (Exception ex)
            {
                tslDurum.Text = "❌ Yedek hatası";
                MessageBox.Show("Yedek alınamadı:\n" + ex.Message);
            }


        }

        private void btnYedeklemeFormu_Click(object sender, EventArgs e)
        {
            // Daha önce açık olup olmadığını kontrol edebilirsin veya direkt oluşturabilirsin
            fYedek yedekFormu = new fYedek();

            // Formun ana sayfanın ortasında açılması için:
            yedekFormu.StartPosition = FormStartPosition.CenterParent;

            // .Show() yerine .ShowDialog() kullanmanı öneririm. 
            // Böylece yedekleme yaparken arkadaki ana formda yanlışlıkla işlem yapılmaz.
            yedekFormu.ShowDialog();
        }

       
    }
}

