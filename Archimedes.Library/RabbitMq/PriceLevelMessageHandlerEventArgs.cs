using System;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.RabbitMq
{
    public class PriceLevelMessageHandlerEventArgs : EventArgs
    {
        public string Message { get; set; }
        public PriceLevelDto PriceLevel { get; set; }
    }
}