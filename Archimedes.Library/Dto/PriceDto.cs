using System;
using Newtonsoft.Json;

namespace Archimedes.Library.Message.Dto
{
     public class PriceDto
    { 

        [JsonProperty(PropertyName = "market")]
        public string  Market { get; set; }

        [JsonProperty(PropertyName = "granularity")]
        public string  Granularity { get; set; }


        [JsonProperty(PropertyName = "bid")]
        public decimal Bid { get; set; }

        [JsonProperty(PropertyName = "ask")]
        public decimal Ask { get; set; }

        [JsonProperty(PropertyName = "timeStamp")]
        public DateTime TimeStamp { get; set; }


        public override string ToString()
        {
            return 
                $"\n\n {nameof(PriceDto)}" +
                $"\n  {nameof(Market)}: {Market}  {nameof(Market)}: {Market} {nameof(Granularity)}: {Granularity}" +
                $"\n  {nameof(Bid)}: {Bid} {nameof(Ask)}: {Ask} {nameof(TimeStamp)}: {TimeStamp} \n";
        }

    }
}
