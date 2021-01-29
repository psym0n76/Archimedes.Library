using System;

namespace Archimedes.Library.Extensions
{
    public static class IntegerExtensions
    {
        public static int ToMinutes(this int value, string timeFrame)
        {
            return value * GetMinutes(timeFrame);
        }

        private static int GetMinutes(string timeFrame)
        {
            return timeFrame switch
            {
                "Min" => 1,
                "H" => 60,
                "D" => 1440,
                _ => 1,
            };
        }

        public static int Round(this int i, int nearest)
        {
            if (nearest <= 0 || nearest % 10 != 0)
                throw new ArgumentOutOfRangeException("nearest", "Must round to a positive multiple of 10");

            return (i + 5 * nearest / 10) / nearest * nearest;
        }
    }
}