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
    /// Interaction logic for FrmVinoPorudzbina.xaml
    /// </summary>
    public partial class FrmVinoPorudzbina : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmVinoPorudzbina()
        {
            InitializeComponent();
            cbVino.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();

        }
        public FrmVinoPorudzbina(bool azuriraj, DataRowView red)
         {
            InitializeComponent();
            cbVino.Focus();
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

                string vratiVino = @"SELECT vinoID, nazivVina  FROM tblVino";
                SqlDataAdapter daVino = new SqlDataAdapter(vratiVino, konekcija);
                DataTable dtVino = new DataTable();
                daVino.Fill(dtVino);
                cbVino.ItemsSource = dtVino.DefaultView;
                daVino.Dispose();
                dtVino.Dispose();


                string vratiPorudzbinu = @"SELECT porudzbinaID, brojRacuna FROM tblPorudzbina";
                SqlDataAdapter daPorudzbina = new SqlDataAdapter(vratiPorudzbinu, konekcija);
                DataTable dtPorudzbina = new DataTable();
                daPorudzbina.Fill(dtPorudzbina);
                cbPorudzbina.ItemsSource = dtPorudzbina.DefaultView;
                daPorudzbina.Dispose();
                dtPorudzbina.Dispose();

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

                cmd.Parameters.Add("@vinoID", SqlDbType.Int).Value = cbVino.SelectedValue;
                cmd.Parameters.Add("@porudzbinaID", SqlDbType.Int).Value = cbPorudzbina.SelectedValue;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblVinoPorudzbina
                                        set vinoID = @vinoID,porudzbinaID = @porudzbinaID
                                        where vinoPorudzbinaID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO tblVinoPorudzbina(vinoID,porudzbinaID)
                                    VALUES(@vinoID,@porudzbinaID)";
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
