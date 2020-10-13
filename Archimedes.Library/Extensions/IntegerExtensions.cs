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
    }
}