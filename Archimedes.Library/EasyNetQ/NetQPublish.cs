using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using EasyNetQ;

namespace Archimedes.Library.EasyNetQ
{
    public class NetQPublish<T> : INetQPublish<T> where T : class
    {
        private readonly string _host;

        public NetQPublish(string host)
        {
            _host = host;
        }

        public async Task PublishMessage(T message)
        {
            using var bus = RabbitHutch.CreateBus(_host);
            await bus.PublishAsync(message);
        }
    }
}