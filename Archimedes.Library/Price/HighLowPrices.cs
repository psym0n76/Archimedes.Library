using System;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Price
{
    public class HighLowPrices
    {
        public decimal BidLow { get; set; }
        public decimal BidHigh { get; set; }
        public decimal AskLow { get; set; }
        public decimal AskHigh { get; set; }

        public DateTime BidLowTimestamp { get; set; }
        public DateTime BidHighTimestamp { get; set; }
        public DateTime AskLowTimestamp { get; set; }
        public DateTime AskHighTimestamp { get; set; }
    }
}