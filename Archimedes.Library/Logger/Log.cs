using System;

namespace Archimedes.Library.Logger
{
    public class Log
    {
        public DateTime TimeStamp { get; set; }
        public string  Description { get; set; }
        public long ElapsedTimeMilliseconds { get; set; }

        public override string ToString()
        {
            return
                $"{TimeStamp} Elapsed: {ElapsedTimeMilliseconds.ToString().PadRight(10, ' ')} {nameof(Description)}: {Description}";
            //return
            //    $"{nameof(TimeStamp)}:{TimeStamp} {nameof(Description)}:{Description} {nameof(ElapsedTimeMilliseconds)}:{ElapsedTimeMilliseconds}";
        }
    }
}