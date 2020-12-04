using System;
using System.Threading;

namespace Archimedes.Library.RabbitMq
{
    public interface IPriceLevelConsumer
    {
        event EventHandler<PriceLevelMessageHandlerEventArgs> HandleMessage;
        void Subscribe(CancellationToken cancellationToken);
    }
}