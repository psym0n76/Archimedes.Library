using System;
using RabbitMQ.Client.Events;

namespace Archimedes.Library.RabbitMq
{
    public interface IPriceConsumer
    {
        event EventHandler<PriceMessageHandlerEventArgs> HandleMessage;
        void Subscribe();
        void Consumer_Received(object sender, BasicDeliverEventArgs e);
    }
}