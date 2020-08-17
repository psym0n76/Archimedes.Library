namespace Archimedes.Library.RabbitMq
{
    public interface IConsumer
    {
        event Consumer.RabbitMqMessageHandler HandleMessage;
        void Subscribe(string queueName);
    }
}