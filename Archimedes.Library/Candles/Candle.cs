using System;
using Archimedes.Library.Enums;

namespace Archimedes.Library.Candles
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
            return
                $"\n{nameof(TimeStamp)}: {TimeStamp}" +
                $" {nameof(Market)}: {Market}" +
                $" {nameof(TimeFrame)}: {TimeFrame.GetDescription()}" +
                $"\n{nameof(Open)}: {Open}" +
                $" {nameof(High)}: {High}" +
                $" {nameof(Low)}: {Low}" +
                $" {nameof(Close)}: {Close}";
        }


        public int CompareTo(Candle c)
        {
            if (TimeStamp < c.TimeStamp) return 1;
            if (TimeStamp > c.TimeStamp) return -1;
            return 0;
        }
    }
}