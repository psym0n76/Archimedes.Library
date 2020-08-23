using System.Collections.Generic;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Message
{
    public class PriceMessage
    {
        public string Text { get; set; }
        public List<string> Properties { get; set; }
        public string Market { get; set; }

        public List<PriceDto> Prices { get; set; }

        public override string ToString()
        {
            return $"\n {nameof(PriceMessage)}" +
                   $"\n  {nameof(Market)}: {Market} {nameof(Text)}: {Text}";
        }
    }
}