namespace Archimedes.Library.RabbitMq
{
    public interface IProducer<T> where T : class
    {
        void PublishMessage(string queueName, string exchange, T message);
    }
}