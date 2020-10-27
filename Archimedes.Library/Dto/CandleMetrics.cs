using Newtonsoft.Json;
using System;

namespace Archimedes.Library.Message.Dto
{
    public class CandleMetrics
    {
        [JsonProperty(PropertyName = "maxDate")]
        public DateTime MaxDate { get; set; }

        [JsonProperty(PropertyName = "minDate")]
        public DateTime MinDate { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
    }
}