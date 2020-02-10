using Newtonsoft.Json;
using RedditClient.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RedditClient.Helpers
{
    /// <summary>
    /// Helper class for HTTP calls
    /// </summary>
    public static class HttpHelper
    {
        #region --- Uri Constants ---

        public const string baseUrl = "https://www.reddit.com";
        public const string Top50Uri = "/top/.json?limit=50";

        #endregion


        #region --- Variables ---

        private static HttpClient httpClient;

        #endregion


        #region --- Create HTTP Client ---

        /// <summary>
        /// Creates and configures the HTTP client
        /// </summary>
        private static void CreateHttpClient()
        {
            // Disables the default cache
            if (httpClient != null)
            {
                httpClient.DefaultRequestHeaders.IfModifiedSince = DateTimeOffset.Now;
            }
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.IfModifiedSince = DateTimeOffset.Now;
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.Timeout = new TimeSpan(0, 0, 5, 0);
        }

        #endregion


        #region --- GetAsync ---

        /// <summary>
        /// Executes a GET method to the API
        /// </summary>
        private static async Task<T> GetAsync<T>(string uri, JsonSerializerSettings settings = null)
        {
            try
            {
                CreateHttpClient();

                var result = await httpClient.GetAsync(uri);
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception($"Error in GetAsync: {result.StatusCode}");
                }
                var response = await result.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<T>(response);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region --- GetTop50Listings ---

        /// <summary>
        /// Get top 50 reddit posts
        /// </summary>
        /// <returns></returns>
        public static async Task<ObservableCollection<RedditPostData>> GetTop50Listings()
        {
            var rootData = await GetAsync<RootObject>($"{baseUrl}{Top50Uri}");

            var posts = rootData.Data.Children.Select(x => x.Data).ToList();

            return new ObservableCollection<RedditPostData>(posts);
        }

        #endregion
    }
}
