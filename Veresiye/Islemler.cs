using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veresiye
{
    static class Islemler
    {



        public static double DoubleYap(string deger)
        {
            double sonuc = 0;
            double.TryParse(deger, NumberStyles.Currency, CultureInfo.CurrentUICulture.NumberFormat, out sonuc);
            return sonuc;
        }
        public static double DoubleYapDolar(string deger)
        {
            double sonuc = 0;
            double.TryParse(deger, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US").NumberFormat, out sonuc);
            return sonuc;
        }

        public static void Gridduzenle(DataGridView dgv)
        {
            if (dgv.Columns.Count <= 0) return;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                // Kolon adı üzerinden git (HeaderText değişse bile bozulmaz)
                switch (col.Name)
                {
                    case "Id":
                        col.HeaderText = "No";
                        col.Visible = false; // Id genelde gizli
                        break;

                    case "CariKodu":
                        col.HeaderText = "Cari Kodu";
                        break;

                    case "Unvan":
                    case "CariUnvani":
                        col.HeaderText = "Cari Ünvanı";
                        break;

                    case "Il":
                    case "Sehir":
                        col.HeaderText = "Şehir";
                        break;

                    case "Tarih":
                    case "SonIslem":
                        col.HeaderText = "Son İşlem";
                        col.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                        break;

                    case "Kasa":
                    case "Bakiye":
                        col.HeaderText = "Bakiye";
                        col.DefaultCellStyle.Format = "N2";
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        break;

                    case "Aciklama":
                        col.HeaderText = "Açıklama";
                        break;

                    case "Yetkili":
                        col.HeaderText = "Yetkili";
                        break;

                    case "Gsm":
                        col.HeaderText = "GSM";
                        break;

                    case "Telefon":
                        col.HeaderText = "Telefon";
                        break;

                    case "Faks":
                        col.HeaderText = "Faks";
                        break;

                    case "Adres":
                        col.HeaderText = "Adres";
                        break;

                    case "Ilce":
                        col.HeaderText = "İlçe";
                        break;

                    case "VergiDairesi":
                        col.HeaderText = "V. Dairesi";
                        break;

                    case "VergiNo":
                        col.HeaderText = "Vergi No";
                        break;

                    case "Eposta":
                        col.HeaderText = "E-Mail";
                        break;

                    case "CariLimit":
                        col.HeaderText = "Cari Limit";
                        break;

                    case "Hesap":
                        col.HeaderText = "Hesap";
                        break;

                    case "Tur":
                        col.HeaderText = "Tür";
                        break;

                    case "Alacak":
                        col.HeaderText = "Alacak";
                        col.DefaultCellStyle.Format = "N2";
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        break;

                    case "Borc":
                        col.HeaderText = "Borç";
                        col.DefaultCellStyle.Format = "N2";
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        break;
                }
            }
        }
    }

    }
