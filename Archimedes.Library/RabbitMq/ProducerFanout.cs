using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Archimedes.Library.RabbitMq
{
    public class ProducerFanout<T> : IProducerFanout<T> where T : class
    {
        private readonly string _host;
        private readonly int _port;

        public ProducerFanout(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void PublishMessage(T message, string exchange)
        {
            RabbitHealthCheck.ValidateConnection(_host, _port);

            var factory = new ConnectionFactory()
            {
                HostName = _host, Port = _port,
                ClientProvidedName = $"{Assembly.GetCallingAssembly().GetName().Name}.{exchange}"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: exchange, type: ExchangeType.Fanout, autoDelete:true);

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            channel.BasicPublish(exchange: exchange,
                routingKey: "",
                basicProperties: null,
                body: body);
        }


        public void PublishMessages(List<T> messages, string exchange)
        {
            RabbitHealthCheck.ValidateConnection(_host, _port);

            var factory = new ConnectionFactory()
            {
                HostName = _host,
                Port = _port,
                ClientProvidedName = $"{Assembly.GetCallingAssembly().GetName().Name}.{exchange}"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: exchange, type: ExchangeType.Fanout, autoDelete: true);

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(messages));

            channel.BasicPublish(exchange: exchange,
                routingKey: "",
                basicProperties: null,
                body: body);
        }
    }
}