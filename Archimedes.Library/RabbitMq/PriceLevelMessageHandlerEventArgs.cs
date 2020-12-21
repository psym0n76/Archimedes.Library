using System;
using System.Collections.Generic;
using Archimedes.Library.Message;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.RabbitMq
{
    public class PriceLevelMessageHandlerEventArgs : EventArgs
    {
        public List<PriceLevelDto> PriceLevels { get; set; }
        public PriceLevelMessage Message { get; set; }
    }
}