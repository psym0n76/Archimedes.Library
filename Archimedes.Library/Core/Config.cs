namespace Archimedes.Library.Domain
{
    public class Config
    {
        public string ApplicationName { get; set; }
        public string AppVersion { get; set; }
        public string EnvironmentName { get; set; }
        public string DatabaseServerConnection { get; set; }
        public string RabbitHutchConnection { get; set; }
        public string HangfireDatabaseName { get; set; }
        public string DatabaseServer { get; set; }
        public string IisAppPool { get; set; }

    }
}