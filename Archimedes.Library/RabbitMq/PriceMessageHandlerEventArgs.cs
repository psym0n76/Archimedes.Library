using System;
using Archimedes.Library.Message;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.RabbitMq
{
    public class PriceMessageHandlerEventArgs : EventArgs
    {
        public PriceMessage Message { get; set; }
        public PriceDto Price { get; set; }
    }
}