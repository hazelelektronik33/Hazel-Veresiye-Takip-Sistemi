using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Veresiye
{
    public partial class fHareketDuzenle : Form
    {
        public fHareketDuzenle()
        {
            InitializeComponent();

            // ✅ Click eventleri garanti bağla
            bKaydet.Click -= bKaydet_Click;
            bKaydet.Click += bKaydet_Click;

            bVazgec.Click -= bVazgec_Click;
            bVazgec.Click += bVazgec_Click;

            // ✅ Combo elle yazılmasın
            cbTur.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public int HareketId { get; set; }

        // ✅ Event bağımlılığını bitiriyoruz: Load yerine OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (HareketId <= 0)
            {
                MessageBox.Show("HareketId gelmedi.");
                Close();
                return;
            }

            // ✅ Combo her zaman doldur
            cbTur.Items.Clear();
            cbTur.Items.AddRange(new object[] { "BORC", "TAHSILAT", "ALACAK", "ODEME" });
            cbTur.SelectedIndex = 0;

            using (var db = new VeresiyedbEntities())
            {
                var h = db.CariHareket.FirstOrDefault(x => x.Id == HareketId);
                if (h == null)
                {
                    MessageBox.Show("Hareket bulunamadı");
                    Close();
                    return;
                }

                dtTarih.Value = h.Tarih;
                tTutar.Text = h.Tutar.ToString("0.##", CultureInfo.CurrentCulture);
                tAciklama.Text = (h.Aciklama ?? "");

                // Tür normalize
                var turDb = (h.Tur ?? "").Trim().ToUpperInvariant();
                turDb = turDb.Replace("Ö", "O").Replace("Ç", "C").Replace("Ş", "S")
                             .Replace("Ğ", "G").Replace("İ", "I").Replace("Ü", "U");

                int idx = cbTur.FindStringExact(turDb);
                cbTur.SelectedIndex = (idx >= 0) ? idx : 0;
            }
        }

        private void bVazgec_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void bKaydet_Click(object sender, EventArgs e)
        {
            // ✅ Bu mesaj çıkmıyorsa Click hala bağlanmıyordur (ama burada artık bağlanır)
            // MessageBox.Show("Kaydet tetiklendi");

            string tur = cbTur.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(tur))
            {
                MessageBox.Show("Tür seç.");
                return;
            }

            if (!decimal.TryParse(tTutar.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal tutar) || tutar <= 0)
            {
                MessageBox.Show("Tutar geçersiz");
                return;
            }

            using (var db = new VeresiyedbEntities())
            {
                var h = db.CariHareket.FirstOrDefault(x => x.Id == HareketId);
                if (h == null)
                {
                    MessageBox.Show("Hareket bulunamadı");
                    return;
                }

                h.Tur = tur;
                h.Tarih = dtTarih.Value;
                h.Tutar = tutar;
                h.Aciklama = (tAciklama.Text ?? "").Trim();

                db.SaveChanges();
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
