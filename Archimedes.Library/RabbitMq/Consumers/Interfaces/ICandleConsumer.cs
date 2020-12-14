using System;
using System.Threading;

namespace Archimedes.Library.RabbitMq
{
    public interface ICandleConsumer
    {
        event EventHandler<CandleMessageHandlerEventArgs> HandleMessage;
        void Subscribe(CancellationToken cancellationToken, int delay);
    }
}