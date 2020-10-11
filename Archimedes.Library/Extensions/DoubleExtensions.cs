using System.Globalization;

namespace Archimedes.Library.Extensions
{
    public static class DoubleExtensions
    {
        public static decimal ToDecimal(this double value)
        {
            return decimal.Parse(value.ToString(CultureInfo.InvariantCulture));
        }
    }
}