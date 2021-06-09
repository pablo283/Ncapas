using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DL
{
    public class Conexion
    {
        public static string GetConnectionString()
        {
            string  connectionString =ConfigurationManager.ConnectionStrings["PGonzalezNCapa"].ConnectionString;

            return connectionString;
        }

        public static System.Data.SqlClient.SqlCommand CreateCommand(string Query, System.Data.SqlClient.SqlConnection context)
        {
            throw new NotImplementedException();
        }

        public static int ExecuteCommand(System.Data.SqlClient.SqlCommand cmd)
        {
            throw new NotImplementedException();
        }
    }                                                               
}
