using System.Collections.Generic;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Message
{
    public class ResponseCandle : IResponse<CandleDto>
    {
        public string Text { get; set; }
        public string Status { get; set; }
        public List<CandleDto> Payload { get; set; }

        public override string ToString()
        {
            var payload = "";

            foreach (var candleDto in Payload)
            {
                payload += $"/n {candleDto}";
            }

            return $"Candle Response Text: {Text} Status: {Status} Rows: {Payload.Count} Payload: {payload}";
        }
    }
}