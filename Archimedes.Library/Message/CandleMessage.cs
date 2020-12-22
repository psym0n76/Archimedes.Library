using System;
using System.Collections.Generic;
using Archimedes.Library.Domain;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Message
{
    public class CandleMessage
    {

        public string Market { get; set; }
        public int MarketId { get; set; }
        public int Interval { get; set; }
        public string TimeFrame { get; set; }

        public string TimeFrameBroker { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<CandleDto> Candles { get; set; }
        public int MaxIntervals { get; set; }


        public List<DateRange> DateRanges { get; set; }
        public int Intervals { get; set; }

        public bool Success { get; set; }
        public List<string> Logs { get; set; }

        public DateTime ElapsedTime { get; set; }

        public string QueueName => $"Archimedes_Candle_{Market.Replace("/", "")}.{Interval}{TimeFrame}";

        public override string ToString()
        {
            return $"\n\n {nameof(CandleMessage)}" +
                   $"\n  {nameof(Market)}: {Market} {nameof(MarketId)}: {MarketId} {nameof(Interval)}: {Interval} {nameof(TimeFrame)}: {TimeFrame} {nameof(StartDate)}: {StartDate} {nameof(EndDate)}: {EndDate} " +
                   $"\n  Candle Counter: { GetCandleCount()} in {GetRequestCount()} request(s) {nameof(ElapsedTime)}: { GetElapsed()} \n";
        }

        private int GetCandleCount()
        {
            return Candles?.Count ?? 0;
        }

        private int GetRequestCount()
        {
            return DateRanges?.Count ?? 0;
        }

        private string GetElapsed()
        {
            var span = (DateTime.Now - ElapsedTime);
            return $"Minutes: {span.Minutes} Seconds: {span.Seconds}.{span.Milliseconds}";
        }
    }
}