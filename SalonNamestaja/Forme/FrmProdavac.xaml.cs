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
    /// Interaction logic for FrmProdavac.xaml
    /// </summary>
    public partial class FrmProdavac : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();

        private bool azuriraj;
        private DataRowView red;

        public FrmProdavac()
        {
            InitializeComponent();
            txtImeProdavca.Focus();
            konekcija = kon.KreirajKonekciju();
        }

        public FrmProdavac(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtImeProdavca.Focus();
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
                cmd.Parameters.Add("@ime", SqlDbType.NVarChar).Value = txtImeProdavca.Text;
                cmd.Parameters.Add("@prezime", SqlDbType.NVarChar).Value = txtPrezimeProdavca.Text;
                cmd.Parameters.Add("@jmbg", SqlDbType.NVarChar).Value = txtJMBGProdavca.Text;
                cmd.Parameters.Add("@kontakt", SqlDbType.NVarChar).Value = txtKontaktProdavca.Text;// preko .Text se pristupa textu

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tbl_Prodavac set imeProdavca = @ime, prezimeProdavca = @prezime, JMBGProdavca = @jmbg, kontaktProdavca = @kontakt where prodavacID = @id";

                    red = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tbl_Prodavac(imeProdavca, prezimeProdavca, JMBGProdavca, kontaktProdavca)
                                    values (@ime, @prezime, @jmbg, @kontakt)";
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
