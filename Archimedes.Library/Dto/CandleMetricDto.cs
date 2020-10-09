using System;
using Newtonsoft.Json;

namespace Archimedes.Library.Message.Dto
{
    public class CandleMetricDto
    {
        [JsonProperty(PropertyName = "maxDate")]
        public DateTime MaxDate { get; set; }

        [JsonProperty(PropertyName = "minDate")]
        public DateTime MinDate { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
    }
}