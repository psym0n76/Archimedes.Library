using Newtonsoft.Json;

namespace Archimedes.Library.Message.Dto
{
    public class TradeDto
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "open")]
        public string Open { get; set; }
    }
}