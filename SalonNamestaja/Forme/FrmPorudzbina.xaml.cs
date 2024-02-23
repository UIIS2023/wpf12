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

namespace SalonNamestaja.Forme
{
    /// <summary>
    /// Interaction logic for FrmPorudzbina.xaml
    /// </summary>
    public partial class FrmPorudzbina : Window
    {

        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();

        private bool azuriraj;
        private DataRowView red;

        public FrmPorudzbina()
        {
            InitializeComponent();
            txtAdresaIsporuke.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public FrmPorudzbina(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtAdresaIsporuke.Focus();
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

                string vratiKupca = @"select kupacID, imeKupca + ' ' + prezimeKupca as 'Ime i prezime' from tbl_Kupac";  //ime i prezime mora u memberPath u xaml
                DataTable dtKupac = new DataTable();  // kopija tabela iz baze
                SqlDataAdapter daKupac = new SqlDataAdapter(vratiKupca, konekcija);
                daKupac.Fill(dtKupac);
                cbKupac.ItemsSource = dtKupac.DefaultView;
                dtKupac.Dispose();
                dtKupac.Dispose();

                string vratiProdavca = @"select prodavacID, imeProdavca + ' ' + prezimeProdavca as 'Ime i Prezime' from tbl_Prodavac";
                DataTable dtProdavac = new DataTable();
                SqlDataAdapter daProdavac = new SqlDataAdapter(vratiProdavca, konekcija);
                daProdavac.Fill(dtProdavac);
                cbProdavac.ItemsSource = dtProdavac.DefaultView;
                dtProdavac.Dispose();
                dtProdavac.Dispose();

                string vratiNamestaj = @"select namestajID, nazivProizvoda from tbl_Namestaj";
                DataTable dtNamestaj = new DataTable();
                SqlDataAdapter daNamestaj = new SqlDataAdapter(vratiNamestaj, konekcija);
                daNamestaj.Fill(dtNamestaj);
                cbNamestaj.ItemsSource = dtNamestaj.DefaultView;
                dtNamestaj.Dispose();
                dtNamestaj.Dispose();

                string vratiDostavljaca = @"select dostavljacID, imeDostavljaca + ' ' + prezimeDostavljaca as 'dostavljacFull' from tbl_Dostavljac";
                DataTable dtDostavljac = new DataTable();
                SqlDataAdapter daDostavljac = new SqlDataAdapter(vratiDostavljaca, konekcija);
                daDostavljac.Fill(dtDostavljac);
                cbDostavljac.ItemsSource = dtDostavljac.DefaultView;
                dtDostavljac.Dispose();
                dtDostavljac.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuce liste nisu popunjene", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DateTime date = (DateTime)dpDatum.SelectedDate;            
                string datum = date.ToString("yyyy-MM-dd");

                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@adresa", SqlDbType.NVarChar).Value = txtAdresaIsporuke.Text;
                cmd.Parameters.Add("@nacin", SqlDbType.NVarChar).Value = txtNacinIsporuke.Text;
                cmd.Parameters.Add("@rok", SqlDbType.Int).Value = int.Parse(txtRokIsporuke.Text);
                cmd.Parameters.Add("@vreme", SqlDbType.NVarChar).Value = txtVreme.Text;
                cmd.Parameters.Add("@datum", SqlDbType.DateTime).Value = datum;
                
                cmd.Parameters.Add("@kupacID", SqlDbType.Int).Value = cbKupac.SelectedValue;
                cmd.Parameters.Add("@prodavacID", SqlDbType.Int).Value = cbProdavac.SelectedValue;
                cmd.Parameters.Add("@namestajID", SqlDbType.Int).Value = cbNamestaj.SelectedValue;
                cmd.Parameters.Add("@dostavljacID", SqlDbType.Int).Value = cbDostavljac.SelectedValue;


                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"UPDATE tbl_Porudzbina 
                                       SET adresaIsporuke = @adresa, 
                                           nacinIsporuke = @nacin, 
                                           vremeIsporuke = @rok,
                                           vreme = @vreme,
                                           datum = @datum,                                   
                                           kupacID = @kupacID, 
                                           prodavacID = @prodavacID, 
                                           namestajID = @namestajID, 
                                           dostavljacID = @dostavljacID
                                       WHERE porudzbinaID = @id";
                    red = null;

                }
                else
                {
                    cmd.CommandText = @"INSERT INTO tbl_Porudzbina(adresaIsporuke, nacinIsporuke, vremeIsporuke, vreme, datum, kupacID, prodavacID, namestajID, dostavljacID)
                                                VALUES(@adresa, @nacin, @rok, @vreme, @datum, @kupacID, @prodavacID, @namestajID, @dostavljacID)";
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();

            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Odaberite datum", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Greska prilikom konverzije podataka!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
