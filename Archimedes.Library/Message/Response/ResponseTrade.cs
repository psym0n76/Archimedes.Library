﻿using System.Collections.Generic;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Message
{
    public class ResponseTrade : IResponse<TradeDto>
    {
        public string Text { get; set; }
        public string Status { get; set; }
        public List<TradeDto> Payload { get; set; }

        public override string ToString()
        {
            var payload = "";

            foreach (var tradeDto in Payload)
            {
                payload += $"\n{tradeDto}";
            }

            return $"Trade Response Text: {Text} Status: {Status} Rows: {Payload} Payload: {payload}";
        }
    }
}