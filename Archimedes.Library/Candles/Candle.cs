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

        public Dictionary<int, Candle> PastCandlesDict { get; set; }

        public Dictionary<int, Candle> FutureCandlesDict { get; set; }

        public DateTime ElapsedTime { get; set; }

        public string GetElapsed()
        {
            var span = (DateTime.Now - ElapsedTime);
            return $"Minutes: {span.Minutes} Seconds: {span.Seconds}.{span.Milliseconds}";
        }

        public Candle(Open open, High high, Low low, Close close, string market, string timeFrame, DateTime timeStamp)
        {
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Market = market;
            TimeFrame = timeFrame;
            TimeStamp = timeStamp;
            ElapsedTime = DateTime.Now;
            PastCandles = new List<Candle>();
            PastCandlesDict = new Dictionary<int, Candle>();
            FutureCandles = new List<Candle>();
            FutureCandlesDict = new Dictionary<int, Candle>();
        }

        public override string ToString()
        {
            return
                $"\n\n {nameof(Candle)}" +
                $"\n  {nameof(TimeStamp)}: {TimeStamp} {nameof(Market)}: {Market} {nameof(TimeFrame)}: {TimeFrame}" +
                $"\n  {nameof(Open.Bid)}: {Open.Bid} {nameof(High.Bid)}: {High.Bid} {nameof(Low.Bid)}: {Low.Bid} {nameof(Close.Bid)}: {Close.Bid}" +
                $"\n  Elapsed Time: {GetElapsed()}";
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