using System;

namespace Archimedes.Library.RabbitMq
{
    public interface IPriceLevelConsumer
    {
        event EventHandler<MessageHandlerEventArgs> HandleMessage;
        void Subscribe();
    }
}