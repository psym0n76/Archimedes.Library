using System;
using System.Threading;
using RabbitMQ.Client;

namespace Archimedes.Library.RabbitMq
{
    public static class RabbitHealthCheck
    {
        public static void ValidateConnection(string host, int port)
        {
            var retry = 0;

            while (!ConnectionSuccessful(host, port) && retry < 10)
            {
                Thread.Sleep(2000);
                retry++;
            }

            if (retry == 10)
            {
                throw new ApplicationException(
                    $"Unable to connect to RabbitMQ Host:{host} Port:{port} - Max Retries hit 10");
            }
        }

        private static bool ConnectionSuccessful(string host, int port)
        {
            var factory = new ConnectionFactory {HostName = host, Port = port};
            try
            {
                var conn = factory.CreateConnection();
                conn.Close();
                conn.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}