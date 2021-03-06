﻿using System.Collections.Generic;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Message
{
    public class PriceLevelMessage
    {
        public string Id { get; set; }
        public string Strategy { get; set; }
        public string Market { get; set; }

        public string Granularity { get; set; }
        public List<PriceLevelDto> PriceLevels { get; set; }

        public override string ToString()
        {
            return $"\n\n {nameof(PriceLevelMessage)}" +
                   $"\n  {nameof(Market)}: {Market} {nameof(Strategy)}: {Strategy} {nameof(Granularity)}: {Granularity} " +
                   $"\n  PriceLevel Counter: { GetPriceLevelCount()} \n";
        }

        private int GetPriceLevelCount()
        {
            return PriceLevels?.Count ?? 0;
        }
    }
}