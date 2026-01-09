using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace Veresiye
{
    public partial class fCariAc : Form
    {
        public fCariAc()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture =
    new CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentUICulture =
                new CultureInfo("tr-TR");
        }

        // fAcilis burayı set edecek
        public int CariId { get; set; }

        private void fCariAc_Load(object sender, EventArgs e)
        {
            if (CariId <= 0)
            {
                MessageBox.Show("Cari seçilmedi.");
                Close();
                return;
            }

            dGridListeAc.AutoGenerateColumns = true;
            dGridListeAc.AllowUserToAddRows = false;
            dGridListeAc.ReadOnly = true;
            dGridListeAc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGridListeAc.MultiSelect = false;

            CariYukle(CariId);
            
        }

        private void CariOzetYukle()
        {
            var tbBorc = Controls.Find("tBorcCari", true).FirstOrDefault() as TextBox;
            var tbAlacak = Controls.Find("tAlacakCari", true).FirstOrDefault() as TextBox;
            var tbBakiye = Controls.Find("tBakiye", true).FirstOrDefault() as TextBox;

            using (var db = new VeresiyedbEntities())
            {
                decimal borc = db.CariHareket
                    .Where(x => x.CariId == CariId && x.Tur == "BORC")
                    .Sum(x => (decimal?)x.Tutar) ?? 0m;

                decimal alacak = db.CariHareket
                    .Where(x => x.CariId == CariId &&
                                (x.Tur == "ALACAK" || x.Tur == "TAHSILAT" || x.Tur == "ODEME"))
                    .Sum(x => (decimal?)x.Tutar) ?? 0m;

                decimal bakiye = borc - alacak;

                if (tbBorc != null) tbBorc.Text = borc.ToString("N2");
                if (tbAlacak != null) tbAlacak.Text = alacak.ToString("N2");
                if (tbBakiye != null) tbBakiye.Text = bakiye.ToString("N2");

                if (tbBakiye != null)
                {
                    if (bakiye > 0) tbBakiye.ForeColor = Color.Maroon;
                    else if (bakiye < 0) tbBakiye.ForeColor = Color.DarkGreen;
                    else tbBakiye.ForeColor = Color.Black;
                }
            }
        }


        private int? OncekiCariIdGetir(int mevcutCariId)
        {
            using (var db = new VeresiyedbEntities())
            {
                return db.CariHesap
                    .Where(x => x.Id < mevcutCariId)
                    .OrderByDescending(x => x.Id)
                    .Select(x => (int?)x.Id)
                    .FirstOrDefault();
            }
        }

        private int? SonrakiCariIdGetir(int mevcutCariId)
        {
            using (var db = new VeresiyedbEntities())
            {
                return db.CariHesap
                    .Where(x => x.Id > mevcutCariId)
                    .OrderBy(x => x.Id)
                    .Select(x => (int?)x.Id)
                    .FirstOrDefault();
            }
        }

        private void HareketleriYenile()
        {
            using (var db = new VeresiyedbEntities())
            {
                // sadece bu carinin hareketleri
                var liste = db.CariHareket
                    .Where(x => x.CariId == CariId)
                    .OrderByDescending(x => x.Tarih)
                    .Select(x => new
                    {
                        x.Id,
                        x.Tarih,
                        x.Tur,
                        x.Tutar,
                        x.Aciklama
                    })
                    .ToList();

                dGridListeAc.DataSource = null;
                dGridListeAc.Columns.Clear();
                dGridListeAc.AutoGenerateColumns = true;
                dGridListeAc.DataSource = liste;

                if (dGridListeAc.Columns.Contains("Id"))
                    dGridListeAc.Columns["Id"].Visible = false;

                if (dGridListeAc.Columns.Contains("Tarih"))
                    dGridListeAc.Columns["Tarih"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";

                if (dGridListeAc.Columns.Contains("Tutar"))
                {
                    dGridListeAc.Columns["Tutar"].DefaultCellStyle.Format = "N2";
                    dGridListeAc.Columns["Tutar"].DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleRight;
                }

                Islemler.Gridduzenle(dGridListeAc);
                dGridListeAc.ClearSelection();
            }

            BakiyeYenile();
            CariOzetYukle();
        }

        private void BakiyeYenile()
        {
            // lBakiye labelin varsa göster, yoksa sessiz geç
            var lbl = Controls.Find("lBakiye", true).FirstOrDefault() as Label;
            if (lbl == null) return;

            using (var db = new VeresiyedbEntities())
            {
                var borc = db.CariHareket
                    .Where(x => x.CariId == CariId && x.Tur == "BORC")
                    .Sum(x => (decimal?)x.Tutar) ?? 0;

                var alacak = db.CariHareket
                    .Where(x => x.CariId == CariId && (x.Tur == "ALACAK" || x.Tur == "TAHSILAT" || x.Tur == "ODEME"))
                    .Sum(x => (decimal?)x.Tutar) ?? 0;

                lbl.Text = (borc - alacak).ToString("N2");
            }
        }

        // Ekle menüsü
        private void bEkle_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(bEkle, 0, bEkle.Height);
        }

        // Çift tık -> hareket düzenle
        private void DebugSeciliHareket()
        {
            if (dGridListeAc.CurrentRow == null)
            {
                MessageBox.Show("Seçili satır yok");
                return;
            }

            MessageBox.Show(
                "Kolonlar: " + string.Join(",", dGridListeAc.Columns.Cast<DataGridViewColumn>().Select(c => c.Name)) +
                "\nId değeri: " + (dGridListeAc.CurrentRow.Cells["Id"]?.Value?.ToString() ?? "NULL")
            );
        }

        private void dGridListeAc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            bBakiyeDuzenle_Click(sender, EventArgs.Empty); // çift tık = düzenle
        }

        // BORÇ
        private void bBorcMenuEkle_Click(object sender, EventArgs e)
        {
            using (var f = new fBorcEkle())
            {
                f.CariId = this.CariId;   // ✅ EN KRİTİK SATIR
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    HareketleriYenile();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }


        // TAHSİLAT
        private void tahsilatYapMenuEkle_Click(object sender, EventArgs e)
        {
            using (var f = new fTahsilatEkle())
            {
                f.CariId = CariId;   // ✅ lId yok, property ile geçiyoruz
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    HareketleriYenile();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        // ALACAK
        private void hesabaAlacakEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var f = new fAlacak())
            {
                f.CariId = this.CariId;
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    HareketleriYenile();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }


        // ÖDEME
        private void ödemeYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var f = new fOdeme())
            {
                f.CariId = this.CariId;  // ✅ şart
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    HareketleriYenile();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }


        // Kısayollar
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            if (keyData == Keys.F5) { bBorcMenuEkle_Click(null, EventArgs.Empty); return true; }
            if (keyData == Keys.F6) { tahsilatYapMenuEkle_Click(null, EventArgs.Empty); return true; }
            if (keyData == Keys.F7) { hesabaAlacakEkleToolStripMenuItem_Click(null, EventArgs.Empty); return true; }
            if (keyData == Keys.F8) { ödemeYapToolStripMenuItem_Click(null, EventArgs.Empty); return true; }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void bOnceki_Click(object sender, EventArgs e)
        {
            var prevId = OncekiCariIdGetir(CariId);
            if (prevId == null) { MessageBox.Show("Önceki cari yok."); return; }
            CariYukle(prevId.Value);
        }

        private void bSonraki_Click(object sender, EventArgs e)
        {
            var nextId = SonrakiCariIdGetir(CariId);
            if (nextId == null) { MessageBox.Show("Sonraki cari yok."); return; }
            CariYukle(nextId.Value);
        }

        private void bGeri_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CariYukle(int yeniCariId)
        {
            CariId = yeniCariId;

            using (var db = new VeresiyedbEntities())
            {
                var cari = db.CariHesap.FirstOrDefault(x => x.Id == CariId);
                if (cari == null)
                {
                    MessageBox.Show("Cari bulunamadı.");
                    return;
                }

                bCariAdi.Text = cari.Unvan;
            }

            HareketleriYenile();
            CariOzetYukle();
        }


        private void bBakiyeSil_Click(object sender, EventArgs e)
        {
            if (dGridListeAc.CurrentRow == null)
            {
                MessageBox.Show("Silmek için bir hareket seç.");
                return;
            }

            if (!dGridListeAc.Columns.Contains("Id"))
            {
                MessageBox.Show("Grid'de Id kolonu yok.");
                return;
            }

            int hareketId = Convert.ToInt32(dGridListeAc.CurrentRow.Cells["Id"].Value);

            if (MessageBox.Show("Seçili hareket silinsin mi?", "Onay",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using (var db = new VeresiyedbEntities())
            {
                // güvenlik: hem Id hem cariId ile sil
                var hareket = db.CariHareket.FirstOrDefault(x => x.Id == hareketId && x.CariId == this.CariId);
                if (hareket == null)
                {
                    MessageBox.Show("Hareket bulunamadı.");
                    return;
                }

                db.CariHareket.Remove(hareket);
                db.SaveChanges();
            }

            HareketleriYenile();
            this.DialogResult = DialogResult.OK;
        }

        private void bBakiyeDuzenle_Click(object sender, EventArgs e)
        {
            if (dGridListeAc.CurrentRow == null)
            {
                MessageBox.Show("Düzenlemek için bir hareket seç.");
                return;
            }

            // Id kolonu yoksa (bazı gridlerde Name farklı olabilir)
            int hareketId;

            if (dGridListeAc.Columns.Contains("Id") && dGridListeAc.CurrentRow.Cells["Id"].Value != null)
            {
                hareketId = Convert.ToInt32(dGridListeAc.CurrentRow.Cells["Id"].Value);
            }
            else
            {
                // fallback: ilk hücreden dene
                if (dGridListeAc.CurrentRow.Cells.Count == 0 || dGridListeAc.CurrentRow.Cells[0].Value == null)
                {
                    MessageBox.Show("Hareket Id bulunamadı.");
                    return;
                }
                hareketId = Convert.ToInt32(dGridListeAc.CurrentRow.Cells[0].Value);
            }

            using (var f = new fHareketDuzenle())
            {
                f.HareketId = hareketId;

                var dr = f.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    HareketleriYenile(); // grid + bakiye yenile
                    this.DialogResult = DialogResult.OK;
                }
            }
        }


    }
}
