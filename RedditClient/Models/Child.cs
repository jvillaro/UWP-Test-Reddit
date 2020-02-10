using Newtonsoft.Json;

namespace RedditClient.Models
{
    /// <summary>
    /// Model of the child object list in the root data
    /// </summary>
    public class Child
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("data")]
        public RedditPostData Data { get; set; }
    }
}
