using System;

namespace Archimedes.Library.Dto
{
    public class BidAskDto
    {
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}