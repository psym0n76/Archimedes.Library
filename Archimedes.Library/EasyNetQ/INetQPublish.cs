using System.Threading.Tasks;

namespace Archimedes.Library.EasyNetQ
{
    public interface INetQPublish<T> where T : class
    {
        Task PublishMessage(T message);
    }
}
