using System.Collections.Generic;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Message
{
    public class ResponseCandle:IResponse
    {
        public string Text { get; set; }
        public string Status { get; set; }
        public List<CandleDto> Payload { get; set; }
    }
}