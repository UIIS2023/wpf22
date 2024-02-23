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
    /// Interaction logic for FrmNivoSlatkoce.xaml
    /// </summary>
    public partial class FrmNivoSlatkoce : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmNivoSlatkoce()
        {
            InitializeComponent();
            txtNivoSlatkoce.Focus();
            konekcija = kon.KreirajKonekciju();
        }

        public FrmNivoSlatkoce(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtNivoSlatkoce.Focus();
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

                cmd.Parameters.Add("@nivoSlatkoce", SqlDbType.NVarChar).Value = txtNivoSlatkoce.Text;
              
                if(azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblNivoSlatkoce
                                        set nivoSlatkoce = @nivoSlatkoce
                                        where nivoSlatkoceID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO tblNivoSlatkoce(nivoSlatkoce)
                                    VALUES (@nivoSlatkoce)";
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
