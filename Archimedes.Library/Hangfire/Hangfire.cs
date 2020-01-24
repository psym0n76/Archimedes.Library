using System.Data.SqlClient;

namespace Archimedes.Library.Extensions
{
    public static class Hangfire
    {
        public static string BuildTestHangfireConnection(this string result, string dbName, string server)
        {
            using (var conn = new SqlConnection($"Server={server};Trusted_Connection=True;"))
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

            return $"Server={server};Database={dbName};Trusted_Connection=True;;";
        }

        public static void SetInternetInformationServicesPermissions(this string server,string appPooolName)
        {
            using (var conn = new SqlConnection($"Server={server};Trusted_Connection=True;"))
            {
                conn.Open();

                using (var command = new SqlCommand($@"IF NOT EXISTS (SELECT name FROM sys.server_principals WHERE name = 'IIS APPPOOL\{appPooolName}')
                        BEGIN
                            CREATE LOGIN [IIS APPPOOL\{appPooolName}] 
                              FROM WINDOWS WITH DEFAULT_DATABASE=[master], 
                              DEFAULT_LANGUAGE=[us_english]
                        END
                       
                        CREATE USER [WebDatabaseUser] 
                          FOR LOGIN [IIS APPPOOL\{appPooolName}]
                   
                        EXEC sp_addrolemember 'db_owner', 'WebDatabaseUser'
                        ;
                      ", conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}