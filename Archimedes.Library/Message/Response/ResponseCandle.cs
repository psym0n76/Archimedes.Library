using System.Collections.Generic;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Message
{
    public class ResponseCandle : IResponse<CandleDto>
    {
        public string Text { get; set; }
        public string Status { get; set; }
        public List<CandleDto> Payload { get; set; }
        public RequestCandle Request { get; set; }

        public override string ToString()
        {
            var payload = "";

            foreach (var candleDto in Payload)
            {
                payload += $"\n{candleDto}";
            }

            return $"\nCandle Response:" +
                   $"\n{nameof(Text)}: {Text} " +
                   $"\n{nameof(Status)}: {Status} Rows: {Payload.Count} " +
                   $"\n{nameof(Payload)}: {payload}";

        }
    }
}