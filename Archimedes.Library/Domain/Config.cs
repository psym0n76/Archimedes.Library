namespace Archimedes.Library.Domain
{
    public class Config
    {

        public string ApiRepositoryUrl { get; set; }
        public string ApplicationName { get; set; }
        public string AppPool { get; set; }
        public string AppVersion { get; set; }

        public string DatabaseServer { get; set; }  
        public string DatabaseServerConnection { get; set; }
        public string EnvironmentName { get; set; }
        public string HangfireDatabaseName { get; set; }

        public int MaxIntervalCandles { get; set; }
        public string RabbitHutchConnection { get; set; }



        public override string ToString()
        {
            var result =
                $"{nameof(ApplicationName)}: {ApplicationName} {nameof(AppVersion)}: {AppVersion} " +
                $"{nameof(EnvironmentName)}: {EnvironmentName} {nameof(DatabaseServerConnection)}: {DatabaseServerConnection} " +
                $"{nameof(RabbitHutchConnection)}: {RabbitHutchConnection} {nameof(HangfireDatabaseName)}: {HangfireDatabaseName} " +
                $"{nameof(DatabaseServer)}: {DatabaseServer} {nameof(AppPool)}:{AppPool} " +
                $"{nameof(ApiRepositoryUrl)}:{ApiRepositoryUrl} {nameof(MaxIntervalCandles)}: {MaxIntervalCandles}";

            return result;
        }
    }
}