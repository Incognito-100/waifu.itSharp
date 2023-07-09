using animuSharp.Client.Internals.DataTypes;
using animuSharp.Client.Internals.Enums;
using Newtonsoft.Json;

namespace animuSharp.Client
{
    /// <summary>
    /// main method for interacting with the api
    /// </summary>
    public class Client
    {
        private const string BaseUrl = "https://waifu.it/api";
        private string Key;
        private HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="apiKey">apiKey for making requests NOTE: it has a 5 requests/second rate-limit</param>
        public Client(string apiKey)
        {
            Key = apiKey;
            httpClient.DefaultRequestHeaders.Add("Authorization", Key);
        }

        /// <summary>
        /// Gets a URL of the desired content.
        /// </summary>
        /// <param name="content">The type of content you want to get, select from <see cref="ContentType"/>.</param>
        /// <returns>A URL of the selected item.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Data.Generic> GetURl(ContentType content)
        {
            string endpoint = $"/{content.ToString().ToLower()}";

            string nl = $"{BaseUrl}{endpoint}";

            return await GetResponse<Data.Generic>(nl).ConfigureAwait(false);
        }

        /// <summary>
        /// returns info about a random waifu
        /// </summary>
        /// <returns>A random waifu and associated info.</returns>
        public async Task<Data.Waifu> GetwaifuURl()
        {
            const string endpoint = $"/waifu";

            string end = $"{BaseUrl}{endpoint}";

            return await GetResponse<Data.Waifu>(end).ConfigureAwait(false);
        }

        //==========================================|make requests|==========================================
        /// <summary>
        /// Sends a request asynchronously.
        /// </summary>
        /// <param name="url">URL to get.</param>
        /// <typeparam name="T">Class to deserialize from JSON.</typeparam>
        /// <returns>JSON-deserialized class.</returns>
        private async Task<T> GetResponse<T>(string url)
        {
            var response = await httpClient.GetAsync(url).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Request failed with status code {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}