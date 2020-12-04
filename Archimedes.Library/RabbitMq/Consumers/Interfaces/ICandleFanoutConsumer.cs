using System;
using System.Threading;
using RabbitMQ.Client.Events;

namespace Archimedes.Library.RabbitMq
{
    public interface ICandleFanoutConsumer
    {
        event EventHandler<CandleMessageHandlerEventArgs> HandleMessage;
        void Subscribe(CancellationToken cancellationToken);

        void Consumer_Received(object sender, BasicDeliverEventArgs e);
    }
}