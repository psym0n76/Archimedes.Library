using System;
using Newtonsoft.Json;

namespace Archimedes.Library.Message.Dto
{
     public class PriceDto
    { 

        /// <summary>
        /// The market
        /// </summary>
        [JsonProperty(PropertyName = "market")]
        public string  Market { get; set; }

        [JsonProperty(PropertyName = "marketId")]
        public int  MarketId { get; set; }

        /// <summary>
        /// The market
        /// </summary>
        [JsonProperty(PropertyName = "granularity")]
        public string  Granularity { get; set; }

        /// <summary>
        /// The price BidOpen price.
        /// </summary>
        [JsonProperty(PropertyName = "bidOpen")]
        public double BidOpen { get; set; }

        /// <summary>
        /// The price BidClose price.
        /// </summary>
        [JsonProperty(PropertyName = "bidClose")]
        public double BidClose { get; set; }

        /// <summary>
        /// The price BidHigh price.
        /// </summary>
        [JsonProperty(PropertyName = "bidHigh")]
        public double BidHigh { get; set; }

        /// <summary>
        /// The price BidLow price.
        /// </summary>
        [JsonProperty(PropertyName = "bidLow")]
        public double BidLow { get; set; }

        /// <summary>
        /// The price AskOpen price.
        /// </summary>
        [JsonProperty(PropertyName = "askOpen")]
        public double AskOpen { get; set; }

        /// <summary>
        /// The price AskClose price.
        /// </summary>
        [JsonProperty(PropertyName = "askClose")]
        public double AskClose { get; set; }

        /// <summary>
        /// The price BidHigh price.
        /// </summary>
        [JsonProperty(PropertyName = "askHigh")]
        public double AskHigh { get; set; }

        /// <summary>
        /// The price AskLow price.
        /// </summary>
        [JsonProperty(PropertyName = "askLow")]
        public double AskLow { get; set; }

        /// <summary>
        /// The price tick quantity value.
        /// </summary>
        [JsonProperty(PropertyName = "tickQty")]
        public double TickQty { get; set; }

        /// <summary>
        /// The price timestamp.
        /// </summary>
        [JsonProperty(PropertyName = "timeStamp")]
        public DateTime Timestamp { get; set; }

        public override string ToString()
        {
            return 
                $"\n {nameof(PriceDto)}" +
                $"\n  {nameof(Timestamp)}: {Timestamp} {nameof(Market)}: {Market} {nameof(TickQty)}: {TickQty}" +
                $"\n  {nameof(BidOpen)}: {BidOpen} {nameof(BidHigh)}: {BidHigh} {nameof(BidLow)}: {BidLow} {nameof(BidClose)}: {BidClose}" +
                $"\n  {nameof(AskOpen)}: {AskOpen} {nameof(AskHigh)}: {AskHigh} {nameof(AskLow)}: {AskLow} {nameof(AskClose)}: {AskClose}";
        }
    }
}
