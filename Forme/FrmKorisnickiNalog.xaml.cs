using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Vinarija.Forme
{
    /// <summary>
    /// Interaction logic for FrmKorisnickiNalog.xaml
    /// </summary>
    public partial class FrmKorisnickiNalog : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmKorisnickiNalog()
        {
            InitializeComponent();
            txtImeNaloga.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

         public FrmKorisnickiNalog(bool azuriraj, DataRowView red)
         {
            InitializeComponent();
            txtImeNaloga.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
            this.azuriraj = azuriraj;
            this.red = red;
        }
        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();

                string vratiKorisnika = @"SELECT korisnikID, imeKorisnika  FROM tblKorisnik";
                SqlDataAdapter daKorisnik = new SqlDataAdapter(vratiKorisnika, konekcija);
                DataTable dtKorisnik = new DataTable();
                daKorisnik.Fill(dtKorisnik);
                cbKorisnik.ItemsSource = dtKorisnik.DefaultView;
                daKorisnik.Dispose();
                dtKorisnik.Dispose();

            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuce liste nisu popunjene", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };

                cmd.Parameters.Add("@imeNaloga", SqlDbType.NVarChar).Value = txtImeNaloga.Text;
                cmd.Parameters.Add("@lozinka", SqlDbType.NVarChar).Value = txtLozinka.Text;
                cmd.Parameters.Add("@korisnikID", SqlDbType.Int).Value = cbKorisnik.SelectedValue;
               
                if(azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblKorisnickiNalog
                                        set imeNaloga = @imeNaloga, lozinka = @lozinka, korisnikID = @korisnikID
                                        where korisnickiNalogID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO tblKorisnickiNalog(imeNaloga,lozinka,korisnikID)
                                    VALUES(@imeNaloga,@lozinka,@korisnikID)";
                }

                
                cmd.ExecuteNonQuery(); //ova metoda pokrece izvrsenje nase komande gore
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Doslo je do greske prilikom konverzija podataka", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
