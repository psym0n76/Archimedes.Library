namespace Archimedes.Library.RabbitMq
{
    public interface IProducerFanout<T> where T : class
    {
        void PublishMessage(T message);
    }
}