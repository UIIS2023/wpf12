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
    /// Interaction logic for FrmKupac.xaml
    /// </summary>
    public partial class FrmKupac : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();

        private bool azuriraj;
        private DataRowView red;

        public FrmKupac()
        {
            InitializeComponent();
            txtImeKupca.Focus();
            konekcija = kon.KreirajKonekciju();
           
        }

        public FrmKupac(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtImeKupca.Focus();
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
                cmd.Parameters.Add("@ime", SqlDbType.NVarChar).Value = txtImeKupca.Text;
                cmd.Parameters.Add("@prezime", SqlDbType.NVarChar).Value = txtPrezimeKupca.Text;
                cmd.Parameters.Add("@kontakt", SqlDbType.NVarChar).Value = txtKontaktKupca.Text;
                cmd.Parameters.Add("@grad", SqlDbType.NVarChar).Value = txtGradKupca.Text;
                cmd.Parameters.Add("@adresa", SqlDbType.NVarChar).Value = txtAdresaKupca.Text;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tbl_Kupac set imeKupca = @ime, prezimeKupca = @prezime, kontaktKupca = @kontakt, gradKupca = @grad, adresaKupca = @adresa where kupacID = @id";

                    red = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tbl_Kupac(imeKupca, prezimeKupca, kontaktKupca, gradKupca, adresaKupca)
                                    values (@ime, @prezime, @kontakt, @grad, @adresa)";
                }

                
                cmd.ExecuteNonQuery();  // ovo sluzi da bi se izvrsila insert naredba
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
