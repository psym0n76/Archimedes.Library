using System;
using System.Collections.Generic;
using Archimedes.Library.Message;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.RabbitMq
{
    public class PriceMessageHandlerEventArgs : EventArgs
    {
        public PriceMessage Message { get; set; }
        public List<PriceDto> Prices { get; set; }
    }
}