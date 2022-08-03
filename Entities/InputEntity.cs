using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace Entities
{
    public class InputEntity
    {
        [JsonProperty("url")]
        public string? Url { get; set; }
        [JsonProperty("username")]
        public string? Username { get; set; }
        [JsonProperty("password")]
        public string? Password { get; set; }
        [JsonProperty("apiKey")]
        public string? ApiKey { get; set; }

        [JsonProperty("body")]
        public JsonObject? Body { get; set; }
    }
}