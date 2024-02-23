using SalonNamestaja.Forme;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace SalonNamestaja
{

    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string ucitanaTabela;

        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();

        //novo
        private bool azuriraj;
        private DataRowView red;


        #region
        private static string namestajSelect = @"Select namestajID as ID, nazivProizvoda, cena, dostupnost, materijal, nazivProizvodjaca as Proizvodjac, nazivProstorije as Prostorija, boja
                                                From tbl_Namestaj join tbl_Materijal on tbl_Namestaj.materijalID = tbl_Materijal.materijalID
				                                                  join tbl_Proizvodjac on tbl_Namestaj.proizvodjacID = tbl_Proizvodjac.proizvodjacID
				                                                  join tbl_Prostorija on tbl_Namestaj.prostorijaID = tbl_Prostorija.prostorijaID
				                                                  join tbl_Boja on tbl_Namestaj.bojaID = tbl_Boja.bojaID";
        private static string materijalSelect = @"select materijalID as ID, materijal from tbl_Materijal";
        private static string bojaSelect = @"select bojaID as ID, boja from tbl_Boja";
        private static string prostorijaSelect = @"select prostorijaID as ID, nazivProstorije from tbl_Prostorija";
        private static string proizvodjacSelect = @"Select proizvodjacID as ID, nazivProizvodjaca as Proizvodjac, lokacijaProizvodjaca as 'Lokacija Proizvodjaca', kontaktProizvodjaca as Kontakt from tbl_Proizvodjac";
        private static string dostavljacSelect = @"Select dostavljacID as ID, imeDostavljaca as 'Ime Dostavljaca', prezimeDostavljaca as 'Prezime Dostavljaca' From tbl_Dostavljac";
        private static string kupacSelect = @"select kupacID as ID, imeKupca as Ime, prezimeKupca as Prezime, kontaktKupca as Kontakt, gradKupca as 'Grad kupca', adresaKupca as 'Adresa kupca' from tbl_Kupac";
        private static string prodavacSelect = @"Select prodavacID as ID, imeProdavca as 'Ime prodavca', prezimeProdavca as 'Prezime prodavca', JMBGProdavca as 'JMBG', kontaktProdavca as Kontakt from tbl_Prodavac";
        private static string porudzbinaSelect = @"Select porudzbinaID as ID, adresaIsporuke as 'Adresa za isporuku', nacinIsporuke as 'Nacin isporuke', vremeIsporuke as 'Rok isporuke', vreme, datum, imeKupca + ' ' + prezimeKupca as 'Ime i Prezime Kupca', imeProdavca + ' ' + prezimeProdavca as 'Ime i prezime Prodavca', nazivProizvoda as 'Proizvod', imeDostavljaca + ' ' + prezimeDostavljaca as 'Dostavljac' 
                                                  from tbl_Porudzbina join tbl_Kupac on tbl_Porudzbina.kupacID = tbl_Kupac.kupacID
                                                                      join tbl_Prodavac on tbl_Porudzbina.prodavacID = tbl_Prodavac.prodavacID
                                                                      join tbl_Namestaj on tbl_Porudzbina.namestajID = tbl_Namestaj.namestajID
                                                                      join tbl_Dostavljac on tbl_Porudzbina.dostavljacID = tbl_Dostavljac.dostavljacID";
        
       
        #endregion

        #region select naredbe
        private static string selectUslovNamestaj = @"select * from tbl_Namestaj where namestajID=";
        private static string selectUslovMaterijal = @"select * from tbl_Materijal where materijalID=";
        private static string selectUslovBoja = @"select * from tbl_Boja where bojaID=";
        private static string selectUslovProstorija = @"select * from tbl_Prostorija where prostorijaID=";
        private static string selectUslovProizvodjac = @"select * from tbl_Proizvodjac where proizvodjacID=";
        private static string selectUslovPorudzbina = @"select * from tbl_Porudzbina where porudzbinaID=";
        private static string selectUslovDostavljac = @"select * from tbl_Dostavljac where dostavljacID=";
        private static string selectUslovKupac = @"select * from tbl_Kupac where kupacID=";
        private static string selectUslovProdavac = @"select * from tbl_Prodavac where prodavacID=";
        #endregion

        #region delete naredbe
        private static string namestajDelete = @"delete from tbl_Namestaj where namestajID=";
        private static string materijalDelete = @"delete from tbl_Materijal where materijalID=";
        private static string bojaDelete = @"delete from tbl_Boja where bojaID=";
        private static string proizvodjacDelete = @"delete from tbl_Proizvodjac where proizvodjacID=";
        private static string porudzbinaDelete = @"delete from tbl_Porudzbina where porudzbinaID=";
        private static string dostavljacDelete = @"delete from tbl_Dostavljac where dostavljacID=";
        private static string kupacDelete = @"delete from tbl_Kupac where kupacID=";
        private static string prodavacDelete = @"delete from tbl_Prodavac where prodavacID=";
        private static string prostorijaDelete = @"delete from tbl_Prostorija where prostorijaID=";
        #endregion

        

        public MainWindow()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            UcitajPodatke(namestajSelect);

        }

        private void ApplyDateFormating(DataGrid grid, string columnDate)
        {
            var datumColumn = grid.Columns.FirstOrDefault(column => (string)column.Header == columnDate);

            if(datumColumn != null)
            {
                if(datumColumn is DataGridTextColumn textColumn)
                {
                    textColumn.Binding.StringFormat = "yyyy-MM-dd";
                }
            }
        }

        
        public void UcitajPodatke(String selectUpit)
        {
            try
            {
                konekcija.Open();
                
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if(dataGridCentralni != null)
                {
                    dataGridCentralni.ItemsSource = dataTable.DefaultView;

                    // za formatiranje datuma
                    ApplyDateFormating(dataGridCentralni, "datum");
                    
                }

                ucitanaTabela = selectUpit;
                dataAdapter.Dispose();
                dataTable.Dispose();
            }
            catch(SqlException)
            {
                MessageBox.Show("Neuspesno ucitani podaci", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if(konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }




        //-----------------------------KLIK NA DUGME--------------------------

        private void btnNamestaj_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(namestajSelect);
        }

        private void btnProizvodjac_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(proizvodjacSelect);
        }

        private void btnProstorija_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(prostorijaSelect);
        }

        private void btnBoja_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(bojaSelect);
        }

        private void btnMaterijal_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(materijalSelect);
        }

        private void btnPorudzbina_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(porudzbinaSelect);
        }

        private void btnDostavljac_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dostavljacSelect);
        }

        private void btnKupac_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(kupacSelect);
        }

        private void btnProdavac_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(prodavacSelect);
        }






        //----------------------DODAJ KOMANDA----------------------------

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window prozor;

            if (ucitanaTabela.Equals(namestajSelect))
            {
                prozor = new FrmNamestaj();
                prozor.ShowDialog();
                UcitajPodatke(namestajSelect);
            }
            else if (ucitanaTabela.Equals(bojaSelect))
            {
                prozor = new FrmBoja();
                prozor.ShowDialog();
                UcitajPodatke(bojaSelect);
            }
            else if (ucitanaTabela.Equals(dostavljacSelect))
            {
                prozor = new FrmDostavljac();
                prozor.ShowDialog();
                UcitajPodatke(dostavljacSelect);
            }
            else if (ucitanaTabela.Equals(materijalSelect))
            {
                prozor = new FrmMaterijal();
                prozor.ShowDialog();
                UcitajPodatke(materijalSelect);
            }
            else if (ucitanaTabela.Equals(kupacSelect))
            {
                prozor = new FrmKupac();
                prozor.ShowDialog();
                UcitajPodatke(kupacSelect);
            }
            else if (ucitanaTabela.Equals(prodavacSelect))
            {
                prozor = new FrmProdavac();
                prozor.ShowDialog();
                UcitajPodatke(prodavacSelect);
            }
            else if (ucitanaTabela.Equals(proizvodjacSelect))
            {
                prozor = new FrmProizvodjac();
                prozor.ShowDialog();
                UcitajPodatke(proizvodjacSelect);
            }
            else if (ucitanaTabela.Equals(prostorijaSelect))
            {
                prozor = new FrmProstorija();
                prozor.ShowDialog();
                UcitajPodatke(prostorijaSelect);
            }
            else if (ucitanaTabela.Equals(porudzbinaSelect))
            {
                prozor = new FrmPorudzbina();
                prozor.ShowDialog();
                UcitajPodatke(porudzbinaSelect);
            }
        }





       


        // -------------------------IZMENI-----------------------------

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(namestajSelect))
            {
                PopuniFormu(selectUslovNamestaj);
                UcitajPodatke(namestajSelect);  // ovo treba da bi se rifresofale tabele
            }
            else if (ucitanaTabela.Equals(porudzbinaSelect))
            {
                PopuniFormu(selectUslovPorudzbina);
                UcitajPodatke(porudzbinaSelect);
            }
            else if (ucitanaTabela.Equals(bojaSelect))
            {
                PopuniFormu(selectUslovBoja);
                UcitajPodatke(bojaSelect);
            }
            else if(ucitanaTabela.Equals(materijalSelect))
            {
                PopuniFormu(selectUslovMaterijal);
                UcitajPodatke(materijalSelect);
            }
            else if (ucitanaTabela.Equals(prostorijaSelect))
            {
                PopuniFormu(selectUslovProstorija);
                UcitajPodatke(prostorijaSelect);
            }
            else if (ucitanaTabela.Equals(proizvodjacSelect))
            {
                PopuniFormu(selectUslovProizvodjac);
                UcitajPodatke(proizvodjacSelect);
            }
            else if (ucitanaTabela.Equals(kupacSelect))
            {
                PopuniFormu(selectUslovKupac);
                UcitajPodatke(kupacSelect);
            }
            else if (ucitanaTabela.Equals(dostavljacSelect))
            {
                PopuniFormu(selectUslovDostavljac);
                UcitajPodatke(dostavljacSelect);
            }
            else if (ucitanaTabela.Equals(prodavacSelect))
            {
                PopuniFormu(selectUslovProdavac);
                UcitajPodatke(prodavacSelect);
            }

        }

        private void PopuniFormu(string selectUslov)
        {
            try
            {
                konekcija.Open();
                azuriraj = true;
                red = (DataRowView)dataGridCentralni.SelectedItems[0];
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"]; 
                cmd.CommandText = selectUslov + "@id";
                SqlDataReader citac = cmd.ExecuteReader();  // cita naredbe

                if(citac.Read()) // ako ima sta da cita       
                {
                    if(ucitanaTabela.Equals(namestajSelect))
                    {
                        FrmNamestaj prozorNamestaj = new FrmNamestaj(azuriraj, red); // crveni jer nemam konstruktor
                        

                        prozorNamestaj.txtNazivProizvoda.Text = citac["nazivProizvoda"].ToString();
                        prozorNamestaj.txtCena.Text = citac["cena"].ToString();  // ide to string jer je text box
                        prozorNamestaj.cbxDostupnost.IsChecked = (bool)citac["dostupnost"];

                        prozorNamestaj.cbBoja.SelectedValue = citac["bojaID"].ToString();
                        prozorNamestaj.cbMaterijal.SelectedValue = citac["materijalID"].ToString();
                        prozorNamestaj.cbProizvodjac.SelectedValue = citac["proizvodjacID"].ToString();
                        prozorNamestaj.cbProstorija.SelectedValue = citac["prostorijaID"].ToString();

                        prozorNamestaj.ShowDialog();
                    }
                    else if(ucitanaTabela.Equals(porudzbinaSelect))
                    {
                        FrmPorudzbina prozorPorudzbina = new FrmPorudzbina(azuriraj, red); 


                        prozorPorudzbina.txtAdresaIsporuke.Text = citac["adresaISporuke"].ToString();
                        prozorPorudzbina.txtNacinIsporuke.Text = citac["nacinIsporuke"].ToString();  // ide to string jer je text box
                        prozorPorudzbina.txtRokIsporuke.Text = citac["vremeIsporuke"].ToString();
                        prozorPorudzbina.txtVreme.Text = citac["vreme"].ToString();

                        prozorPorudzbina.dpDatum.SelectedDate = (DateTime)citac["datum"];

                        prozorPorudzbina.cbKupac.SelectedValue = citac["kupacID"].ToString();
                        prozorPorudzbina.cbProdavac.SelectedValue = citac["prodavacID"].ToString();
                        prozorPorudzbina.cbNamestaj.SelectedValue = citac["namestajID"].ToString();
                        prozorPorudzbina.cbDostavljac.SelectedValue = citac["dostavljacID"].ToString();


                        prozorPorudzbina.ShowDialog();
                    }
                    else if(ucitanaTabela.Equals(bojaSelect))
                    {
                        FrmBoja prozorBoja = new FrmBoja(azuriraj, red);

                        prozorBoja.txtBoja.Text = citac["boja"].ToString();  

                        prozorBoja.ShowDialog();   
                    }
                    else if (ucitanaTabela.Equals(materijalSelect))
                    {
                        FrmMaterijal prozorMaterijal = new FrmMaterijal(azuriraj, red);
                        prozorMaterijal.txtMaterijal.Text = citac["materijal"].ToString();
                        prozorMaterijal.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(prostorijaSelect))
                    {
                        FrmProstorija prozorProstorija = new FrmProstorija(azuriraj, red);
                        prozorProstorija.txtProstorija.Text = citac["nazivProstorije"].ToString();
                        prozorProstorija.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(proizvodjacSelect))
                    {
                        FrmProizvodjac prozorProizvodjac = new FrmProizvodjac(azuriraj, red);

                        prozorProizvodjac.txtNazivProizvodjaca.Text = citac["nazivProizvodjaca"].ToString();
                        prozorProizvodjac.txtKontaktProizvodjaca.Text = citac["kontaktProizvodjaca"].ToString();  // ide to string jer je text box
                        prozorProizvodjac.txtLokacijaProizvodjaca.Text = citac["lokacijaProizvodjaca"].ToString();
  
                        prozorProizvodjac.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(kupacSelect))
                    {
                        FrmKupac prozorKupac = new FrmKupac(azuriraj, red);

                        prozorKupac.txtImeKupca.Text = citac["imeKupca"].ToString();
                        prozorKupac.txtPrezimeKupca.Text = citac["prezimeKupca"].ToString();  // ide to string jer je text box
                        prozorKupac.txtKontaktKupca.Text = citac["kontaktKupca"].ToString();
                        prozorKupac.txtGradKupca.Text = citac["gradKupca"].ToString();
                        prozorKupac.txtAdresaKupca.Text = citac["adresaKupca"].ToString();

                        prozorKupac.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(prodavacSelect))
                    {
                        FrmProdavac prozorProdavac = new FrmProdavac(azuriraj, red);

                        prozorProdavac.txtImeProdavca.Text = citac["imeProdavca"].ToString();
                        prozorProdavac.txtPrezimeProdavca.Text = citac["prezimeProdavca"].ToString();  // ide to string jer je text box
                        prozorProdavac.txtJMBGProdavca.Text = citac["JMBGProdavca"].ToString();
                        prozorProdavac.txtKontaktProdavca.Text = citac["kontaktProdavca"].ToString();

                        prozorProdavac.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(dostavljacSelect))
                    {
                        FrmDostavljac prozorDostavljac = new FrmDostavljac(azuriraj, red);

                        prozorDostavljac.txtImeDostavljaca.Text = citac["imeDostavljaca"].ToString();
                        prozorDostavljac.txtPrezimeDostavljaca.Text = citac["prezimeDostavljaca"].ToString();  // ide to string jer je text box

                        prozorDostavljac.ShowDialog();
                    }


                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if(konekcija != null)
                {
                    konekcija.Close();
                }
            }
            
        }

        //+++++++++++++++++++++++++++++++++++++ DELETE +++++++++++++++++++++++++++++++++++++++++++++++

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(namestajSelect))
            {
                ObrisiZapis(namestajDelete);
                UcitajPodatke(namestajSelect);  // ovo treba da bi se rifresofale tabele
            }
            else if (ucitanaTabela.Equals(bojaSelect))
            {
                ObrisiZapis(bojaDelete);
                UcitajPodatke(bojaSelect);
            }
            else if (ucitanaTabela.Equals(materijalSelect))
            {
                ObrisiZapis(materijalDelete);
                UcitajPodatke(materijalSelect);
            }
            else if (ucitanaTabela.Equals(prostorijaSelect))
            {
                ObrisiZapis(prostorijaDelete);
                UcitajPodatke(prostorijaSelect);
            }
            else if (ucitanaTabela.Equals(proizvodjacSelect))
            {
                ObrisiZapis(proizvodjacDelete);
                UcitajPodatke(proizvodjacSelect);
            }
            else if (ucitanaTabela.Equals(kupacSelect))
            {
                ObrisiZapis(kupacDelete);
                UcitajPodatke(kupacSelect);
            }
            else if (ucitanaTabela.Equals(dostavljacSelect))
            {
                ObrisiZapis(dostavljacDelete);
                UcitajPodatke(dostavljacSelect);
            }
            else if (ucitanaTabela.Equals(prodavacSelect))
            {
                ObrisiZapis(prodavacDelete);
                UcitajPodatke(prodavacSelect);
            }
            else if (ucitanaTabela.Equals(porudzbinaSelect))
            {
                ObrisiZapis(porudzbinaDelete);
                UcitajPodatke(porudzbinaSelect);
            }
        }

        private void ObrisiZapis(string deleteUpit)
        {
            try
            {
                konekcija.Open();
                red = (DataRowView) dataGridCentralni.SelectedItems[0];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(rezultat == MessageBoxResult.Yes)
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
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if(konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }











        



    }
}
