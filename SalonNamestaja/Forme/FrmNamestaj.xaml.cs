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

namespace SalonNamestaja.Forme
{
    /// <summary>
    /// Interaction logic for FrmNamestaj.xaml
    /// </summary>
    public partial class FrmNamestaj : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();

        private bool azuriraj;
        private DataRowView red;

        public FrmNamestaj()
        {
            InitializeComponent();
            txtNazivProizvoda.Focus();  
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();  // mora posle konekcije
        }

        public FrmNamestaj(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtNazivProizvoda.Focus();
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
                
                string vratiProstorija = @"select prostorijaID, nazivProstorije from tbl_Prostorija";
                DataTable dtProstorija = new DataTable();
                SqlDataAdapter daProstorija = new SqlDataAdapter(vratiProstorija, konekcija);
                daProstorija.Fill(dtProstorija);
                cbProstorija.ItemsSource = dtProstorija.DefaultView;
                //cbProstorija.DisplayMemberPath = "nazivProstorije"; // ??????????
                dtProstorija.Dispose();
                dtProstorija.Dispose();

                string vratiBoja = @"select bojaID, boja from tbl_Boja";
                DataTable dtBoja = new DataTable();
                SqlDataAdapter daBoja = new SqlDataAdapter(vratiBoja, konekcija);
                daBoja.Fill(dtBoja);
                cbBoja.ItemsSource = dtBoja.DefaultView;
                //cbBoja.DisplayMemberPath = "boja"; // ??????????
                dtBoja.Dispose();
                dtBoja.Dispose();

                string vratiMaterijal = @"select materijalID, materijal from tbl_Materijal";
                DataTable dtMaterijal = new DataTable();
                SqlDataAdapter daMaterijal = new SqlDataAdapter(vratiMaterijal, konekcija);
                daMaterijal.Fill(dtMaterijal);
                cbMaterijal.ItemsSource = dtMaterijal.DefaultView;
                //cbMaterijal.DisplayMemberPath = "materijal"; // ??????????
                dtMaterijal.Dispose();
                dtMaterijal.Dispose();

                
                string vratiProizvodjac = @"select proizvodjacID, nazivProizvodjaca from tbl_Proizvodjac";
                DataTable dtProizvodjac = new DataTable();
                SqlDataAdapter daProizvodjac = new SqlDataAdapter(vratiProizvodjac, konekcija);
                daProizvodjac.Fill(dtProizvodjac);
                cbProizvodjac.ItemsSource = dtProizvodjac.DefaultView;
                //cbProizvodjac.DisplayMemberPath = "nazivProizvodjaca"; // ??????????
                dtProizvodjac.Dispose();
                dtProizvodjac.Dispose();
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
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@nazivProizvoda", SqlDbType.NVarChar).Value = txtNazivProizvoda.Text;
                cmd.Parameters.Add("@dostupnost", SqlDbType.Bit).Value = Convert.ToInt32(cbxDostupnost.IsChecked); //menjo
                cmd.Parameters.Add("@cena", SqlDbType.Float).Value = float.Parse(txtCena.Text);

                cmd.Parameters.Add("@prostorijaID", SqlDbType.Int).Value = cbProstorija.SelectedValue;
                cmd.Parameters.Add("@proizvodjacID", SqlDbType.Int).Value = cbProizvodjac.SelectedValue;
                cmd.Parameters.Add("@bojaID", SqlDbType.Int).Value = cbBoja.SelectedValue;
                cmd.Parameters.Add("@materijalID", SqlDbType.Int).Value = cbMaterijal.SelectedValue;



                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"UPDATE tbl_Namestaj 
                                SET nazivProizvoda = @nazivProizvoda, 
                                    dostupnost = @dostupnost, 
                                    cena = @cena, 
                                    prostorijaID = @prostorijaID, 
                                    proizvodjacID = @proizvodjacID, 
                                    materijalID = @materijalID, 
                                    bojaID = @bojaID
                                WHERE namestajID = @id";
                    red = null;

                }
                else
                {                 
                    cmd.CommandText = "INSERT INTO tbl_Namestaj (nazivProizvoda, dostupnost, cena, prostorijaID, proizvodjacID, bojaID, materijalID) VALUES (@nazivProizvoda, @dostupnost, @cena, @prostorijaID, @proizvodjacID, @bojaID, @materijalID)";
                }

                //SelectedValuePath da bi moglo da pokupi vrednost kljuca
                cmd.ExecuteNonQuery(); 
                cmd.Dispose(); 
                this.Close(); 

            }
            catch(SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (FormatException)  //zbog convertovanja
            {
                MessageBox.Show("Greska prilikom konverzije podataka!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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
