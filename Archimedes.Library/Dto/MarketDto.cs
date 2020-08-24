using System;
using Newtonsoft.Json;

namespace Archimedes.Library.Message.Dto
{
    public class MarketDto
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "interval")]
        public int Interval { get; set; }

        [JsonProperty(PropertyName = "timeframe")]
        public string TimeFrame { get; set; }

        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }

        [JsonProperty(PropertyName = "maxDate")]
        public DateTime MaxDate { get; set; }

        [JsonProperty(PropertyName = "lastUpdated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty(PropertyName = "timeFrameInterval")]
        public string TimeFrameInterval => $"{Interval}{TimeFrame}";

        [JsonProperty(PropertyName = "brokerTimeMinInterval")]
        public string BrokerTimeMinInterval => $"{Interval}{TimeFrame.Substring(1, 1).ToLower()}";

        [JsonProperty(PropertyName = "brokerTimeInterval")]
        public string BrokerTimeInterval => $"{Interval}{TimeFrame.Substring(1, 1).ToUpper()}";

        public override string ToString()
        {
            return $"\n {nameof(MarketDto)}" +
                   $"\n  {nameof(Name)}: {Name} {nameof(TimeFrameInterval)}: {TimeFrameInterval} {nameof(Active)}: {Active} " +
                   $"\n  {nameof(BrokerTimeMinInterval)}: {BrokerTimeMinInterval} {nameof(BrokerTimeInterval)}: {BrokerTimeInterval} {nameof(Active)}: {Active} " +
                   $"\n  {nameof(MaxDate)}: {MaxDate} {nameof(LastUpdated)}: {LastUpdated}";
        }
    }
}