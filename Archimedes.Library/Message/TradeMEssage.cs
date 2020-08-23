﻿using System.Collections.Generic;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Message
{
    public class TradeMessage
    {
        public string Text { get; set; }
        public List<string> Properties { get; set; }
        public string Market { get; set; }

        public List<TradeDto> Trades { get; set; }

        public override string ToString()
        {
            return $"\n {nameof(TradeMessage)}" +
                   $"\n  {nameof(Market)}: {Market} {nameof(Text)}: {Text}";
        }
    }
}