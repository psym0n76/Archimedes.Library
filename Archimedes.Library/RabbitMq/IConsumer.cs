namespace Archimedes.Library.RabbitMq
{
    public interface IConsumer
    {
        event MessageHandler HandleMessage;
        void Subscribe();
    }
}