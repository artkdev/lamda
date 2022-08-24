using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace Entities
{
    public class InputEntity
    {
        [JsonProperty("userip")]
        public string? UserIp { get; set; }
        [JsonProperty("firstname")]
        public string? FirstName { get; set; }
        [JsonProperty("lastname")]
        public string? LastName { get; set; }
        [JsonProperty("email")]
        public string? Email { get; set; }
        [JsonProperty("password")]
        public string? Password { get; set; }
        [JsonProperty("phone")]
        public string? Phone { get; set; }
        [JsonProperty("globalization")]
        public string? Globalization { get; set; }
    }
}