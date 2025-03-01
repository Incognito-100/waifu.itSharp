using animuSharp.Client.Internals.DataTypes;
using animuSharp.Client.Internals.Enums;
using Newtonsoft.Json;
using System.Net;
using System.Web;

namespace animuSharp.Client
{
    /// <summary>
    ///     main method for interacting with the api
    /// </summary>
    /// <remarks>
    ///     Initializes a new instance of the <see cref="Client" /> class.
    /// </remarks>
    /// <param name="apiKey">apiKey for making requests NOTE: it has a5 requests/second rate-limit</param>
    public class Client(string apiKey)
    {
        private const string BaseUrl = "https://waifu.it/api/v4";
        private static readonly HttpClient HttpClient = new();
        private readonly string _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));

        /// <summary>
        ///     Gets a URL of the desired content for image-based requests.
        /// </summary>
        public async Task<Data.Generic> GetURl(ImageContentType content)
        {
            string endpoint = $"{BaseUrl}/{content.ToString().ToLower()}";
            return await GetResponse<Data.Generic>(endpoint).ConfigureAwait(false);
        }

        /// <summary>
        ///     Gets a URL of the desired content for text-based requests.
        /// </summary>
        public async Task<Data.Text> GetURl(string text, Textypes content)
        {
            string encodedText = Uri.EscapeDataString(text);
            string endpoint = $"{BaseUrl}/{content.ToString().ToLower()}?text={encodedText}";
            return await GetResponse<Data.Text>(endpoint).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a waifu character and their information.
        /// </summary>
        public async Task<Data.Waifu> GetWaifu(string name = null, string anime = null)
        {
            string queryString = $"{BaseUrl}/waifu{GetQueryString(name, anime, "name", "anime")}";
            return await GetResponse<Data.Waifu>(queryString).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a husbando character and their information.
        /// </summary>
        public async Task<Data.Husbando> GetHusbando(string name = null, string anime = null)
        {
            string queryString = $"{BaseUrl}/husbando{GetQueryString(name, anime, "name", "anime")}";
            return await GetResponse<Data.Husbando>(queryString).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets an anime quote, optionally filtered by character or anime.
        /// </summary>
        public async Task<Data.Quote> GetQuote(string character = null, string anime = null)
        {
            string queryString = $"{BaseUrl}/quote{GetQueryString(character, anime, "character", "anime")}";
            return await GetResponse<Data.Quote>(queryString).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a random anime fact.
        /// </summary>
        public async Task<Data.Fact> GetFact()
        {
            string endpoint = $"{BaseUrl}/fact";
            return await GetResponse<Data.Fact>(endpoint).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a random password.
        /// </summary>
        public async Task<Data.Password> GetPassword()
        {
            string endpoint = $"{BaseUrl}/password";
            return await GetResponse<Data.Password>(endpoint).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets available tags for specific queries.
        /// </summary>
        public async Task<Data.Generic> GetTags()
        {
            string endpoint = $"{BaseUrl}/tags";
            return await GetResponse<Data.Generic>(endpoint).ConfigureAwait(false);
        }

        private static string GetQueryString(string name, string anime, string param1, string param2)
        {
            var queryParams = new List<string>();

            if (!string.IsNullOrEmpty(name))
            {
                string f = $"{param1}={HttpUtility.UrlEncode(name)}";
                queryParams.Add(f);
            }

            if (!string.IsNullOrEmpty(anime))
            {
                string f = $"{param2}={HttpUtility.UrlEncode(anime)}";
                queryParams.Add(f);
            }

            if (queryParams.Count != 0)
            {
                return $"?{string.Join("&", queryParams)}";
            }

            return string.Empty;
        }

        private async Task<T> GetResponse<T>(string url)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                {
                    {
                        "Authorization", _apiKey
                    }
                },
            };

            var response = await HttpClient.SendAsync(request);

            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    throw new Exception("Not Found");

                case HttpStatusCode.OK:
                    break;

                case HttpStatusCode.Forbidden:
                    throw new Exception("You've exhausted your request limits");

                case HttpStatusCode.InternalServerError:
                    throw new Exception("Internal Server Error");
            }

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}