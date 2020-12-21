using System;
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
            if (c.Close.Bid > c.Open.Bid)
            {
                return c.Close;
            }

            return c.Open;
        }

        public static Price Bottom(this Candle c)
        {
            if (c.Close.Bid > c.Open.Bid)
            {
                return c.Open;
            }

            return c.Close;
        }


        public static decimal Fibonacci382(this Candle candle)
        {
            var result = 0m;

            if (candle.Color()==Colour.Green)
            {
                var range = (candle.High.Ask - candle.Low.Ask) * 0.382m;

                result =  candle.High.Ask - range;
            }

            if (candle.Color() == Colour.Red)
            {
                var range = (candle.High.Bid - candle.Low.Bid) * 0.382m;

                result= candle.Low.Bid + range;
            }

            return result;
        }

        public static CandleType Type(this Candle c)
        {
            if (c.Open.Bid == c.Close.Bid)
            {
                return CandleType.Doji;
            }

            if (c.Close.Bid < c.PastCandles[0].Low.Bid && c.PastCandles[0].Color() == Colour.Green)
            {
                //bearish red engulf
                return CandleType.Engulfing;
            }

            if (c.Close.Bid > c.PastCandles[0].High.Bid && c.PastCandles[0].Color() == Colour.Red)
            {
                return CandleType.Engulfing;
            }

            return CandleType.Null;
        }

        public static decimal BodyFillRate(this Candle c)
        {
            var bidHighLowRange = c.High.Bid - c.Low.Bid;

            if (bidHighLowRange == 0)
            {
                return 0m;
            }

            var bidOpenCloseRange = c.Top().Bid - c.Bottom().Bid;

            if (bidOpenCloseRange == 0)
            {
                return 0m;
            }

            return Math.Round(bidOpenCloseRange / bidHighLowRange, 2);
        }
    }
}