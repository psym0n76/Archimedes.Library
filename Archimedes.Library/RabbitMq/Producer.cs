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
        private readonly string _exchange;

        public Producer(string host, int port, string exchange)
        {
            _host = host;
            _port = port;
            _exchange = exchange;
        }

        public void PublishMessage(T message, string queueName)
        {

            var factory = new ConnectionFactory()
            {
                HostName = _host, Port = _port,
                ClientProvidedName = $"{Assembly.GetCallingAssembly().GetName().Name}.{_exchange}.{queueName}"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queueName, true, false, false);
            channel.ExchangeDeclare(exchange: _exchange, type: ExchangeType.Direct);
            channel.QueueBind(queueName, _exchange, queueName);

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            channel.BasicPublish(exchange: _exchange,
                routingKey: "",
                basicProperties: null,
                body: body);
        }
    }
}