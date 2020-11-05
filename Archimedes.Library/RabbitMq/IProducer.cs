namespace Archimedes.Library.RabbitMq
{
    public interface IProducer<T> where T : class
    {
        void PublishMessage(T message, string queueName);
        void PublishFanoutMessage(T message);
    }
}