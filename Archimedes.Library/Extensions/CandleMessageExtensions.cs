using System.Collections.Generic;
using Archimedes.Library.Domain;
using Archimedes.Library.Message;

namespace Archimedes.Library.Extensions
{
    public static class CandleMessageExtensions
    {
        public static CandleMessage CalculateDateRanges(this CandleMessage candle)
        {
            bool splitDateRange;

            candle.DateRanges = new List<DateRange>();

            var intFromDate = candle.StartDate;
            var intToDate = candle.EndDate;

            do
            {
                splitDateRange = false;
                if (intToDate >= intFromDate.AddMinutes(candle.MaxIntervals * candle.Interval))
                {
                    intToDate = intFromDate.AddMinutes(candle.MaxIntervals * candle.Interval);
                    splitDateRange = true;
                }

                var range = new DateRange()
                {
                    StartDate = intFromDate,
                    EndDate = intToDate
                };

                candle.DateRanges.Add(range);

                intFromDate = intToDate;
                intToDate = candle.EndDate;

            } while (splitDateRange);

            return candle;
        }

        public static CandleMessage CountCandleIntervals(this CandleMessage candle)
        {
            var delta = candle.EndDate - candle.StartDate;

            //if (TimeFrame.Value == GranularityType.Minute.Value

            if (candle.TimeFrame == "Min")
            {
                candle.Intervals = (int) delta.TotalMinutes / candle.Interval; 
            }

            //if (TimeFrame.Value == GranularityType.Hour.Value)
            if (candle.TimeFrame == "H")
            {
                candle.Intervals = (int) delta.TotalHours / candle.Interval; 
            }

            return candle;
        }
    }
}