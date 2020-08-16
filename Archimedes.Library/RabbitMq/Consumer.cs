using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Archimedes.Library.RabbitMq
{
    public class Consumer : IConsumer
    {
        // todo add sender/this
        public delegate void RabbitMqMessageHandler(RabbitMqMessageArgs args);
        public event RabbitMqMessageHandler HandleMessage;

        public void Subscribe(string queueName, string exchange, int port)
        {
            var factory = new ConnectionFactory() {HostName = "localhost", Port = port};
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
            }

        }

        private  void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            //invoke a event
            HandleMessage?.Invoke(new RabbitMqMessageArgs(){Message = message});
        }
    }

    public class RabbitMqMessageArgs
    {
        public string Message { get; set; }
    }
}