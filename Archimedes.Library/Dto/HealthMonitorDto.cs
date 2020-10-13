using System;
using Newtonsoft.Json;

namespace Archimedes.Library.Message.Dto
{
    public class HealthMonitorDto
    {
        [JsonProperty(PropertyName = "url")]
        public string Url  { get; set; }

        [JsonProperty(PropertyName = "appName")]
        public string AppName { get; set; }

        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

        [JsonProperty(PropertyName = "status")]
        public bool Status { get; set; }

        [JsonProperty(PropertyName = "statusMessage")]
        public string StatusMessage { get; set; }

        [JsonProperty(PropertyName = "lastActive")]
        public DateTime LastActive { get; set; }

        [JsonProperty(PropertyName = "lastActiveVersion")]
        public string LastActiveVersion { get; set; }

        [JsonProperty(PropertyName = "lastUpdated")]
        public DateTime LastUpdated { get; set; }

        public override string ToString()
        {
            return $"\n\n{nameof(AppName)}: {AppName}" +
                   $"{nameof(Url)}: {Url}" +
                   $"\n{nameof(Version)}: {Version}" +
                   $"\n{nameof(LastActiveVersion)}: {LastActiveVersion} : {nameof(LastActive)}: {LastActive}" +
                   $"\n{nameof(Status)}: {Status} : {nameof(StatusMessage)}: {StatusMessage}\n";
        }
    }
}