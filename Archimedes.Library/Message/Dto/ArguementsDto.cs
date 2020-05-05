using System;

namespace Fx.Domain.Message.Dto
{
    public class ArguementsDto
    {
        public string AccessToken { get; set; }

        public string Url { get; set; }

        public string Instrument { get; set; }

        public string BuySell { get; set; }

        public int? Lots { get; set; }

        public string Account { get; set; }

        public string Timeframe { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public int Count { get; set; }
    }
}