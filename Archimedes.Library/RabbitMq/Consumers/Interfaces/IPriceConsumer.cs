using System;
using System.Threading;

namespace Archimedes.Library.RabbitMq
{
    public interface IPriceConsumer
    {
        event EventHandler<PriceMessageHandlerEventArgs> HandleMessage;
        void Subscribe(CancellationToken cancellationToken);
    }
}