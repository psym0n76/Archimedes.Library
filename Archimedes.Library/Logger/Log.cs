using System;
using System.Globalization;

namespace Archimedes.Library.Logger
{
    public class Log
    {
        private decimal _elapsed;

        public DateTime TimeStamp { get; set; }
        public string Description { get; set; }

        public decimal ElapsedTimeSeconds
        {
            get => Math.Round(decimal.Parse(_elapsed.ToString(CultureInfo.InvariantCulture)) / 1000, 4);
            set => _elapsed = value;
        }

        public string ElapsedTimeText => $"{ElapsedTimeSeconds} sec(s)";

        public override string ToString()
        {
            return
                $"{TimeStamp} Elapsed: {ElapsedTimeText.PadRight(10, ' ')} {nameof(Description)}: {Description}";
        }
    }
}