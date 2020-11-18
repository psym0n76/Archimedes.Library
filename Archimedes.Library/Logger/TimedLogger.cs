using System;
using System.Diagnostics;
using System.Text;

namespace Archimedes.Library.Logger
{
    public class TimedLogger
    {
        private readonly StringBuilder _logger;
        private readonly Stopwatch _timer;
        private readonly string _title;
        private long _elapsed = 0;

        //todo add a list to collect different logs

        public TimedLogger(string message)
        {
            _timer = new Stopwatch();
            _timer.Start();
            _title = message;
            _logger = new StringBuilder();
        }


        public void EndLog()
        {
            var dateMessage = $"{DateTime.Now} {_title} Duration: {_timer.ElapsedMilliseconds}ms";
            //Debug.WriteLine(dateMessage);
            _logger.Append(dateMessage);
        }

        public void UpdateLog(string message)
        {
            var time = _timer.ElapsedMilliseconds;
            var dateMessage = $"{DateTime.Now} {_title} {message} Duration: {time - _elapsed}ms Elapsed: {time}ms";
            _elapsed = time;
            //Debug.WriteLine(dateMessage);
            _logger.AppendLine(dateMessage);
        }

        public string GetLog()
        {
            return _logger.ToString();
        }
    }
}