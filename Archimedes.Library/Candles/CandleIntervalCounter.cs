using System;

namespace Archimedes.Library.Candles
{
    public class CandleIntervalCounter
    {
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;
        private readonly int _interval;
        private readonly string _timeFrame;

        public CandleIntervalCounter(DateTime startDate, DateTime endDate, int interval, string timeFrame)
        {
            _startDate = startDate;
            _endDate = endDate;
            _interval = interval;
            _timeFrame = timeFrame;
        }

        public int Count()
        {
            var delta = _endDate - _startDate;
            var intervals = 0;

            //if (TimeFrame.Value == GranularityType.Minute.Value

            if (_timeFrame == "Min")
            {
                intervals = (int) delta.TotalMinutes / _interval; 
            }

            //if (TimeFrame.Value == GranularityType.Hour.Value)
            if (_timeFrame == "H")
            {
                intervals = (int) delta.TotalHours / _interval; 
            }

            return intervals;
        }
    }
}