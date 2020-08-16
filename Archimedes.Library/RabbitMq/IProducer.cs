namespace Archimedes.Library.RabbitMq
{
    public interface IProducer
    {
        void PublishMessage(string queueName, string exchange, string message, string host, int port);
    }
}