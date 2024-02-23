using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonNamestaja
{
    internal class Konekcija  //bilo public
    {
       
        public SqlConnection KreirajKonekciju()
        {
            
            SqlConnectionStringBuilder ccnSb = new SqlConnectionStringBuilder
            {
                DataSource = @"DESKTOP-770PHGA\SQLEXPRESS", 
                InitialCatalog = "SalonNamestaja", 
                IntegratedSecurity = true 
            };
            string con = ccnSb.ToString();
            SqlConnection konekcija = new SqlConnection(con);
            return konekcija;
        }
    }
}
