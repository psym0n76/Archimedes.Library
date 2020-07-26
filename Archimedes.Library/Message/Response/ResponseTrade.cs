using System.Collections.Generic;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Message
{
    public class ResponseTrade : IResponse<TradeDto>
    {
        public string Text { get; set; }
        public string Status { get; set; }
        public List<TradeDto> Payload { get; set; }
        public RequestTrade Request { get; set; }

        public override string ToString()
        {
            var payload = "";

            foreach (var tradeDto in Payload)
            {
                payload += $"\n{tradeDto}";
            }

            return $"\n {nameof(ResponseTrade)}" +
                   $"\n  {nameof(Text)}: {Text} {nameof(Status)}: {Status} Rows: {Payload.Count} " +
                   $"\n  {nameof(Payload)}: {payload}";
        }
    }
}