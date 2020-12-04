using System;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.RabbitMq
{
    public class CandleMessageHandlerEventArgs : EventArgs
    {
        public string Message { get; set; }
        public CandleDto Candle { get; set; }
    }
}