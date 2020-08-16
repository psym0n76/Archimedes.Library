using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Archimedes.Library.RabbitMq
{
    public class Producer<T> : IProducer<T> where T : class
    {
        private readonly string _host;
        private readonly int _port;

        public Producer(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void PublishMessage(string queueName, string exchange, T message)
        {

            var factory = new ConnectionFactory()
            {
                HostName = _host, Port = _port,
                ClientProvidedName = $"{Assembly.GetCallingAssembly().GetName().Name}.{exchange}.{queueName}"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queueName, true, false, false);
            channel.ExchangeDeclare(exchange: exchange, type: ExchangeType.Direct);
            channel.QueueBind(queueName, exchange, "");

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            channel.BasicPublish(exchange: exchange,
                routingKey: "",
                basicProperties: null,
                body: body);
        }
    }
}