using System;
using System.Threading;

namespace Archimedes.Library.RabbitMq
{
    public interface IStrategyConsumer
    {
        event EventHandler<MessageHandlerEventArgs> HandleMessage;
        void Subscribe(CancellationToken cancellationToken, int delay);
        //void Consumer_Received(object sender, BasicDeliverEventArgs e);
    }
}