using System.Reflection;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Archimedes.Library.RabbitMq
{
    public class Consumer : IConsumer
    {
        public delegate void RabbitMqMessageHandler(string message);

        public event RabbitMqMessageHandler HandleMessage;

        private readonly string _host;
        private readonly int _port;
        private readonly string _exchange;

        public Consumer(string host, int port, string exchange)
        {
            _host = host;
            _port = port;
            _exchange = exchange;
        }

        public void Subscribe(string queueName)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _host, Port = _port,
                ClientProvidedName = $"{Assembly.GetCallingAssembly().GetName().Name}.{_exchange}.{queueName}"
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(_exchange, ExchangeType.Direct);

            channel.QueueBind(queueName, _exchange, "");

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += Consumer_Received;

            channel.BasicConsume(queueName,
                autoAck: true,
                consumer: consumer);

            while (true)
            {
                Thread.Sleep(5000);
            }
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            HandleMessage?.Invoke(message);
        }
    }
}