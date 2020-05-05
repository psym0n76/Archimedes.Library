using System;

namespace Fx.Domain.Candles.OHLC
{
    public class Price
    {
        public Price(decimal bid, decimal ask)
        {
            Bid = bid;
            Ask = ask;
            TimeStamp = DateTime.Now;
        }

        public decimal Bid { get; }
        public decimal Ask { get; }
        public DateTime TimeStamp { get; }
    }
}