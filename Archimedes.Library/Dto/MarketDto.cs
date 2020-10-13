using System;
using Newtonsoft.Json;

namespace Archimedes.Library.Message.Dto
{
    public class MarketDto
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "interval")]
        public int Interval { get; set; }

        [JsonProperty(PropertyName = "timeframe")]
        public string TimeFrame { get; set; }

        [JsonProperty(PropertyName = "granularity")]
        public string Granularity { get; set; }

        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }

        [JsonProperty(PropertyName = "maxDate")]
        public DateTime MaxDate { get; set; }

        [JsonProperty(PropertyName = "minDate")]
        public DateTime MinDate { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "lastUpdated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty(PropertyName = "timeStamp")]
        public DateTime TimeStamp { get; set; }

        [JsonProperty(PropertyName = "timeFrameInterval")]
        public string TimeFrameInterval => $"{Interval}{TimeFrame}";

        [JsonProperty(PropertyName = "brokerTimeMinInterval")]
        public string BrokerTimeMinInterval => $"{TimeFrame.Substring(0, 1).ToLower()}{Interval}";

        [JsonProperty(PropertyName = "brokerTimeInterval")]
        public string BrokerTimeInterval => $"{TimeFrame.Substring(0, 1).ToUpper()}{Interval}";

        public override string ToString()
        {
            return $"\n\n {nameof(MarketDto)}" +
                   $"\n  {nameof(Name)}: {Name} {nameof(TimeFrameInterval)}: {TimeFrameInterval} {nameof(Active)}: {Active} " +
                   $"\n  {nameof(BrokerTimeMinInterval)}: {BrokerTimeMinInterval} {nameof(BrokerTimeInterval)}: {BrokerTimeInterval} {nameof(Active)}: {Active} " +
                   $"\n  {nameof(MinDate)}: {MinDate} {nameof(MaxDate)}: {MaxDate} {nameof(Granularity)}: {Granularity} {nameof(LastUpdated)}: {LastUpdated}\n";
        }
    }
}