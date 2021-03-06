﻿using System;
using System.Reflection;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Archimedes.Library.RabbitMq
{
    public class Consumer : IConsumer
    {

        public event EventHandler<MessageHandlerEventArgs> HandleMessage;

        private readonly string _host;
        private readonly int _port;
        private readonly string _exchange;
        private readonly string _queue;

        public Consumer(string host, int port, string exchange, string queue)
        {
            _host = host;
            _port = port;
            _exchange = exchange;
            _queue = queue;
        }

        public void Subscribe(CancellationToken cancellationToken)
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

            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                HandleMessage?.Invoke(sender, new MessageHandlerEventArgs() { Message = message });

                channel.BasicAck(e.DeliveryTag, false);
            };

            channel.BasicConsume(_queue,
                autoAck: false,
                consumer: consumer);

            while (!cancellationToken.IsCancellationRequested)
            {
                Thread.Sleep(5000);
            }
        }
    }
}