using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPersonenverwaltung.Helper
{
    static class CreateSqlConnection
    {
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString);
        }

        public static void OpenConnection(SqlConnection connection)
        {
            if (connection.State != ConnectionState.Closed)
                return;
            connection.Open();
        }
    }
}
