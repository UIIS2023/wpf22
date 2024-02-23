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
    /// Interaction logic for FrmKorisnik.xaml
    /// </summary>
    public partial class FrmKorisnik : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmKorisnik()
        {
            InitializeComponent();
            txtImeKorisnika.Focus();
            konekcija = kon.KreirajKonekciju();
        }

        public FrmKorisnik(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtImeKorisnika.Focus();
            konekcija = kon.KreirajKonekciju();
            this.azuriraj = azuriraj;
            this.red = red;
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

                cmd.Parameters.Add("@imeKorisnika", SqlDbType.NVarChar).Value = txtImeKorisnika.Text;
                cmd.Parameters.Add("@prezimeKorisnika", SqlDbType.NVarChar).Value = txtPrezimeKorisnika.Text;
                cmd.Parameters.Add("@mailKorisnika", SqlDbType.NVarChar).Value = txtMailKorisnika.Text;

                if(azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblKorisnik
                                        set imeKorisnika = @imeKorisnika, prezimeKorisnika = @prezimeKorisnika, mailKorisnika = @mailKorisnika
                                        where korisnikID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO tblKorisnik(imeKorisnika, prezimeKorisnika, mailKorisnika)
                                    VALUES (@imeKorisnika, @prezimeKorisnika, @mailKorisnika)";
                }

                
                cmd.ExecuteNonQuery(); //ova metoda pokrece izvrsenje nase komande gore
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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
