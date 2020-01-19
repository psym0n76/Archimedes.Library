
using System.Data.SqlClient;

namespace Archimedes.Library.Helpers
{
    public static class HangfireHelpers
    {
        public static string GetHangfireConnectionString(string dbName, string server)
        {
            using (var conn = new SqlConnection($"Server={server};Integrated Security=SSPI"))
            {
                conn.Open();

                using (var command = new SqlCommand(string.Format(
                    @"IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'{0}') 
                                    create database [{0}];
                      ", dbName), conn))
                {
                    command.ExecuteNonQuery();
                }
            }

            return $"Server={server};Database={dbName};Integrated Security=SSPI;";
        }
    }
}
