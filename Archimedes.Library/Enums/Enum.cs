using System.ComponentModel;

namespace Archimedes.Library.Enums
{
    public enum Market
    {
        [Description("GbpUsd")]
        Gbpusd,
        [Description("EurUsd")]
        Eurusd
    }

    public enum TimeFrame
    {
        [Description("OneMinute")]
        OneMinute,
        [Description("FiveMinute")]
        FiveMinute,
        [Description("FifteenMinute")]
        FifteenMinute,
        [Description("OneHour")]
        OneHour
    }

    public enum CandleType
    {
        [Description("Doji")]
        Doji,
        [Description("Engulfing")]
        Engulfing,
        [Description("Null")]
        Null
    }

    public enum Colour
    {
        [Description("Green")]
        Green,
        [Description("Red")]
        Red,
        [Description("Black")]
        Black
    }
}