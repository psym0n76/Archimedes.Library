using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Archimedes.Library.Logger
{
    public class BatchLog
    {
        private static readonly object LockingObject = new object();

        private readonly ConcurrentDictionary<string, List<Log>> _dictLogs =
            new ConcurrentDictionary<string, List<Log>>();

        public string Start()
        {
            lock (LockingObject)
            {
                var logId = Guid.NewGuid();
                var logs = new List<Log>
                {
                    new Log()
                    {
                        Id = 1,
                        LogId = logId.ToString(),
                        Description = "Start Logging",
                        ElapsedTimeSeconds = 0,
                        TotalElapsedTimeSeconds = 0,
                        TimeStamp = DateTime.Now
                    }
                };

                _dictLogs[logId.ToString()] = logs;

                return logId.ToString();
            }

        }


        public string Start(string idThread)
        {
            lock (LockingObject)
            {
                var logId = $"{Guid.NewGuid()}";
                var logs = new List<Log>
                {
                    new Log()
                    {
                        Id = 1,
                        LogId = $"{logId}{idThread}",
                        Description = "Start Logging",
                        ElapsedTimeSeconds = 0,
                        TotalElapsedTimeSeconds = 0,
                        TimeStamp = DateTime.Now
                    }
                };

                _dictLogs[$"{logId}{idThread}"] = logs;
                return logId;
            }
        }



        private void Stop(string idThread)
        {
            Update(idThread, "End Logging");
        }

        public void Update(string idThread, string message)
        {
            lock (LockingObject)
            {
                var logs = _dictLogs[idThread];
                var counter = logs.Count + 1;

                var start = logs[0].TimeStamp;
                var previous = logs[counter - 1 - 1].TimeStamp;
                var today = DateTime.Now;

                var totalElapsed = (today - start).TotalMilliseconds;
                var elapsed = (today - previous).TotalMilliseconds;

                logs.Add(new Log()
                {
                    Id = counter,
                    LogId = idThread,
                    Description = message,
                    ElapsedTimeSeconds = decimal.Parse(elapsed.ToString(CultureInfo.InvariantCulture)),
                    TotalElapsedTimeSeconds = decimal.Parse(totalElapsed.ToString(CultureInfo.InvariantCulture)),
                    TimeStamp = today
                });

                if (_dictLogs.ContainsKey(idThread))
                {
                    _dictLogs[idThread] = logs;
                }
            }
        }

        public string Print(string idThread, string message = "", Exception e = null)
        {
            if (e != null)
            {
                message = $"{message} \n\nErrorMessage: {e.Message} \n\nStackTrace: {e.StackTrace}\n\n";
            }

            if (!string.IsNullOrEmpty(message))
            {
                Update(idThread, message);
            }

            Stop(idThread);

            lock (LockingObject)
            {
                var stringBuilder = new StringBuilder();

                if (!_dictLogs.ContainsKey(idThread)) return stringBuilder.ToString();
                
                var logs = _dictLogs[idThread];

                var orderLog = logs.OrderBy(a => a.Id);

                stringBuilder.AppendLine();

                foreach (var log in orderLog)
                {
                    stringBuilder.AppendLine(log.ToString());
                }

                return stringBuilder.ToString();
            }
        }
    }
}