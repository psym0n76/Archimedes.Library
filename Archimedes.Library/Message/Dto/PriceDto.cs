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

        /// <summary>
        /// The market
        /// </summary>
        [JsonProperty(PropertyName = "granularity")]
        public string  Granularity { get; set; }

        /// <summary>
        /// The price BidOpen price.
        /// </summary>
        [JsonProperty(PropertyName = "bidopen")]
        public double BidOpen { get; set; }

        /// <summary>
        /// The price BidClose price.
        /// </summary>
        [JsonProperty(PropertyName = "bidclose")]
        public double BidClose { get; set; }

        /// <summary>
        /// The price BidHigh price.
        /// </summary>
        [JsonProperty(PropertyName = "bidhigh")]
        public double BidHigh { get; set; }

        /// <summary>
        /// The price BidLow price.
        /// </summary>
        [JsonProperty(PropertyName = "bidlow")]
        public double BidLow { get; set; }

        /// <summary>
        /// The price AskOpen price.
        /// </summary>
        [JsonProperty(PropertyName = "askopen")]
        public double AskOpen { get; set; }

        /// <summary>
        /// The price AskClose price.
        /// </summary>
        [JsonProperty(PropertyName = "askclose")]
        public double AskClose { get; set; }

        /// <summary>
        /// The price BidHigh price.
        /// </summary>
        [JsonProperty(PropertyName = "askhigh")]
        public double AskHigh { get; set; }

        /// <summary>
        /// The price AskLow price.
        /// </summary>
        [JsonProperty(PropertyName = "asklow")]
        public double AskLow { get; set; }

        /// <summary>
        /// The price tick quantity value.
        /// </summary>
        [JsonProperty(PropertyName = "tickqty")]
        public double TickQty { get; set; }

        /// <summary>
        /// The price timestamp.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
