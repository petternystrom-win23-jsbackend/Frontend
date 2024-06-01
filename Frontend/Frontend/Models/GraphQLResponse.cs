using System.Text.Json.Serialization;
using System.Text.Json;

namespace Frontend.Models
{
    public class GraphQLResponse
    {
        [JsonPropertyName("data")]
        public JsonElement Data { get; set; }
    }
}
