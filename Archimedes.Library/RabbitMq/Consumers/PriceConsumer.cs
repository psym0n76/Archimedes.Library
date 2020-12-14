using System;
using System.Reflection;
using System.Text;
using System.Threading;
using Archimedes.Library.Message.Dto;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Archimedes.Library.RabbitMq
{
    public class PriceConsumer : IPriceConsumer
    {

        public event EventHandler<PriceMessageHandlerEventArgs> HandleMessage;

        private readonly string _host;
        private readonly int _port;
        private readonly string _exchange;
        private readonly string _queueName;

        public PriceConsumer(string host, int port, string exchange, string queueName)
        {
            _host = host;
            _port = port;
            _exchange = exchange;
            _queueName = queueName;
        }

        public void Subscribe(CancellationToken cancellationToken)
        {
            RabbitHealthCheck.ValidateConnection(_host, _port);

            var factory = new ConnectionFactory()
            {
                HostName = _host, Port = _port,
                ClientProvidedName = $"{Assembly.GetCallingAssembly().GetName().Name}.{_exchange}.{_queueName}"
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(_queueName, true, false, true);
            channel.ExchangeDeclare(_exchange, ExchangeType.Direct);

            channel.QueueBind(_queueName, _exchange, _queueName);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var price = JsonConvert.DeserializeObject<PriceDto>(message);
                HandleMessage?.Invoke(sender, new PriceMessageHandlerEventArgs() { Message = message, Price = price });

                channel.BasicAck(e.DeliveryTag, false);
            };

            channel.BasicConsume(_queueName,
                autoAck: false,
                consumer: consumer);

            while (!cancellationToken.IsCancellationRequested)
            {
                Thread.Sleep(5000);
            }
        }
    }
}