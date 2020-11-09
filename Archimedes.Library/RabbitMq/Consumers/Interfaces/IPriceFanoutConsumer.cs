using System;

namespace Archimedes.Library.RabbitMq
{
    public interface IPriceFanoutConsumer
    {
        event EventHandler<MessageHandlerEventArgs> HandleMessage;
        void Subscribe();
    }
}