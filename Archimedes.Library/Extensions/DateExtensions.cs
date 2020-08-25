using System;

namespace Archimedes.Library.Extensions
{
    public static class DateExtensions
    {
        public static DateTime BrokerDate(this DateTime dte)
        {
            const string sDateFormat = "MM.dd.yyyy HH:mm:ss";

            //if (!DateTime.TryParseExact(dte.ToString(CultureInfo.InvariantCulture), sDateFormat, CultureInfo.InvariantCulture,
            //    DateTimeStyles.AssumeLocal, out var dateTime))
            //{
            //    return DateTime.MinValue;
            //}

            if (DateTime.TryParseExact(dte.ToString(), sDateFormat,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out var startDate))
            {
                return startDate;
            }

            return dte;
        }
    }
}