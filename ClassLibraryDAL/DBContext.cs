using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL
{
    public class DBContext 
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-I132SCO\\SQLEXPRESS01;Initial Catalog=NexusFarm Database;Integrated Security=True; TrustServerCertificate=true;");
            return con;
        }
    }
}

