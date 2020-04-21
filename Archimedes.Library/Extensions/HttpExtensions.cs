using System.Threading.Tasks;

namespace Archimedes.Library.Extensions
{
    public static class HttpExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this System.Net.Http.HttpContent content)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await content.ReadAsStringAsync());
        }
    }
}