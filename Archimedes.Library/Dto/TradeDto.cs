using System;
using Newtonsoft.Json;

namespace Archimedes.Library.Message.Dto
{
    public class TradeDto
    {
        [JsonProperty(PropertyName = "market")]
        public string Market { get; set; }

        [JsonProperty(PropertyName = "direction")]
        public string Direction { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; set; }

        public override string ToString()
        {
            return $"\n {nameof(TradeDto)}" +
                   $"\n  {nameof(Market)}:{Market} {nameof(Direction)}:{Direction} {nameof(Timestamp)}:{Timestamp}\n";
        }
    }
}