using System;
using Fx.Domain.Candles.OHLC;
using Fx.Domain.Enums;

namespace Fx.Domain.Candles
{
    public class Candle : IComparable<Candle>
    {
        public Open Open { get; }
        public High High { get; }
        public Low Low { get; }
        public Close Close { get; }
        public Market Market { get; }
        public TimeFrame TimeFrame { get; }
        public DateTime TimeStamp { get; }

        public Candle(Open open, High high, Low low, Close close, Market market, TimeFrame timeFrame, DateTime timeStamp)
        {
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Market = market;
            TimeFrame = timeFrame;
            TimeStamp = timeStamp;
        }

        public override string ToString()
        {
            return $"Open: {Open} High: {High} Low: {Low} Close: {Close} " +
                   $"Market: {Market.GetDescription()} " +
                   $"TimeFrame: {TimeFrame.GetDescription()} " +
                   $"TimeStamp: {TimeStamp}";
        }

        public int CompareTo(Candle c)
        {
            if (TimeStamp < c.TimeStamp) return 1;
            if (TimeStamp > c.TimeStamp) return -1;
            return 0;
        }
    }
}