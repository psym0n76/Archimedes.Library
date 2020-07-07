
using Archimedes.Library.Enums;

namespace Archimedes.Library.Candles
{
    public static class CandleExtension
    {
        public static Colour Color(this Candle c)
        {

            if (c.Open.Bid > c.Close.Bid)
            {
                return Colour.Red;
            }

            if (c.Open.Bid < c.Close.Bid)
            {
                return Colour.Green;
            }

            return Colour.Black;
        }

        public static Price Top(this Candle c)
        {
            if (c.Color() == Colour.Green)
            {
                return c.Close;
            }

            return c.Open;
        }

        public static Price Bottom(this Candle c)
        {
            if (c.Color() == Colour.Red)
            {
                return c.Close;
            }

            return c.Open;
        }

        public static CandleType Type(this Candle c)
        {
            if (c.Open.Bid == c.Close.Bid)
            {
                return CandleType.Doji;
            }

            if (c.Open.Bid == c.High.Bid && c.Close.Bid == c.Low.Bid)
            {
                return CandleType.Engulfing;
            }

            if (c.Open.Bid == c.Low.Bid && c.Close.Bid == c.High.Bid)
            {
                return CandleType.Engulfing;
            }

            return CandleType.Null;
        }
    }
}