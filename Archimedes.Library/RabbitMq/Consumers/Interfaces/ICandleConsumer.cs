namespace Archimedes.Library.RabbitMq
{
    public interface ICandleConsumer
    {
        event CandleMessageHandler HandleMessage;
    }
}