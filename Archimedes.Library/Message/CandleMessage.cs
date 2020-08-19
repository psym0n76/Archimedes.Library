using System;
using System.Collections.Generic;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Message
{
    public class CandleMessage
    {
        public string Market { get; set; }
        public int Interval { get; set; }
        public string TimeFrame { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<CandleDto> Candles { get; set; }


        public override string ToString()
        {
            return $"\n {nameof(CandleMessage)}" +
                   $"\n  {nameof(Market)}: {Market} {nameof(Interval)}: {Interval} " +
                   $"\n  {nameof(TimeFrame)} : {TimeFrame} "+
                   $"\n  {nameof(StartDate)}: {StartDate} {nameof(EndDate)}: {EndDate} requests)";
        }
    }
}