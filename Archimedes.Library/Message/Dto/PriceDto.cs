using System;

namespace Archimedes.Library.Message.Dto
{
    public class PriceDto
    {
        public DateTime Date { get; set; }
        public decimal Ask { get; set; }
        public decimal Bid { get; set; }
    }
}