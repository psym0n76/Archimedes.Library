using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Archimedes.Library.Logger
{
    public class BatchLog
    {
        private readonly Stopwatch _timer = new Stopwatch();
        private readonly List<Log> _logs = new List<Log>();

        public void Start()
        {
            _timer.Start();
            _logs.Add(new Log()
            {
                Description = "Start Logging",
                ElapsedTimeMilliseconds = 0,
                TimeStamp = DateTime.Now
            });
        }

        private void Stop()
        {
            _logs.Add(new Log()
            {
                Description = "End Logging",
                ElapsedTimeMilliseconds = _timer.ElapsedMilliseconds,
                TimeStamp = DateTime.Now
            });

            _timer.Stop();
        }

        public void Update(string message)
        {
            _logs.Add(new Log()
            {
                Description = message,
                ElapsedTimeMilliseconds = _timer.ElapsedMilliseconds,
                TimeStamp = DateTime.Now
            });
        }

        public string Print()
        {
            Stop();

            var stringBuilder= new StringBuilder();
            var orderLog = _logs.OrderBy(a => a.TimeStamp);

            foreach (var log in orderLog)
            {
                stringBuilder.AppendLine(log.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}