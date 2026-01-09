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
    public partial class fCariEkle : Form
    {
        public fCariEkle()
        {
            InitializeComponent();
        }

        public int YeniCariId { get; private set; }
        public int? EditCariId { get; set; }

       
        private void bKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tUnvan.Text) || string.IsNullOrWhiteSpace(tYetkili.Text))
            {
                MessageBox.Show("Unvan ve Yetkili boş olamaz.");
                return;
            }

            try
            {
                using (var db = new VeresiyedbEntities())
                {
                    CariHesap c;

                    if (EditCariId.HasValue)
                    {
                        c = db.CariHesap.FirstOrDefault(x => x.Id == EditCariId.Value);
                        if (c == null) { MessageBox.Show("Cari bulunamadı"); return; }
                    }
                    else
                    {
                        c = new CariHesap();
                        db.CariHesap.Add(c);
                    }

                    c.Tarih = dTarih.Value;
                    c.Unvan = tUnvan.Text.Trim();
                    c.Yetkili = tYetkili.Text.Trim();
                    c.Telefon = tTelefon.Text.Trim();
                    c.Faks = tFax.Text.Trim();
                    c.Gsm = tGsm.Text.Trim();
                    c.Adres = tAdres.Text.Trim();
                    c.Il = tIl.Text.Trim();
                    c.Ilce = tIlce.Text.Trim();
                    c.VergiDairesi = tVdairesi.Text.Trim();
                    c.VergiNo = tVno.Text.Trim();
                    c.Eposta = tEposta.Text.Trim();
                    c.CariLimit = tCariLimit.Text.Trim();

                    db.SaveChanges();

                    // sadece eklemede cari kodu üret
                    if (!EditCariId.HasValue)
                    {
                        c.CariKodu = "HZL " + c.Id;   // istersen 000000 format
                        db.SaveChanges();
                        YeniCariId = c.Id;
                        MessageBox.Show("Kayıt Yapıldı\nCari Kodu: " + c.CariKodu);
                    }
                    else
                    {
                        YeniCariId = c.Id;
                        MessageBox.Show("Güncellendi");
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bDegistir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fCariEkle_Load(object sender, EventArgs e)
        {
            if (!EditCariId.HasValue) return;

            using (var db = new VeresiyedbEntities())
            {
                var c = db.CariHesap.FirstOrDefault(x => x.Id == EditCariId.Value);
                if (c == null) { MessageBox.Show("Cari bulunamadı"); Close(); return; }

                dTarih.Value = c.Tarih ?? DateTime.Now;   // Tarih nullable değilse direkt c.Tarih
                tUnvan.Text = c.Unvan;
                tYetkili.Text = c.Yetkili;
                tTelefon.Text = c.Telefon;
                tFax.Text = c.Faks;
                tGsm.Text = c.Gsm;
                tAdres.Text = c.Adres;
                tIl.Text = c.Il;
                tIlce.Text = c.Ilce;
                tVdairesi.Text = c.VergiDairesi;
                tVno.Text = c.VergiNo;
                tEposta.Text = c.Eposta;
                tCariLimit.Text = c.CariLimit;
            }
        }

    }
}
