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
    /// Interaction logic for FrmRecenzija.xaml
    /// </summary>
    public partial class FrmRecenzija : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmRecenzija()
        {
            InitializeComponent();
            txtKomentar.Focus();
            konekcija = kon.KreirajKonekciju();
        }

        public FrmRecenzija(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtKomentar.Focus();
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

                cmd.Parameters.Add("@komentar", SqlDbType.NVarChar).Value = txtKomentar.Text;
                cmd.Parameters.Add("@ocjena", SqlDbType.NVarChar).Value = txtOcjena.Text;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblRecenzija
                                        set komentar = @komentar, ocjena = @ocjena
                                        where recenzijaID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO tblRecenzija(komentar, ocjena)
                                    VALUES (@komentar, @ocjena)";
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
