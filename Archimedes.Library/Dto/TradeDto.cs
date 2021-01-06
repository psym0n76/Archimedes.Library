using System;
using Newtonsoft.Json;

namespace Archimedes.Library.Message.Dto
{
    public class TradeDto
    {

        [JsonProperty(PropertyName = "buySell")]
        public string BuySell { get; set; }

        [JsonProperty(PropertyName = "market")]
        public string Market { get; set; }

        [JsonProperty(PropertyName = "strategy")]
        public string Strategy { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        [JsonProperty(PropertyName = "priceLevelTimestamp")]
        public DateTime PriceLevelTimestamp { get; set; }


        [JsonProperty(PropertyName = "entryPrice")]
        public decimal EntryPrice { get; set; }

        [JsonProperty(PropertyName = "closePrice")]
        public decimal ClosePrice { get; set; }

        [JsonProperty(PropertyName = "targetPrice")]
        public decimal TargetPrice { get; set; }


        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; set; }

        public override string ToString()
        {
            return $"\n {nameof(TradeDto)}" +
                   $"\n  {nameof(Market)}:{Market} {nameof(BuySell)}:{BuySell} {nameof(Strategy)}:{Strategy} " +
                   $"\n  {nameof(EntryPrice)}:{EntryPrice} {nameof(ClosePrice)}:{ClosePrice} {nameof(TargetPrice)}:{TargetPrice} {nameof(Success)}:{Success}  {nameof(Timestamp)}:{Timestamp}\n";
        }
    }
}