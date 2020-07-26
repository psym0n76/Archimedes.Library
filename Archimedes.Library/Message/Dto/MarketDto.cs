using System;

namespace Archimedes.Library.Message.Dto
{
    public class MarketDto
    {
        public string Name { get; set; }
        public int Interval { get; set; }
        public string TimeFrame { get; set; }
        public bool Active { get; set; }
        public DateTime MaxDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public string TimeFrameInterval => $"{Interval}{TimeFrame}";

        public override string ToString()
        {
            return $"\n Market dto:" +
                   $"\n  {nameof(Name)}: {Name} {nameof(TimeFrameInterval)}: {TimeFrameInterval} {nameof(Active)}: {Active} " +
                   $"\n  {nameof(MaxDate)}: {MaxDate} {nameof(LastUpdated)}: {LastUpdated}";
        }
    }
}