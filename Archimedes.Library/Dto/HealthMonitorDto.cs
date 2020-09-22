using System;

namespace Archimedes.Library.Message.Dto
{
    public class HealthMonitorDto
    {
        public string Url  { get; set; }
        public string Version { get; set; }
        public bool Status { get; set; }
        public DateTime LastActive { get; set; }
        public DateTime LastActiveVersion { get; set; }

        public override string ToString()
        {
            return $"{nameof(Url)}: {Url}" +
                   $"\n{nameof(Version)}: {Version}" +
                   $"\n{nameof(LastActiveVersion)}: {LastActiveVersion} : {nameof(LastActive)}: {LastActive}" +
                   $"\n{nameof(Status)}: {Status}";
        }
    }
}