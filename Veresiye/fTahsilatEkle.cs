using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veresiye
{
    public partial class fTahsilatEkle : Form
    {
        public int CariId { get; set; }
        
        public fTahsilatEkle()
        {
            InitializeComponent();
        }

        private void bVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bKaydet_Click(object sender, EventArgs e)
        {
            int cariId = this.CariId;
            if (cariId <= 0)
            {
                MessageBox.Show("Cari seçilmedi (CariId gelmedi).");
                return;
            }

            if (!decimal.TryParse(tTutarTahsilat.Text, out decimal tutar) || tutar <= 0)
            {
                MessageBox.Show("Tutar geçersiz");
                return;
            }

            using (var db = new VeresiyedbEntities())
            {
                var h = new CariHareket
                {
                    CariId = cariId,
                    Tarih = dateTimePicker1.Value,
                    Tur = "TAHSILAT",
                    Tutar = tutar,
                    Aciklama = tAciklamaTahsilat.Text.Trim()
                };

                db.CariHareket.Add(h);
                db.SaveChanges();
            }

            this.DialogResult = DialogResult.OK; // 🔥 önemli (yenileme için)
            this.Close();
        }


    }
}
