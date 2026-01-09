using System;
using System.Globalization;
using System.Windows.Forms;

namespace Veresiye
{
    public partial class fBorcEkle : Form
    {
        public fBorcEkle()
        {
            InitializeComponent();
        }

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

            // ✅ TR formatını garanti edelim (1.234,50 gibi)
            if (!decimal.TryParse(textBox3.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal tutar) || tutar <= 0)
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
                    Tur = "BORC",
                    Tutar = tutar,
                    Aciklama = (textBox2.Text ?? "").Trim()
                };

                db.CariHareket.Add(h);
                db.SaveChanges();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
