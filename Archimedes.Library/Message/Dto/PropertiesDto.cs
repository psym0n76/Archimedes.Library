using System;
using Newtonsoft.Json;

namespace Archimedes.Library.Message.Dto
{
    public class PropertiesDto
    {
        [JsonProperty(PropertyName = "accesstoken")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "instrument")]
        public string Instrument { get; set; }

        [JsonProperty(PropertyName = "buysell")]
        public string BuySell { get; set; }

        [JsonProperty(PropertyName = "lots")]
        public int? Lots { get; set; }

        [JsonProperty(PropertyName = "account")]
        public string Account { get; set; }

        [JsonProperty(PropertyName = "timeframe")]
        public string Timeframe { get; set; }

        [JsonProperty(PropertyName = "datefrom")]
        public DateTime DateFrom { get; set; }

        [JsonProperty(PropertyName = "dateto")]
        public DateTime DateTo { get; set; }

        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
    }
}