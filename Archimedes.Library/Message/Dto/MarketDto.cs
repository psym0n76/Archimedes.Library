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
            return $"\nMarket Response:" +
                   $"\n{nameof(Name)}: {Name} " +
                   $"\n{nameof(TimeFrameInterval)}: {TimeFrameInterval}" +
                   $"\n{nameof(Active)}: {Active} " +
                   $"\n{nameof(MaxDate)}: {MaxDate} {nameof(LastUpdated)}: {LastUpdated}";
        }
    }
}