using animuSharp.Client.Internals.DataTypes;
using animuSharp.Client.Internals.Enums;
using Newtonsoft.Json;
using System.Net.Mime;
using ContentType = animuSharp.Client.Internals.Enums.ContentType;

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
        public async Task<object> GetURl(ContentType content)
        {
            string endpoint = $"/{content.ToString().ToLower()}";

            string nl = $"{BaseUrl}{endpoint}";

            switch (content)
            {
                case ContentType.fact:
                    return await GetResponse<Data.Fact>(nl).ConfigureAwait(false);

                case ContentType.Waifu:
                    return await GetResponse<Data.Waifu>(nl).ConfigureAwait(false);

                case ContentType.password:
                    return await GetResponse<Data.Password>(nl).ConfigureAwait(false);

                case ContentType.quote:
                    return await GetResponse<Data.Quote>(nl).ConfigureAwait(false);

                case ContentType.owoify:
                    return await GetResponse<Data.Text>(nl).ConfigureAwait(false);

                case ContentType.uwuify:
                    return await GetResponse<Data.Text>(nl).ConfigureAwait(false);

                default:
                    return await GetResponse<Data.Generic>(nl).ConfigureAwait(false);
            }
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