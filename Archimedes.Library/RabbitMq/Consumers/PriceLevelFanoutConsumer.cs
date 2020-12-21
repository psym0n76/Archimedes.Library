using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using Archimedes.Library.Message.Dto;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Archimedes.Library.RabbitMq
{
    public class PriceLevelFanoutConsumer : IPriceLevelFanoutConsumer
    {
        public event EventHandler<PriceLevelMessageHandlerEventArgs> HandleMessage;

        private readonly string _host;
        private readonly int _port;
        private readonly string _exchange;

        public PriceLevelFanoutConsumer(string host, int port, string exchange)
        {
            _host = host;
            _port = port;
            _exchange = exchange;
        }

        public void Subscribe(CancellationToken cancellationToken)
        {
            RabbitHealthCheck.ValidateConnection(_host, _port);

            var factory = new ConnectionFactory()
            {
                HostName = _host,
                Port = _port,
                ClientProvidedName = $"{Assembly.GetCallingAssembly().GetName().Name}.{_exchange}"
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();


            var queueName = channel.QueueDeclare(durable: false).QueueName;
            channel.ExchangeDeclare(_exchange, ExchangeType.Fanout);

            channel.QueueBind(queueName, _exchange, "");

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var price = JsonConvert.DeserializeObject<List<PriceLevelDto>>(message);
                HandleMessage?.Invoke(sender, new PriceLevelMessageHandlerEventArgs() {PriceLevels = price});

                channel.BasicAck(e.DeliveryTag, false);
            };

            channel.BasicConsume(queueName,
                autoAck: false,
                consumer: consumer);

            while (!cancellationToken.IsCancellationRequested)
            {
                Thread.Sleep(5000);
            }
        }
    }
}