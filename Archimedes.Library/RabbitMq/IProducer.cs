namespace Archimedes.Library.RabbitMq
{
    public interface IProducer
    {
        void PublishMessage(string queueName, string exchange, object message, string host, int port);
    }
}