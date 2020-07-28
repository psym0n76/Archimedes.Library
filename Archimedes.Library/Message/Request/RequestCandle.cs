using System;
using System.Collections.Generic;
using Archimedes.Library.Domain;

namespace Archimedes.Library.Message
{
    public class RequestCandle : IRequest
    {
        //private readonly DateTime _endDate;
        //private readonly DateTime _startDate;
        //private readonly int _maxIntervals;

        //public RequestCandle(DateTime startDate, DateTime endDate, int maxIntervals)
        //{
        //    _startDate = startDate;
        //    _endDate = endDate;
        //    _maxIntervals = maxIntervals;
        //}


        public int Interval { get; set; }

        public int MaxIntervals { get; set; }
        public string Market { get; set; }
        public string TimeFrameInterval => $"{Interval}{TimeFrame}";
        public string TimeFrame { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public int Intervals => IntervalCount();
        public List<DateRange> DateRanges { get; set; }


        // potentially remove these
        public string Text { get; set; }
        public string Status { get; set; }
        public List<string> Properties { get; set; }



        public override string ToString()
        {
            return $"\n {nameof(RequestCandleOld)}" +
                   $"\n  {nameof(Market)}: {Market} {nameof(TimeFrameInterval)}: {TimeFrameInterval} " +
                   $"\n  {nameof(StartDate)}: {StartDate} {nameof(EndDate)}: {EndDate} " +
                   $"\n  {nameof(Intervals)}: {Intervals} ({DateRanges.Count} requests)";
        }

        public List<DateRange> CalculateDateRanges()
        {
            bool splitDateRange;
            var dateRange = new List<DateRange>();

            var intFromDate = StartDate;
            var intToDate = EndDate;

            do
            {
                splitDateRange = false;
                if (intToDate >= intFromDate.AddMinutes(MaxIntervals * Interval))
                {
                    intToDate = intFromDate.AddMinutes(MaxIntervals * Interval);
                    splitDateRange = true;
                }

                var range = new DateRange()
                {
                    StartDate = intFromDate,
                    EndDate = intToDate
                };

                dateRange.Add(range);

                intFromDate = intToDate;
                intToDate = EndDate;

            } while (splitDateRange);

            return dateRange;
        }

        public int IntervalCount()
        {
            var delta = EndDate - StartDate;
            var intervals = 0;

            //if (TimeFrame.Value == GranularityType.Minute.Value

            if (TimeFrame == "Min")
            {
                intervals = (int) delta.TotalMinutes / Interval; 
            }

            //if (TimeFrame.Value == GranularityType.Hour.Value)
            if (TimeFrame == "H")
            {
                intervals = (int) delta.TotalHours / Interval; 
            }

            return intervals;
        }
    }
}