using System;
using System.Collections.Generic;
using Archimedes.Library.Message;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.RabbitMq
{
    public class CandleMessageHandlerEventArgs : EventArgs
    {
        public CandleMessage Message { get; set; }
        public List<CandleDto> Candles { get; set; }
    }
}