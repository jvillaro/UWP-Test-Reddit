using Newtonsoft.Json;
using System.Collections.Generic;

namespace RedditClient.Models
{
    /// <summary>
    /// Model of the data object of the root node
    /// </summary>
    public class RootData
    {
        [JsonProperty("modhash")]
        public string ModHash { get; set; }

        [JsonProperty("dist")]
        public string Dist { get; set; }

        [JsonProperty("children")]
        public List<Child> Children { get; set; }

        [JsonProperty("after")]
        public string After { get; set; }

        [JsonProperty("before")]
        public string Before { get; set; }
    }
}
