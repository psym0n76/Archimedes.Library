using System.Collections.Generic;

namespace Archimedes.Library.RabbitMq
{
    public interface IProducerFanout<T> where T : class
    {
        void PublishMessage(T message, string exchange);
        void PublishMessages(List<T> message, string exchange);

    }
}