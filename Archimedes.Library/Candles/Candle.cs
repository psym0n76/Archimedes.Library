using System;
using System.Collections.Generic;

namespace Archimedes.Library.Candles
{
    public class Candle : IComparable<Candle>
    {
        public Open Open { get; }
        public High High { get; }
        public Low Low { get; }
        public Close Close { get; }
        public string Market { get; }
        public string TimeFrame { get; }
        public DateTime TimeStamp { get; }
        public List<Candle> PastCandles { get; set; }
        public List<Candle> FutureCandles { get; set; }

        public Candle(Open open, High high, Low low, Close close, string market, string timeFrame, DateTime timeStamp)
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
                $" {nameof(TimeFrame)}: {TimeFrame}" +
                $"\n{nameof(Open)}: {Open}" +
                $" {nameof(High)}: {High}" +
                $" {nameof(Low)}: {Low}" +
                $" {nameof(Close)}: {Close}";
        }

        IEnumerable<Candle> UnwrapCandle(Candle p)
        {
            var list = new List<Candle> {p};
            if (p != null)
                list.AddRange(UnwrapCandle(p));

            return list;
        }

        public int CompareTo(Candle c)
        {
            if (TimeStamp < c.TimeStamp) return 1;
            if (TimeStamp > c.TimeStamp) return -1;
            return 0;
        }
    }
}