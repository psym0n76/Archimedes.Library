using System;
using System.Threading;

namespace Archimedes.Library.RabbitMq
{
    public interface IPriceFanoutConsumer
    {
        event EventHandler<PriceMessageHandlerEventArgs> HandleMessage;
        void Subscribe(CancellationToken cancellationToken);

    }
}