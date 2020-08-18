namespace Archimedes.Library.RabbitMq
{
    public interface IPriceConsumer
    {
        event PriceMessageHandler HandleMessage;
    }
}