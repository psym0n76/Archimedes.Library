using System;
using Newtonsoft.Json;

namespace Archimedes.Library.Message.Dto
{
    public class StrategyDto
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "market")]
        public string Market { get; set; }

        [JsonProperty(PropertyName = "granularity")]
        public string Granularity { get; set; }

        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }

        [JsonProperty(PropertyName = "startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty(PropertyName = "endDate")]
        public DateTime EndDate { get; set; }

        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }

        [JsonProperty(PropertyName = "lastUpdated")]
        public DateTime LastUpdated { get; set; }

        
        public override string ToString()
        {
            return $"\n\n {nameof(StrategyDto)}" +
                   $"\n  {nameof(Id)}: {Id} {nameof(Name)}: {Name} {nameof(Market)}: {Market} {nameof(Granularity)}: {Granularity} " +
                   $"\n  {nameof(Active)}: {Active} {nameof(StartDate)}: {StartDate} {nameof(EndDate)}: {EndDate} {nameof(Count)}: {Count} {nameof(LastUpdated)}: {LastUpdated}\n";
        }
    }
}