namespace Archimedes.Library.Types
{
    public class GranularityType
    {
        private GranularityType(string value) { Value = value; }

        public string Value { get; set; }

        public static GranularityType Minute => new GranularityType("min");
        public static GranularityType Hour => new GranularityType("H");
    }
}