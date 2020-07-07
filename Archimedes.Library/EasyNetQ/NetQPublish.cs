using System.Threading.Tasks;
using EasyNetQ;

namespace Archimedes.Library.EasyNetQ
{
    public class NetQPublish<T> : INetQPublish<T> where T : class
    {

        public async Task PublishMessage(T message,string host)
        {
            using var bus = RabbitHutch.CreateBus(host);
            await bus.PublishAsync(message);
        }
    }
}