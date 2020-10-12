using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WpfPersonenverwaltungTest.Helper
{
    static class ExecuteScript
    {
        public static void LoadScript()
        {
            string script = @"DELETE FROM PersonManagementTest.dbo.Person";

            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString);
            conn.Open();
            try
            {
                using (var cmd = new SqlCommand(script, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if(conn.State == ConnectionState.Closed)
                conn.Open();

            script = @"USE [PersonManagementTest]

                      INSERT [dbo].[Person] ([Name], [SecondName], [Street], [Plz], [Place], [AbteilungId]) VALUES ('Wolfsdasda', 'Kurt', 'Dorfstrasse 143', '8400', 'Winterthur', 1)
                      INSERT [dbo].[Person] ([Name], [SecondName], [Street], [Plz], [Place], [AbteilungId]) VALUES ('Sandro', 'Muster', 'Stationsstrasse 29', '8001', 'Zürich', 2)
                      INSERT [dbo].[Person] ([Name], [SecondName], [Street], [Plz], [Place], [AbteilungId]) VALUES ('Bechtle', 'Thomas', 'Bahnhofstrasse 10', '8303', 'Bassersdorf', 3)
                      INSERT [dbo].[Person] ([Name], [SecondName], [Street], [Plz], [Place], [AbteilungId]) VALUES ('Beller', 'Ahmet', 'Im Feld 32', '8424', 'Embrach', 3)";
            try
            {
                using (var cmd = new SqlCommand(script, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
