using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Archimedes.Library.Logger
{
    public class BatchLog
    {
        private readonly Stopwatch _timer = new Stopwatch();
        private readonly ConcurrentBag<Log> _logs = new ConcurrentBag<Log>();
        private int _counter = 0;
        private Guid _logId;

        public void Start()
        {
            _timer.Start();
            _logId = new Guid();
            _logs.Add(new Log()
            {
                Id = _counter,
                LogId = _logId,
                Description = "Start Logging",
                ElapsedTimeSeconds = 0,
                TimeStamp = DateTime.Now
            });
        }

        private void Stop()
        {
            _logs.Add(new Log()
            {
                Id = _counter,
                LogId = _logId,
                Description = "End Logging",
                ElapsedTimeSeconds = _timer.ElapsedMilliseconds,
                TimeStamp = DateTime.Now
            });

            _timer.Stop();
            _timer.Reset();
        }

        public void Update(string message)
        {
            _logs.Add(new Log()
            {
                Id = _counter++,
                LogId = _logId,
                Description = message,
                ElapsedTimeSeconds = _timer.ElapsedMilliseconds,
                TimeStamp = DateTime.Now
            });
        }

        public string Print()
        {
            Stop();

            var stringBuilder= new StringBuilder();
            var orderLog = _logs.OrderBy(a => a.Id);

            foreach (var log in orderLog)
            {
                stringBuilder.AppendLine(log.ToString());
            }

            _counter++;
            return stringBuilder.ToString();
        }
    }
}