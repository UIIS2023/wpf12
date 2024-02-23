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
    /// Interaction logic for FrmProstorija.xaml
    /// </summary>
    public partial class FrmProstorija : Window
    {

        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();

        private bool azuriraj;
        private DataRowView red;

        public FrmProstorija()
        {
            InitializeComponent();
            txtProstorija.Focus();
            konekcija = kon.KreirajKonekciju();
        }

        public FrmProstorija(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtProstorija.Focus();
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
                cmd.Parameters.Add("@prostorija", SqlDbType.NVarChar).Value = txtProstorija.Text; // preko .Text se pristupa textu


                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tbl_Prostorija set nazivProstorije = @prostorija where prostorijaID = @id";

                    red = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tbl_Prostorija(nazivProstorije)
                                    values (@prostorija)";
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
