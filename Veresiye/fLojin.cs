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
    public partial class fLojin : Form
    {
        public fLojin()
        {
            InitializeComponent();
        }

        private void bGiris_Click(object sender, EventArgs e)
        {
            if (tKullaniciAdi.Text!="" && tParola.Text!="")
            {
                try
                {
                    using (var db = new VeresiyedbEntities())
                    {
                        if (db.Kullanici.Any(x=> x.FirmaUnvani==""))
                        {
                            var bak = db.Kullanici.Where(x => x.KullaniciAdi == tKullaniciAdi.Text && x.Parola == tParola.Text).FirstOrDefault();
                            if (bak != null)
                            {
                                
                                    fKayit f = new fKayit();
                                    f.Show();
                                    this.Hide();
                                
                               
                               
                            }
                        }
                        else
                        {
                            fAcilis f = new fAcilis();
                            f.Show();
                            this.Hide();
                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }

            }
            else
            {
                MessageBox.Show("Boş Geçme");
            }
            
        }

        private void bCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
