using System;
using System.Threading;

namespace Archimedes.Library.RabbitMq
{
    public interface IPriceLevelFanoutConsumer
    {
        event EventHandler<PriceLevelMessageHandlerEventArgs> HandleMessage;
        void Subscribe(CancellationToken cancellationToken);
    }
}