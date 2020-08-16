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

        public void Subscribe(string queueName, string exchange, string host, int port)
        {
            var factory = new ConnectionFactory()
            {
                HostName = host, Port = port,
                ClientProvidedName = $"{Assembly.GetCallingAssembly().GetName().Name}.{exchange}.{queueName}"
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange, ExchangeType.Direct);

            channel.QueueBind(queueName, exchange, "");

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