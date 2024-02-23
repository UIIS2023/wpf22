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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vinarija.Forme;

namespace Vinarija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string ucitanaTabela;
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        #region Select upiti
        private static string vrsteVinaSelect = @"select vrstaVinaID as ID, vrstaVina as 'Vrsta vina'  from tblVrstaVina";
        private static string nivoiSlatkoceSelect = @"select nivoSlatkoceID as ID, nivoSlatkoce as 'Nivo slatkoce'  from tblNivoSlatkoce";
        private static string recenzijeSelect = @"select recenzijaID as ID, komentar as Komentar, ocjena as Ocjena  from tblRecenzija";
        private static string dobavljaciSelect = @"select dobavljacID as ID, grad as Grad, imeDobavljaca as Dobavljac  from tblDobavljac";
        private static string korisniciSelect = @"select korisnikID as ID, imeKorisnika + ' ' + prezimeKorisnika as Korisnik, mailKorisnika as 'Mail adresa' from tblKorisnik";
        private static string korisnickiNaloziSelect = @"select korisnickiNalogID as ID, imeKorisnika + ' ' + prezimeKorisnika as Korisnik, imeNaloga as Nalog, lozinka as Lozinka
                              from tblKorisnickiNalog join tblKorisnik on tblKorisnickiNalog.korisnikID = tblKorisnik.korisnikID";
        private static string porudzbineSelect = @"select porudzbinaID as ID, kolicinaProizvoda as Kolicina, datum as Datum, brojRacuna as 'Broj racuna', cijena as Cijena  from tblPorudzbina";
        private static string vinoPorudzbinaSelect = @"select vinoPorudzbinaID as ID, nazivVina as Vino, brojRacuna as 'Broj racuna'
                              from tblVinoPorudzbina join tblVino on tblVinoPorudzbina.vinoID = tblVino.vinoID
                                                     join tblPorudzbina on tblVinoPorudzbina.porudzbinaID = tblPorudzbina.porudzbinaID";
        private static string vinoSelect = @"select vinoID as ID, nazivVina as Vino, godinaProizvodnje as 'Godina proizvodnje', vrstaVina as Vrsta, nivoSlatkoce as Slatkoca, komentar as Recenzija, imeDobavljaca as Dobavljac 
                                            from tblVino join tblVrstaVina on tblVino.vrstaVinaID = tblVrstaVina.vrstaVinaID
                                                         join tblNivoSlatkoce on tblVino.nivoSlatkoceID = tblNivoSlatkoce.nivoSlatkoceID
                                                         join tblRecenzija on tblVino.recenzijaID = tblRecenzija.recenzijaID
                                                         join tblDobavljac on tblVino.dobavljacID = tblDobavljac.dobavljacID";

        #endregion

        #region Select sa uslovom
        private static string selectUslovVrsteVina = @"select * from tblVrstaVina where vrstaVinaID=";
        private static string selectUslovNivoiSlatkoce = @"select * from tblNivoSlatkoce where nivoSlatkoceID=";
        private static string selectUslovRecenzije = @"select * from tblRecenzija where recenzijaID=";
        private static string selectUslovDobavljaci = @"select * from tblDobavljac where dobavljacID=";
        private static string selectUslovKorisnici = @"select * from tblKorisnik where korisnikID=";
        private static string selectUslovKorisnickiNalozi = @"select * from tblKorisnickiNalog where korisnickiNalogID=";
        private static string selectUslovVinoPorudzbina = @"select * from tblVinoPorudzbina where vinoPorudzbinaID=";
        private static string selectUslovPorudzbine = @"select * from tblPorudzbina where porudzbinaID=";
        private static string selectUslovVina = @"select * from tblVino where vinoID=";
        #endregion

        #region Delete naredbe
        private static string vrsteVinaDelete = @"delete from tblVrstaVina where vrstaVinaID=";
        private static string nivoiSlatkoceDelete = @"delete from tblNivoSlatkoce where nivoSlatkoceID=";
        private static string recenzijeDelete = @"delete from tblRecenzija where recenzijaID=";
        private static string dobavljaciDelete = @"delete from tblDobavljac where dobavljacID=";
        private static string korisniciDelete = @"delete from tblKorisnik where korisnikID=";
        private static string korisnickiNaloziDelete = @"delete from tblKorisnickiNalog where korisnickiNalogID=";
        private static string vinoPorudzbinaDelete = @"delete from tblVinoPorudzbina where vinoPorudzbinaID=";
        private static string porudzbineDelete = @"delete from tblPorudzbina where porudzbinaID=";
        private static string vinaDelete = @"delete from tblVino where vinoID=";
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            UcitajPodatke(vinoSelect);
        }

        private void UcitajPodatke(string selectUpit)
        {
            try
            {
                konekcija.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataGridCentralni != null)
                {
                    dataGridCentralni.ItemsSource = dataTable.DefaultView;
                }
                ucitanaTabela = selectUpit;
                dataAdapter.Dispose();
                dataTable.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show("Neuspjesno ucitani podaci", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

        }

        private void btnVino_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(vinoSelect);
        }

        private void btnVrstaVina_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(vrsteVinaSelect);

        }

        private void btnNivoSlatkoce_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(nivoiSlatkoceSelect);

        }

        private void btnKorisnik_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(korisniciSelect);

        }

        private void btnKorisnickiNalog_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(korisnickiNaloziSelect);

        }

        private void btnDobavljac_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dobavljaciSelect);

        }

        private void btnRecenzija_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(recenzijeSelect);

        }

        private void btnPorudzbina_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(porudzbineSelect);

        }

        private void btnVinoPorudzbina_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(vinoPorudzbinaSelect);

        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window prozor;

            if (ucitanaTabela.Equals(vrsteVinaSelect))
            {
                prozor = new FrmVrstaVina();
                prozor.ShowDialog();
                UcitajPodatke(vrsteVinaSelect);
            }
            else if (ucitanaTabela.Equals(nivoiSlatkoceSelect))
            {
                prozor = new FrmNivoSlatkoce();
                prozor.ShowDialog();
                UcitajPodatke(nivoiSlatkoceSelect);
            }
            else if (ucitanaTabela.Equals(vinoSelect))
            {
                prozor = new FrmVino();
                prozor.ShowDialog();
                UcitajPodatke(vinoSelect);
            }
            else if (ucitanaTabela.Equals(korisniciSelect))
            {
                prozor = new FrmKorisnik();
                prozor.ShowDialog();
                UcitajPodatke(korisniciSelect);
            }
            else if (ucitanaTabela.Equals(korisnickiNaloziSelect))
            {
                prozor = new FrmKorisnickiNalog();
                prozor.ShowDialog();
                UcitajPodatke(korisnickiNaloziSelect);
            }
            else if (ucitanaTabela.Equals(dobavljaciSelect))
            {
                prozor = new FrmDobavljac();
                prozor.ShowDialog();
                UcitajPodatke(dobavljaciSelect);
            }
            else if (ucitanaTabela.Equals(recenzijeSelect))
            {
                prozor = new FrmRecenzija();
                prozor.ShowDialog();
                UcitajPodatke(recenzijeSelect);
            }
            else if (ucitanaTabela.Equals(porudzbineSelect))
            {
                prozor = new FrmPorudzbina();
                prozor.ShowDialog();
                UcitajPodatke(porudzbineSelect);
            }
            else if (ucitanaTabela.Equals(vinoPorudzbinaSelect))
            {
                prozor = new FrmVinoPorudzbina();
                prozor.ShowDialog();
                UcitajPodatke(vinoPorudzbinaSelect);
            }
        }

        private void btnIzmijeni_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(vrsteVinaSelect))
            {
                PopuniFormu(selectUslovVrsteVina);
                UcitajPodatke(vrsteVinaSelect);
            }
            else if (ucitanaTabela.Equals(nivoiSlatkoceSelect))
            {
                PopuniFormu(selectUslovNivoiSlatkoce);
                UcitajPodatke(nivoiSlatkoceSelect);
            }
            else if (ucitanaTabela.Equals(vinoSelect))
            {
                PopuniFormu(selectUslovVina);
                UcitajPodatke(vinoSelect);
            }
            else if (ucitanaTabela.Equals(korisniciSelect))
            {
                PopuniFormu(selectUslovKorisnici);
                UcitajPodatke(korisniciSelect);
            }
            else if (ucitanaTabela.Equals(korisnickiNaloziSelect))
            {
                PopuniFormu(selectUslovKorisnickiNalozi);
                UcitajPodatke(korisnickiNaloziSelect);
            }
            else if (ucitanaTabela.Equals(dobavljaciSelect))
            {
                PopuniFormu(selectUslovDobavljaci);
                UcitajPodatke(dobavljaciSelect);
            }
            else if (ucitanaTabela.Equals(recenzijeSelect))
            {
                PopuniFormu(selectUslovRecenzije);
                UcitajPodatke(recenzijeSelect);
            }
            else if (ucitanaTabela.Equals(porudzbineSelect))
            {
                PopuniFormu(selectUslovPorudzbine);
                UcitajPodatke(porudzbineSelect);
            }
            else if (ucitanaTabela.Equals(vinoPorudzbinaSelect))
            {
                PopuniFormu(selectUslovVinoPorudzbina);
                UcitajPodatke(vinoPorudzbinaSelect);
            }
        }

        private void PopuniFormu(string selectUslov)
        {
            try
            {
                konekcija.Open();
                azuriraj = true;
                red = (DataRowView)dataGridCentralni.SelectedItems[0]; //mozemo da selektujemo samo jedan element i zbog toga[0]
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                cmd.CommandText = selectUslov + "@id";
                SqlDataReader citac = cmd.ExecuteReader();
                if (citac.Read())
                {
                    if (ucitanaTabela.Equals(vrsteVinaSelect))
                    {
                      FrmVrstaVina prozorVrstaVina = new FrmVrstaVina(azuriraj, red);
                        prozorVrstaVina.txtVrstaVina.Text = citac["vrstaVina"].ToString();
                        prozorVrstaVina.ShowDialog();

                    }
                    else if (ucitanaTabela.Equals(nivoiSlatkoceSelect))
                    {
                        FrmNivoSlatkoce prozorNivoSlatkoce = new FrmNivoSlatkoce(azuriraj, red);
                        prozorNivoSlatkoce.txtNivoSlatkoce.Text = citac["nivoSlatkoce"].ToString();
                        prozorNivoSlatkoce.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(vinoSelect))
                    {
                        FrmVino prozorVino = new FrmVino(azuriraj, red);
                        prozorVino.txtNazivVina.Text = citac["nazivVina"].ToString();
                        prozorVino.txtGodinaProizvodnje.Text = citac["godinaProizvodnje"].ToString();
                        prozorVino.cbVrstaVina.SelectedValue = citac["vrstaVinaID"].ToString();
                        prozorVino.cbNivoSlatkoce.SelectedValue = citac["nivoSlatkoceID"].ToString();
                        prozorVino.cbRecenzija.SelectedValue = citac["recenzijaID"].ToString();
                        prozorVino.cbDobavljac.SelectedValue = citac["dobavljacID"].ToString();
                        prozorVino.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(korisniciSelect))
                    {
                       FrmKorisnik prozorKorisnik = new FrmKorisnik(azuriraj, red);
                        prozorKorisnik.txtImeKorisnika.Text = citac["imeKorisnika"].ToString();
                        prozorKorisnik.txtPrezimeKorisnika.Text = citac["prezimeKorisnika"].ToString();
                        prozorKorisnik.txtMailKorisnika.Text = citac["mailKorisnika"].ToString();
                        prozorKorisnik.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(korisnickiNaloziSelect))
                    {
                        FrmKorisnickiNalog prozorKorisnickiNalog = new FrmKorisnickiNalog(azuriraj, red);
                        prozorKorisnickiNalog.txtImeNaloga.Text = citac["imeNaloga"].ToString();
                        prozorKorisnickiNalog.txtLozinka.Text = citac["lozinka"].ToString();
                        prozorKorisnickiNalog.cbKorisnik.SelectedValue = citac["korisnikID"].ToString();
                        prozorKorisnickiNalog.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(dobavljaciSelect))
                    {
                        FrmDobavljac prozorDobavljac = new FrmDobavljac(azuriraj, red);
                        prozorDobavljac.txtGrad.Text = citac["grad"].ToString();
                        prozorDobavljac.txtImeDobavljaca.Text = citac["imeDobavljaca"].ToString();
                        prozorDobavljac.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(recenzijeSelect))
                    {
                        FrmRecenzija prozorRecenzija = new FrmRecenzija(azuriraj, red);
                        prozorRecenzija.txtKomentar.Text = citac["komentar"].ToString();
                        prozorRecenzija.txtOcjena.Text = citac["ocjena"].ToString();
                        prozorRecenzija.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(porudzbineSelect))
                    {
                        FrmPorudzbina prozorPorudzbina = new FrmPorudzbina(azuriraj, red);
                        prozorPorudzbina.txtKolicinaProizvoda.Text = citac["kolicinaProizvoda"].ToString();
                        prozorPorudzbina.dpDatum.SelectedDate = (DateTime)citac["datum"];
                        prozorPorudzbina.txtBrojRacuna.Text = citac["brojRacuna"].ToString();
                        prozorPorudzbina.txtCijena.Text = citac["cijena"].ToString();
                        prozorPorudzbina.cbKorisnik.SelectedValue = citac["korisnikID"].ToString();
                        prozorPorudzbina.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(vinoPorudzbinaSelect))
                    {
                        FrmVinoPorudzbina prozorVinoPorudzbina = new FrmVinoPorudzbina(azuriraj, red);
                        prozorVinoPorudzbina.cbVino.SelectedValue = citac["vinoID"].ToString();
                        prozorVinoPorudzbina.cbPorudzbina.SelectedValue = citac["porudzbinaID"].ToString();
                        prozorVinoPorudzbina.ShowDialog();
                    }

                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }


        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(vrsteVinaSelect))
            {
                ObrisiZapis(vrsteVinaDelete);
                UcitajPodatke(vrsteVinaSelect);
            }
            else if (ucitanaTabela.Equals(nivoiSlatkoceSelect))
            {
                ObrisiZapis(nivoiSlatkoceDelete);
                UcitajPodatke(nivoiSlatkoceSelect);
            }
            else if (ucitanaTabela.Equals(vinoSelect))
            {
                ObrisiZapis(vinaDelete);
                UcitajPodatke(vinoSelect);
            }
            else if (ucitanaTabela.Equals(korisniciSelect))
            {
                ObrisiZapis(korisniciDelete);
                UcitajPodatke(korisniciSelect);
            }
            else if (ucitanaTabela.Equals(korisnickiNaloziSelect))
            {
                ObrisiZapis(korisnickiNaloziDelete);
                UcitajPodatke(korisnickiNaloziSelect);
            }
            else if (ucitanaTabela.Equals(dobavljaciSelect))
            {
                ObrisiZapis(dobavljaciDelete);
                UcitajPodatke(dobavljaciSelect);
            }
            else if (ucitanaTabela.Equals(recenzijeSelect))
            {
                ObrisiZapis(recenzijeDelete);
                UcitajPodatke(recenzijeSelect);
            }
            else if (ucitanaTabela.Equals(porudzbineSelect))
            {
                ObrisiZapis(porudzbineDelete);
                UcitajPodatke(porudzbineSelect);
            }
            else if (ucitanaTabela.Equals(vinoPorudzbinaSelect))
            {
                ObrisiZapis(vinoPorudzbinaDelete);
                UcitajPodatke(vinoPorudzbinaSelect);
            }
        }

        private void ObrisiZapis(string deleteUpit)
        {
            try
            {
                konekcija.Open();
                red = (DataRowView)dataGridCentralni.SelectedItems[0];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = konekcija
                    };

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = deleteUpit + "@id";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (ArgumentOutOfRangeException) //greska kada ne selektujemo red
            {
                MessageBox.Show("Niste selektovali red", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SqlException) //zbog ogranicenja stranog kljuca
            {
                MessageBox.Show("Postoje povezani podaci sa drugim tabelama!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
    }
}
