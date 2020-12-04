using System;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.RabbitMq
{
    public class PriceMessageHandlerEventArgs : EventArgs
    {
        public string Message { get; set; }
        public PriceDto Price { get; set; }
    }
}