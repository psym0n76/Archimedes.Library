using System;
using System.Globalization;

namespace Archimedes.Library.Logger
{
    public class Log
    {
        private decimal _elapsed;
        private decimal _totalElapsed;

        public DateTime TimeStamp { get; set; }
        public string Description { get; set; }

        public decimal TotalElapsedTimeSeconds
        {
            get => Math.Round(decimal.Parse(_totalElapsed.ToString(CultureInfo.InvariantCulture)) / 1000, 4);
            set => _totalElapsed = value;
        }

        public decimal ElapsedTimeSeconds
        {
            get => Math.Round(decimal.Parse(_elapsed.ToString(CultureInfo.InvariantCulture)) / 1000, 4);
            set => _elapsed = value;
        }

        public string TotalElapsedTimeText => $"{TotalElapsedTimeSeconds}";

        public string ElapsedTimeText => $"{ElapsedTimeSeconds}";
        public int Id { get; set; }
        public string LogId { get; set; }

        public override string ToString()
        {
            return
                $"{TimeStamp}  LogId: {LogId.Substring(0, 8)} Id: {Id} Elapsed: {ElapsedTimeText.PadRight(8, ' ')} TotalElapsed: {TotalElapsedTimeText.PadRight(8, ' ')}{nameof(Description)}: {Description}";
        }
    }
}