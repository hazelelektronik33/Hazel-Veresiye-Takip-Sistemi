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
    public partial class fKayit : Form
    {
        public fKayit()
        {
            InitializeComponent();
        }

        private void bGiris_Click(object sender, EventArgs e)
        {
            if (tFirmaUnvani.Text!="" && tVergiDairesi.Text!="" && tVergiNo.Text!="")
            {
                try
                {
                    using (var db=new VeresiyedbEntities())
                    {
                        Kullanici k = new Kullanici();
                        k.FirmaUnvani = tFirmaUnvani.Text;
                        k.Telefon = tTelefon.Text;
                        k.VergiDairesi = tVergiDairesi.Text;
                        k.VergiNo = tVergiNo.Text;
                        k.Adres = tAdres.Text;
                        k.Il = tIl.Text;
                        k.Ilce = tIlce.Text;
                        k.Eposta = tEposta.Text;
                        db.Kullanici.Add(k);
                        db.SaveChanges();
                        fAcilis f = new fAcilis();
                        f.Show();
                        this.Hide();

                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }

            }
            else
            {
                MessageBox.Show("Zorunlu Alanları Yazınız.");
            }
        }
    }
}
