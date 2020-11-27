using System.Linq;
using static System.Char;

namespace Archimedes.Library.Extensions
{
    public static class StringExtensions
    {
        public static string ExtractTimeDenominator(this string value)
        {
            var letters = value.Where(IsNumber).Aggregate(string.Empty, (current, c) => current + c);

            return letters.ToString();
        }

        public static  int ExtractTimeInterval(this string value)
        {
            var numbers = value.Where(IsNumber).Aggregate(string.Empty, (current, c) => current + c);

            return int.Parse(numbers);
        }
    }
}