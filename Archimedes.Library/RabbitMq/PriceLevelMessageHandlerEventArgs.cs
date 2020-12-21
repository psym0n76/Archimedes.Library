using System;
using System.Collections.Generic;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.RabbitMq
{
    public class PriceLevelMessageHandlerEventArgs : EventArgs
    {
        //public string Message { get; set; }
        public List<PriceLevelDto> PriceLevels { get; set; }

    }
}