using System;
using System.Collections.Generic;
using Archimedes.Library.Domain;
using Archimedes.Library.Types;

namespace Archimedes.Library.Message
{
    public class RequestCandle : IRequest
    {
        private readonly DateTime _endDate;
        private readonly DateTime _startDate;
        private readonly int _maxIntervals;

        public RequestCandle(DateTime startDate, DateTime endDate, int maxIntervals)
        {
            _startDate = startDate;
            _endDate = endDate;
            _maxIntervals = maxIntervals;
        }

        public int Interval { get; set; }
        public string Market { get; set; }
        public string TimeFrameInterval => $"{Interval}{TimeFrame}";
        public string TimeFrame { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public int Intervals => IntervalCount();
        public List<DateRange> DateRanges => CalculateDateRanges();


        // potentially remove these
        public string Text { get; set; }
        public string Status { get; set; }
        public IList<string> Properties { get; set; }



        public override string ToString()
        {
            return $"Candle Request -  " +
                   $"\n{nameof(Market)}: {Market} " +
                   $"\n{nameof(TimeFrameInterval)}: {TimeFrameInterval} " +
                   $"\n StartDate: {_startDate} " +
                   $"\n EndDate: {_endDate} " +
                   $"\n {nameof(Intervals)}: {Intervals}";
        }

        private List<DateRange> CalculateDateRanges()
        {
            bool splitDateRange;
            var dateRange = new List<DateRange>();

            var intFromDate = _startDate;
            var intToDate = _endDate;

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
                    StartDate = intFromDate,
                    EndDate = intToDate
                };

                dateRange.Add(range);

                intFromDate = intToDate;
                intToDate = _endDate;

            } while (splitDateRange);

            return dateRange;
        }

        public int IntervalCount()
        {
            var delta = _endDate - _startDate;
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