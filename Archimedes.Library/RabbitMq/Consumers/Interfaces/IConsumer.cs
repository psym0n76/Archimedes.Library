using System;

namespace Archimedes.Library.RabbitMq
{
    public interface IConsumer
    {
        event EventHandler<MessageHandlerEventArgs> HandleMessage;
        void Subscribe();
    }
}