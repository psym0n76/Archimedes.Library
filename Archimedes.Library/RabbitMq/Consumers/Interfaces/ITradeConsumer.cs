namespace Archimedes.Library.RabbitMq
{
    public interface ITradeConsumer
    {
        event TradeMessageHandler HandleMessage;
        void Subscribe();
    }
}