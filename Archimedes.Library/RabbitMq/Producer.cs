using System.Reflection;
using System.Text;
using RabbitMQ.Client;

namespace Archimedes.Library.RabbitMq
{
    public class Producer : IProducer
    {
        public void PublishMessage(string queueName, string exchange, string message, string host, int port)
        {
            var factory = new ConnectionFactory()
                {HostName = host, Port = port, ClientProvidedName = $"{Assembly.GetCallingAssembly().GetName().Name}.{exchange}.{queueName}"};

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queueName, true, false, false);
            channel.ExchangeDeclare(exchange: exchange, type: ExchangeType.Direct);
            channel.QueueBind(queueName, exchange, "");

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: exchange,
                routingKey: "",
                basicProperties: null,
                body: body);
        }
    }
}