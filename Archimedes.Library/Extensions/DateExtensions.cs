using System;
using System.Globalization;

namespace Archimedes.Library.Extensions
{
    public static class DateExtensions
    {
        public static DateTime BrokerDate(this DateTime dte)
        {
            const string sDateFormat = "MM.dd.yyyy HH:mm:ss";

            if (!DateTime.TryParseExact(dte.ToString(CultureInfo.InvariantCulture), sDateFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.AssumeLocal, out var dateTime))
            {
                return DateTime.MinValue;
            }

            return dateTime;
        }


    }
}