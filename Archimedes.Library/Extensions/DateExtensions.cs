using System;

namespace Archimedes.Library.Extensions
{
    public static class DateExtensions
    {
        public static DateTime BrokerDate(this DateTime dte)
        {
            const string sDateFormat = "MM.dd.yyyy HH:mm:ss";

            if (DateTime.TryParseExact(dte.ToString(), sDateFormat,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out var startDate))
            {
                return startDate;
            }

            return dte;
        }

        public static DateTime PreviousWorkDay(this DateTime date)
        {
            do
            {
                date = date.AddDays(-1);
            }
            while (IsHoliday(date) || IsWeekend(date));

            return date;
        }

        private static bool IsHoliday(DateTime date)
        {
            return false;
        }

        private static bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday ||
                   date.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}