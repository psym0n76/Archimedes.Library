using System;
using System.Threading;

namespace Archimedes.Library.RabbitMq
{
    public interface IConsumer
    {
        event EventHandler<MessageHandlerEventArgs> HandleMessage;
        void Subscribe(CancellationToken cancellationToken);
    }
}