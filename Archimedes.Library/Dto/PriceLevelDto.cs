﻿using System;
using Newtonsoft.Json;

namespace Archimedes.Library.Message.Dto
{
    public class PriceLevelDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "price")]
        public double Price { get; set; }

        [JsonProperty(PropertyName = "priceRange")]
        public double PriceRange { get; set; }

        [JsonProperty(PropertyName = "tradeType")]
        public string TradeType { get; set; }

        [JsonProperty(PropertyName = "active")]
        public string Active { get; set; }

        [JsonProperty(PropertyName = "timeStamp")]
        public DateTime TimeStamp { get; set; }

        [JsonProperty(PropertyName = "market")]
        public string Market { get; set; }

        [JsonProperty(PropertyName = "granularity")]
        public string Granularity { get; set; }

        [JsonProperty(PropertyName = "lastUpdated")]
        public DateTime LastUpdated {get; set;}
    }
}