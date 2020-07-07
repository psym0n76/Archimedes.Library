using System.Data.SqlClient;
using Archimedes.Library.Domain;

namespace Archimedes.Library.Hangfire
{
    public static class HangfireSetup
    {
        public static string BuildHangfireConnection(this Config config)
        {
            using (var conn = new SqlConnection($"Server={config.DatabaseServer};Trusted_Connection=True;"))
            {
                conn.Open();

                using var command = new SqlCommand(string.Format(
                    @"IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'{0}') 
                                    create database [{0}];
                      ", config.HangfireDatabaseName), conn);
                command.ExecuteNonQuery();
            }

            return $"Server={config.DatabaseServer};Database={config.HangfireDatabaseName};Trusted_Connection=True;";
        }

        public static void SetInternetInformationServicesPermissions(this Config config)
        {
            using var conn = new SqlConnection($"Server={config.DatabaseServer};Trusted_Connection=True;");
            conn.Open();

            using var command = new SqlCommand(
                $@"IF NOT EXISTS (SELECT name FROM sys.server_principals WHERE name = 'IIS APPPOOL\{config.AppPool}')
                        BEGIN
                            CREATE LOGIN [IIS APPPOOL\{config.AppPool}] 
                              FROM WINDOWS WITH DEFAULT_DATABASE=[master], 
                              DEFAULT_LANGUAGE=[us_english]

                        CREATE USER [WebDatabaseUser] 
                          FOR LOGIN [IIS APPPOOL\{config.AppPool}]
                   
                        EXEC sp_addrolemember 'db_owner', 'WebDatabaseUser'
                        END;", conn);
            command.ExecuteNonQuery();
        }
    }
}