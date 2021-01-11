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


        public string Start(string threadId)
        {
            lock (LockingObject)
            {
                var logId = $"{threadId}{Guid.NewGuid()}";
                var logs = new List<Log>
                {
                    new Log()
                    {
                        Id = 1,
                        LogId = logId,
                        Description = "Start Logging",
                        ElapsedTimeSeconds = 0,
                        TotalElapsedTimeSeconds = 0,
                        TimeStamp = DateTime.Now
                    }
                };

                _dictLogs[threadId] = logs;
                return logId;
            }
        }



        private void Stop(string id)
        {
            Update(id, "End Logging");
        }

        public void Update(string id, string message)
        {
            lock (LockingObject)
            {
                var logs = _dictLogs[id];
                var counter = logs.Count + 1;

                var start = logs[0].TimeStamp;
                var previous = logs[counter - 1 - 1].TimeStamp;
                var today = DateTime.Now;

                var totalElapsed = (today - start).TotalMilliseconds;
                var elapsed = (today - previous).TotalMilliseconds;

                logs.Add(new Log()
                {
                    Id = counter,
                    LogId = id,
                    Description = message,
                    ElapsedTimeSeconds = decimal.Parse(elapsed.ToString(CultureInfo.InvariantCulture)),
                    TotalElapsedTimeSeconds = decimal.Parse(totalElapsed.ToString(CultureInfo.InvariantCulture)),
                    TimeStamp = today
                });

                _dictLogs[id] = logs;
            }
        }

        public string Print(string id, string message = "", Exception e = null)
        {
            if (e != null)
            {
                message = $"{message} \n\nErrorMessage: {e.Message} \n\nStackTrace: {e.StackTrace}\n\n";
            }

            if (!string.IsNullOrEmpty(message))
            {
                Update(id, message);
            }

            Stop(id);

            lock (LockingObject)
            {
                var logs = _dictLogs[id];

                var stringBuilder = new StringBuilder();
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