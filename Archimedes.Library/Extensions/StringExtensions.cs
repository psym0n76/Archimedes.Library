using System;
using System.Linq;
using Archimedes.Library.Enums;
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
            if (value == null)
            {
                return 0;
            }

            var numbers = value.Where(IsNumber).Aggregate(string.Empty, (current, c) => current + c);

            return int.Parse(numbers);
        }

        public static Colour Color(this string buySell)
        {
            return buySell == "buy" ? Colour.Green : Colour.Red;
        }
    }
}