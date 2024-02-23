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
    /// Interaction logic for FrmProizvodjac.xaml
    /// </summary>
    public partial class FrmProizvodjac : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();

        private bool azuriraj;
        private DataRowView red;

        public FrmProizvodjac()
        {
            InitializeComponent();
            txtNazivProizvodjaca.Focus();
            konekcija = kon.KreirajKonekciju();
        }

        public FrmProizvodjac(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtNazivProizvodjaca.Focus();
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
                cmd.Parameters.Add("@proizvodjac", SqlDbType.NVarChar).Value = txtNazivProizvodjaca.Text; // preko .Text se pristupa textu
                cmd.Parameters.Add("@lokacija", SqlDbType.NVarChar).Value = txtLokacijaProizvodjaca.Text; // preko .Text se pristupa textu
                cmd.Parameters.Add("@kontakt", SqlDbType.NVarChar).Value = txtKontaktProizvodjaca.Text; // preko .Text se pristupa textu

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tbl_Proizvodjac set nazivProizvodjaca = @proizvodjac, lokacijaProizvodjaca = @lokacija, kontaktProizvodjaca = @kontakt where proizvodjacID = @id";

                    red = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tbl_Proizvodjac (nazivProizvodjaca, lokacijaProizvodjaca, kontaktProizvodjaca)
                                         values (@proizvodjac, @lokacija, @kontakt)";
                }

                cmd.ExecuteNonQuery();  // ovo sluzi da bi se izvrsila insert naredba, catch se vata posle ove komande
                cmd.Dispose(); // oslobadja resurse
                this.Close(); // da se zatvori forma
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


