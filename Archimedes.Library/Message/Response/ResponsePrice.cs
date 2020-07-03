using System.Collections.Generic;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Message
{
    public class ResponsePrice : IResponse<PriceDto>
    {
        private ResponsePrice()
        {
        }
        public string Text { get; set; }
        public string Status { get; set; }
        public List<PriceDto> Payload { get; set; }

        public override string ToString()
        {
            var payload = "";

            foreach (var priceDto in Payload)
            {
                payload += priceDto.ToString();
            }

            return $"Price Response Text: {Text} Status: {Status} Rows: {Payload} Payload: {payload}";
        }
    }
}