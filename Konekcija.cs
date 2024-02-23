using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinarija
{
    internal class Konekcija
    {
        public SqlConnection KreirajKonekciju()
        {
            SqlConnectionStringBuilder ccnSb = new SqlConnectionStringBuilder  /* ovdje smo odmah stavili viticaste zagrade umjesto (); kako ne bismo stavljali tacke za pocivanje*/
            {
                DataSource = @"DESKTOP-8RJU8OL\SQLEXPRESS",
                InitialCatalog = "VinarijaAndjela",
                IntegratedSecurity = true
            };

            string con = ccnSb.ToString();
            SqlConnection konekcija = new SqlConnection(con);

            return konekcija;


        }
    }
}
