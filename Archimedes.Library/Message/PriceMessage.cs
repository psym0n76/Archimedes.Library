using System.Collections.Generic;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Message
{
    public class PriceMessage
    {
        public string Market { get; set; }

        public List<PriceDto> Prices { get; set; }

        public override string ToString()
        {
            return $"\n\n {nameof(PriceMessage)} {nameof(Market)}: {Market}\n";
        }
    }
}