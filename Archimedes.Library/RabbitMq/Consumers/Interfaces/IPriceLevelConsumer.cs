using System;

namespace Archimedes.Library.RabbitMq
{
    public interface IPriceLevelConsumer
    {
        event EventHandler<PriceLevelMessageHandlerEventArgs> HandleMessage;
        void Subscribe();
    }
}