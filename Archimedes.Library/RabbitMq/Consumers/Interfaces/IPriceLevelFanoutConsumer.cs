using System;
using RabbitMQ.Client.Events;

namespace Archimedes.Library.RabbitMq
{
    public interface IPriceLevelFanoutConsumer
    {
        event EventHandler<MessageHandlerEventArgs> HandleMessage;
        void Subscribe();

        void Consumer_Received(object sender, BasicDeliverEventArgs e);
    }
}