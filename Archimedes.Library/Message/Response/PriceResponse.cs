using System.Collections.Generic;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Message
{
    public class PriceResponse : IResponse<PriceDto>
    {
        public string Text { get; set; }
        public string Status { get; set; }
        public List<PriceDto> Payload { get; set; }
    }
}