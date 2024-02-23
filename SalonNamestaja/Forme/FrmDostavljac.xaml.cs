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
    /// Interaction logic for FrmDostavljac.xaml
    /// </summary>
    public partial class FrmDostavljac : Window
    {

        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();

        private bool azuriraj;
        private DataRowView red;

        public FrmDostavljac()
        {
            InitializeComponent();
            txtImeDostavljaca.Focus();
            konekcija = kon.KreirajKonekciju();
        }

        public FrmDostavljac(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtImeDostavljaca.Focus();
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
                cmd.Parameters.Add("@ime", SqlDbType.NVarChar).Value = txtImeDostavljaca.Text;
                cmd.Parameters.Add("@prezime", SqlDbType.NVarChar).Value = txtPrezimeDostavljaca.Text;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tbl_Dostavljac set imeDostavljaca = @ime, prezimeDostavljaca = @prezime where dostavljacID = @id";

                    red = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tbl_Dostavljac(imeDostavljaca, prezimeDostavljaca)
                                    values (@ime, @prezime)";
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
