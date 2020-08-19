using System;

namespace Archimedes.Library.RabbitMq
{
    public class MessageHandlerEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}