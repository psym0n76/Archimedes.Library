using System;
using System.Collections.Generic;

namespace Archimedes.Library.Message
{
    public class RequestCandle : IRequest
    {
        private readonly DateTime _toDate;
        private readonly DateTime _fromDate;
        private readonly int _maxIntervals;

        public RequestCandle(DateTime fromDate, DateTime toDate, int maxIntervals)
        {
            _fromDate = fromDate;
            _toDate = toDate;
            _maxIntervals = maxIntervals;
        }

        public int Interval { get; set; }
        public string Market { get; set; }
        public string TimeFrame { get; set; }
        public string TimeFrameInterval => $"{Interval}{TimeFrame}";


        public int Intervals => IntervalCount();
        public List<DateRange> DateRanges => CalculateDateRanges();


        // potentially remove these
        public string Text { get; set; }
        public string Status { get; set; }
        public IList<string> Properties { get; set; }



        public override string ToString()
        {
            return $"Market: {Market} TimeFrameInterval: {TimeFrameInterval}";
        }

        private List<DateRange> CalculateDateRanges()
        {
            bool splitDateRange;
            var dateRange = new List<DateRange>();

            var intFromDate = _fromDate;
            var intToDate = _toDate;

            do
            {
                splitDateRange = false;
                if (intToDate >= intFromDate.AddMinutes(_maxIntervals * Interval))
                {
                    intToDate = intFromDate.AddMinutes(_maxIntervals * Interval);
                    splitDateRange = true;
                }

                var range = new DateRange()
                {
                    DateFrom = intFromDate,
                    DateTo = intToDate
                };

                dateRange.Add(range);

                intFromDate = intToDate;
                intToDate = _toDate;

            } while (splitDateRange);

            return dateRange;
        }

        public int IntervalCount()
        {
            var delta = _toDate - _fromDate;
            var intervals = 0;

            if (TimeFrame == "minute")
            {
                intervals = (int) delta.TotalMinutes / Interval;
            }

            if (TimeFrame == "hour")
            {
                intervals = (int) delta.TotalHours / Interval;
            }

            return intervals;
        }
    }

    public class DateRange      
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}