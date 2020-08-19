using System;
using System.Collections.Generic;
using Archimedes.Library.Domain;

namespace Archimedes.Library.Message
{
    public class CandleDateRanges
    {
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;
        private readonly int _maxIntervals;
        private readonly int _interval;

        public CandleDateRanges(DateTime startDate, DateTime endDate, int maxIntervals, int interval)
        {
            _startDate = startDate;
            _endDate = endDate;
            _maxIntervals = maxIntervals;
            _interval = interval;
        }


        public List<DateRange> Calculate()
        {
            bool splitDateRange;
            var dateRange = new List<DateRange>();

            var intFromDate = _startDate;
            var intToDate = _endDate;

            do
            {
                splitDateRange = false;
                if (intToDate >= intFromDate.AddMinutes(_maxIntervals * _interval))
                {
                    intToDate = intFromDate.AddMinutes(_maxIntervals * _interval);
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
    }
}