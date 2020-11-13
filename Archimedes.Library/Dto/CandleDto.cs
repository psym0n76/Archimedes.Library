using System;
using Newtonsoft.Json;

namespace Archimedes.Library.Message.Dto
{

    public class CandleDto
    {

        [JsonProperty(PropertyName = "market")]
        public string  Market { get; set; }

        [JsonProperty(PropertyName = "marketId")]
        public int  MarketId { get; set; }


        [JsonProperty(PropertyName = "granularity")]
        public string  Granularity { get; set; }




        [JsonProperty(PropertyName = "fromDate")]
        public DateTime FromDate { get; set; }

        [JsonProperty(PropertyName = "toDate")]
        public DateTime ToDate { get; set; }




        [JsonProperty(PropertyName = "bidOpen")]
        public decimal BidOpen { get; set; }


        [JsonProperty(PropertyName = "bidClose")]
        public decimal BidClose { get; set; }


        [JsonProperty(PropertyName = "bidHigh")]
        public decimal BidHigh { get; set; }


        [JsonProperty(PropertyName = "bidLow")]
        public decimal BidLow { get; set; }


        [JsonProperty(PropertyName = "askOpen")]
        public decimal AskOpen { get; set; }


        [JsonProperty(PropertyName = "askClose")]
        public decimal AskClose { get; set; }


        [JsonProperty(PropertyName = "askHigh")]
        public decimal AskHigh { get; set; }


        [JsonProperty(PropertyName = "askLow")]
        public decimal AskLow { get; set; }


        [JsonProperty(PropertyName = "tickQty")]
        public double TickQty { get; set; }


        [JsonProperty(PropertyName = "timeStamp")]
        public DateTime TimeStamp { get; set; }

        [JsonProperty(PropertyName = "lastUpdated")]
        public DateTime LastUpdated { get; set; }

        public override string ToString()
        {
            return 
                $"\n\n {nameof(PriceDto)}" +
                $"\n  {nameof(TimeStamp)}: {TimeStamp} {nameof(Market)}: {Market}  {nameof(MarketId)}: {MarketId} {nameof(Granularity)}: {Granularity} {nameof(TickQty)}: {TickQty}" +
                $"\n  {nameof(BidOpen)}: {BidOpen} {nameof(BidHigh)}: {BidHigh} {nameof(BidLow)}: {BidLow} {nameof(BidClose)}: {BidClose}" +
                $"\n  {nameof(AskOpen)}: {AskOpen} {nameof(AskHigh)}: {AskHigh} {nameof(AskLow)}: {AskLow} {nameof(AskClose)}: {AskClose}\n";
        }

    }
}