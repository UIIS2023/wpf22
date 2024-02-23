using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for FrmVino.xaml
    /// </summary>
    public partial class FrmVino : Window
    {

        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmVino()
        {
            InitializeComponent();
            txtNazivVina.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public FrmVino(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtNazivVina.Focus();
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

                string vratiVrstuVina = @"SELECT vrstaVinaID, vrstaVina FROM tblVrstaVina";
                SqlDataAdapter daVrstaVina = new SqlDataAdapter(vratiVrstuVina, konekcija);
                DataTable dtVrstaVina = new DataTable();
                daVrstaVina.Fill(dtVrstaVina);
                cbVrstaVina.ItemsSource = dtVrstaVina.DefaultView;
                daVrstaVina.Dispose();
                dtVrstaVina.Dispose();


                string vratiNivoSlatkoce = @"SELECT nivoSlatkoceID, nivoSlatkoce FROM tblNivoSlatkoce";
                SqlDataAdapter daNivoSlatkoce = new SqlDataAdapter(vratiNivoSlatkoce, konekcija);
                DataTable dtNivoSlatkoce = new DataTable();
                daNivoSlatkoce.Fill(dtNivoSlatkoce);
                cbNivoSlatkoce.ItemsSource = dtNivoSlatkoce.DefaultView;
                daNivoSlatkoce.Dispose();
                dtNivoSlatkoce.Dispose();

                string vratiRecenziju = @"SELECT recenzijaID, komentar FROM tblRecenzija";
                SqlDataAdapter daRecenzija = new SqlDataAdapter(vratiRecenziju, konekcija);
                DataTable dtRecenzija = new DataTable();
                daRecenzija.Fill(dtRecenzija);
                cbRecenzija.ItemsSource = dtRecenzija.DefaultView;
                daRecenzija.Dispose();
                dtRecenzija.Dispose();

                string vratiDobavljaca = @"SELECT dobavljacID, imeDobavljaca FROM tblDobavljac";
                SqlDataAdapter daDobavljac = new SqlDataAdapter(vratiDobavljaca, konekcija);
                DataTable dtDobavljac = new DataTable();
                daDobavljac.Fill(dtDobavljac);
                cbDobavljac.ItemsSource = dtDobavljac.DefaultView;
                daDobavljac.Dispose();
                dtDobavljac.Dispose();
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

                cmd.Parameters.Add("@nazivVina", SqlDbType.NVarChar).Value = txtNazivVina.Text;
                cmd.Parameters.Add("@godinaProizvodnje", SqlDbType.Int).Value = txtGodinaProizvodnje.Text;
                cmd.Parameters.Add("@vrstaVinaID", SqlDbType.Int).Value = cbVrstaVina.SelectedValue;
                cmd.Parameters.Add("@nivoSlatkoceID", SqlDbType.Int).Value = cbNivoSlatkoce.SelectedValue;
                cmd.Parameters.Add("@recenzijaID", SqlDbType.Int).Value = cbRecenzija.SelectedValue;
                cmd.Parameters.Add("@dobavljacID", SqlDbType.Int).Value = cbDobavljac.SelectedValue;

                if(azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblVino
                                        set nazivVina = @nazivVina, godinaProizvodnje = @godinaProizvodnje, vrstaVinaID = @vrstaVinaID,
                                            nivoSlatkoceID = @nivoSlatkoceID, recenzijaID = @recenzijaID, dobavljacID = @dobavljacID
                                        where vinoID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO tblVino(nazivVina,godinaProizvodnje,vrstaVinaID,nivoSlatkoceID,recenzijaID,dobavljacID)
                                    VALUES(@nazivVina,@godinaProizvodnje,@vrstaVinaID,@nivoSlatkoceID,@recenzijaID,@dobavljacID)";
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
