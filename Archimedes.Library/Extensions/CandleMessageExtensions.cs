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
                if (intToDate >= intFromDate.AddMinutes(candle.MaxIntervals * candle.Interval.ToMinutes(candle.TimeFrame)))
                {
                    intToDate = intFromDate.AddMinutes(candle.MaxIntervals * candle.Interval.ToMinutes(candle.TimeFrame));
                    splitDateRange = true;
                }

                var range = new DateRange()
                {
                    // adding an extra interval to prevent duplicate entries
                    StartDate = intFromDate.AddMinutes(candle.Interval.ToMinutes(candle.TimeFrame)),
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

            if (candle.TimeFrame == "Min")
            {
                candle.Intervals = (int) delta.TotalMinutes / candle.Interval.ToMinutes(candle.TimeFrame); 
            }

            if (candle.TimeFrame == "H")
            {
                candle.Intervals = (int) delta.TotalMinutes / candle.Interval.ToMinutes(candle.TimeFrame); 
            }

            if (candle.TimeFrame == "D")
            {
                candle.Intervals = (int) delta.TotalMinutes / candle.Interval.ToMinutes(candle.TimeFrame); 
            }

            return candle;
        }
    }
}