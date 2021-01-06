using System;
using Newtonsoft.Json;

namespace Archimedes.Library.Message.Dto
{
    public class PriceLevelDto
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "market")]
        public string Market { get; set; }

        [JsonProperty(PropertyName = "granularity")]
        public string Granularity { get; set; }

        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }

        [JsonProperty(PropertyName = "outsideOfRange")]
        public bool OutsideOfRange { get; set; }

        [JsonProperty(PropertyName = "outsideOfRangeDate")]
        public DateTime OutsideOfRangeDate { get; set; }

        [JsonProperty(PropertyName = "levelBroken")]
        public bool LevelBroken { get; set; }


        [JsonProperty(PropertyName = "candlesElapsedLevelBroken")]
        public int CandlesElapsedLevelBroken { get; set; }


        [JsonProperty(PropertyName = "trade")]
        public bool Trade { get; set; }

        [JsonProperty(PropertyName = "buySell")]
        public string BuySell { get; set; }

        [JsonProperty(PropertyName = "candleType")]
        public string CandleType { get; set; }

        [JsonProperty(PropertyName = "timeStamp")]
        public DateTime TimeStamp { get; set; }

        [JsonProperty(PropertyName = "strategy")]
        public string Strategy { get; set; }


        [JsonProperty(PropertyName = "levelsBroken")]
        public int LevelsBroken { get; set; }

        [JsonProperty(PropertyName = "lastLevelBrokenDate")]
        public DateTime LevelBrokenDate { get; set; }

        [JsonProperty(PropertyName = "Trades")]
        public int Trades { get; set; }




        [JsonProperty(PropertyName = "bidPrice")]
        public decimal BidPrice { get; set; }

        [JsonProperty(PropertyName = "bidPriceRange")]
        public decimal BidPriceRange { get; set; }

        [JsonProperty(PropertyName = "askPrice")]
        public decimal AskPrice { get; set; }

        [JsonProperty(PropertyName = "askPriceRange")]
        public decimal AskPriceRange { get; set; }





        [JsonProperty(PropertyName = "lastUpdated")]
        public DateTime LastUpdated {get; set;}

        public override string ToString()
        {
            return
                $"\n\n {nameof(PriceLevelDto)}" +
                $"\n  {nameof(BidPrice)}: {BidPrice} {nameof(BidPriceRange)}: {BidPriceRange} {nameof(BuySell)}: {BuySell} {nameof(CandleType)}: {CandleType}" +
                $"\n  {nameof(Market)}: {Market} {nameof(Granularity)}: {Granularity} {nameof(TimeStamp)}: {TimeStamp} {nameof(Strategy)}: {Strategy}";
        }
    }
}