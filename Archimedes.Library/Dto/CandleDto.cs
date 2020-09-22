using System;
using Newtonsoft.Json;

namespace Archimedes.Library.Message.Dto
{
    /// <summary>
    /// The historical candle entity.
    /// </summary>
    public class CandleDto : PriceDto
    {

        [JsonProperty(PropertyName = "fromDate")]
        public DateTime FromDate { get; set; }

        [JsonProperty(PropertyName = "toDate")]
        public DateTime ToDate { get; set; }

    }
}