using System;

namespace Archimedes.Library.Message.Dto
{
    /// <summary>
    /// The historical candle entity.
    /// </summary>
    public class CandleDto
    {
        /// <summary>
        /// The candle timestamp.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The candle BidOpen price.
        /// </summary>
        public double BidOpen { get; set; }

        /// <summary>
        /// The candle BidClose price.
        /// </summary>
        public double BidClose { get; set; }

        /// <summary>
        /// The candle BidHigh price.
        /// </summary>
        public double BidHigh { get; set; }

        /// <summary>
        /// The candle BidLow price.
        /// </summary>
        public double BidLow { get; set; }

        /// <summary>
        /// The candle AskOpen price.
        /// </summary>
        public double AskOpen { get; set; }

        /// <summary>
        /// The candle AskClose price.
        /// </summary>
        public double AskClose { get; set; }

        /// <summary>
        /// The candle BidHigh price.
        /// </summary>
        public double AskHigh { get; set; }

        /// <summary>
        /// The candle AskLow price.
        /// </summary>
        public double AskLow { get; set; }

        /// <summary>
        /// The candle tick quantity value.
        /// </summary>
        public double TickQty { get; set; }
    }
}