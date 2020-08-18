using System.Reflection;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Archimedes.Library.RabbitMq
{
    public class CandleConsumer : ICandleConsumer
    {

        public event CandleMessageHandler HandleMessage;

        private readonly string _host;
        private readonly int _port;
        private readonly string _exchange;
        private readonly string _queue;


        public CandleConsumer(string host, int port, string exchange, string queue)
        {
            _host = host;
            _port = port;
            _exchange = exchange;
            _queue = queue;
        }

        public void Subscribe()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _host, Port = _port,
                ClientProvidedName = $"{Assembly.GetCallingAssembly().GetName().Name}.{_exchange}.{_queue}"
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(_exchange, ExchangeType.Direct);

            channel.QueueBind(_queue, _exchange, "");

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += Consumer_Received;

            channel.BasicConsume(_queue,
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
            HandleMessage?.Invoke(sender,new MessageHandlerEventArgs(){Message = message});
        }
    }
}