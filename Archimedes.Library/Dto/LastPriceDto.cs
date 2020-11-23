using System;

namespace Archimedes.Library.Message.Dto
{
    public class LastPriceDto
    {
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}