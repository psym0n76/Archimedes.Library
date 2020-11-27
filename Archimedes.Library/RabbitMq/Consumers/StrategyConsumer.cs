﻿using System;
using System.Reflection;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Archimedes.Library.RabbitMq
{
    public class StrategyConsumer : IStrategyConsumer
    {

        public event EventHandler<MessageHandlerEventArgs> HandleMessage;

        private readonly string _host;
        private readonly int _port;
        private readonly string _exchange;
        private readonly string _queueName;

        public StrategyConsumer(string host, int port, string exchange, string queueName)
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

            channel.QueueDeclare(_queueName, true, false, false);
            channel.ExchangeDeclare(_exchange, ExchangeType.Direct);

            channel.QueueBind(_queueName, _exchange, _queueName);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += Consumer_Received;

            channel.BasicConsume(_queueName,
                autoAck: true,
                consumer: consumer);

            while (true)
            {
                Thread.Sleep(5000);
            }
        }

        public void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            HandleMessage?.Invoke(sender, new MessageHandlerEventArgs() {Message = message});
        }
    }
}