using System.Threading.Tasks;

namespace Archimedes.Library.Extensions
{
    // https://stackoverflow.com/questions/10399324/where-is-httpcontent-readasasync
    public static class HttpExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this System.Net.Http.HttpContent content)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await content.ReadAsStringAsync());
        }
    }
}