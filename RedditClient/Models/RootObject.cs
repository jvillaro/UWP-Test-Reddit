using Newtonsoft.Json;

namespace RedditClient.Models
{
    /// <summary>
    /// Model of the root node of the listings response Json
    /// </summary>
    public class RootObject
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("data")]
        public RootData Data { get; set; }
    }
}
