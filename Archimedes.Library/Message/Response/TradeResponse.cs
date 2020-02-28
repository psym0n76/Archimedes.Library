using System.Collections.Generic;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Message
{
    public class TradeResponse : IResponse<TradeDto>
    {
        public string Text { get; set; }
        public string Status { get; set; }
        public List<TradeDto> Payload { get; set; }
    }
}