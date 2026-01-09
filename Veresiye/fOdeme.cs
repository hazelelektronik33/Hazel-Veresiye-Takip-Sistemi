using System;
using System.Globalization;
using System.Windows.Forms;

namespace Veresiye
{
    public partial class fOdeme : Form
    {
        public fOdeme()
        {
            InitializeComponent();
        }

        // ✅ fCariAc burayı set edecek
        public int CariId { get; set; }

        private void bVazgec_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bKaydet_Click(object sender, EventArgs e)
        {
            if (CariId <= 0)
            {
                MessageBox.Show("Cari seçilmedi (CariId gelmedi).");
                return;
            }

            // ✅ textbox adlarını kendi formuna göre kontrol et
            // tTutarOdeme, tAciklamaOdeme, dateTimePicker1
            if (!decimal.TryParse(tTutarOdeme.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal tutar) || tutar <= 0)
            {
                MessageBox.Show("Tutar geçersiz");
                return;
            }

            using (var db = new VeresiyedbEntities())
            {
                var h = new CariHareket
                {
                    CariId = CariId,
                    Tarih = dateTimePicker1.Value,
                    Tur = "ODEME",
                    Tutar = tutar,
                    Aciklama = (tAciklamaOdeme.Text ?? "").Trim()
                };

                db.CariHareket.Add(h);
                db.SaveChanges();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
