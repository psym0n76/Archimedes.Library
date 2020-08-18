using System;

namespace Archimedes.Library.RabbitMq
{
    public delegate void MessageHandler(object sender, MessageHandlerEventArgs args);

    public class MessageHandlerEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}