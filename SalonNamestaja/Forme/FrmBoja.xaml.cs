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
    /// Interaction logic for FrmBoja.xaml
    /// </summary>
    public partial class FrmBoja : Window
    {

        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();

        private bool azuriraj;
        private DataRowView red;  // oznacava da je u pitanju red

        public FrmBoja()
        {
            InitializeComponent();
            txtBoja.Focus();
            konekcija = kon.KreirajKonekciju();
        }

        public FrmBoja(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            txtBoja.Focus();
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
                cmd.Parameters.Add("@boja", SqlDbType.NVarChar).Value = txtBoja.Text; // preko .Text se pristupa textu

                if(txtBoja.Text == "")
                {
                    MessageBox.Show("Vrednosti nisu unete", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    
                    return;
                }

                if(azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tbl_Boja set boja = @boja where bojaID = @id";

                    red = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tbl_Boja(boja)
                                    values (@boja)";
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
