namespace Archimedes.Library.Domain
{
    public class Config
    {   
        public string UserInterfaceBaseUrl { get; set; }
        public string ApiRepositoryUrl { get; set; }
        public string RepositoryUrl { get; set; }
        public string CandleUrl { get; set; }
        public string BrokerUrl { get; set; }

        public string HealthUrl { get; set; }


        public string ApplicationName { get; set; }
        public string AppPool { get; set; }
        public string AppVersion { get; set; }

        public string DatabaseServer { get; set; }  
        public string DatabaseServerConnection { get; set; }
        public string EnvironmentName { get; set; }
        public string HangfireDatabaseName { get; set; }

        public int MaxIntervalCandles { get; set; }
        public string RabbitHutchConnection { get; set; }
        public string RabbitHost { get; set; }
        public int RabbitPort { get; set; }
        public string RabbitExchange { get; set; }

        

        public override string ToString()
        {
            var result =
                $"\n{nameof(ApplicationName)}: {ApplicationName}" +
                $"\n{nameof(AppVersion)}: {AppVersion}" +
                $"\n{nameof(EnvironmentName)}: {EnvironmentName}" +
                $"\n{nameof(DatabaseServerConnection)}: {DatabaseServerConnection}" +
                $"\n{nameof(RabbitHutchConnection)}: {RabbitHutchConnection}" +
                $"\n{nameof(HangfireDatabaseName)}: {HangfireDatabaseName}" +
                $"\n{nameof(DatabaseServer)}: {DatabaseServer}" +
                $"\n{nameof(AppPool)}:{AppPool}" +
                $"\n{nameof(ApiRepositoryUrl)}:{ApiRepositoryUrl}" +
                $"\n{nameof(MaxIntervalCandles)}: {MaxIntervalCandles}" +
                $"\n{nameof(RabbitHost)}: {RabbitHost}" +
                $"\n{nameof(RabbitPort)}: {RabbitPort}" + 
                $"\n{nameof(RabbitExchange)}: {RabbitExchange}"+
                $"\n{nameof(RepositoryUrl)}: {RepositoryUrl}"+
                $"\n{nameof(CandleUrl)}: {CandleUrl}"+
                $"\n{nameof(BrokerUrl)}: {BrokerUrl}"+
                $"\n{nameof(HealthUrl)}: {HealthUrl}"+
                $"\n{nameof(UserInterfaceBaseUrl)}: {UserInterfaceBaseUrl}";

            return result;
        }
    }
}