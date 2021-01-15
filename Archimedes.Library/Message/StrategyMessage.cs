using System;

namespace Archimedes.Library.Message
{
    public class StrategyMessage
    {
        public string Id { get; set; }
        public string Market { get; set; }
        public string Granularity { get; set; }
        public int Interval { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}