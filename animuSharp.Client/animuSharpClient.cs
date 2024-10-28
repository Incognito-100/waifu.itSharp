﻿using animuSharp.Client.Internals.DataTypes;
using animuSharp.Client.Internals.Enums;
using Newtonsoft.Json;
using System.Net;
using System.Web;

namespace animuSharp.Client
{
    /// <summary>
    /// main method for interacting with the api
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Client"/> class.
    /// </remarks>
    /// <param name="apiKey">apiKey for making requests NOTE: it has a5 requests/second rate-limit</param>
    public class Client(string apiKey)
    {
        private const string BaseUrl = "https://waifu.it/api/v4";
        private static readonly HttpClient HttpClient = new();
        private readonly string _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));

        /// <summary>
        ///Gets a URL of the desired content for image-based requests..
        /// </summary>
        public async Task<Data.Generic> GetURl(ImageContentType content)
        {
            string endpoint = $"{BaseUrl}/{content.ToString().ToLower()}";

            return await GetResponse<Data.Generic>(endpoint).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a URL of the desired content for text-based requests.
        /// </summary>
        public async Task<Data.Text> GetURl(string text, Textypes content)
        {
            string encodedText = Uri.EscapeDataString(text);

            string endpoint = $"{BaseUrl}/{content.ToString().ToLower()}?text={encodedText}";

            return await GetResponse<Data.Text>(endpoint).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a URL of the desired content for miscellaneous requests (waifu, husbando, quote).
        /// </summary>
        public async Task<T> GetURl<T>(Misc content, string name = null, string anime = null)
        {
            string queryString = $"{BaseUrl}/{content.ToString().ToLower()}";

            switch (content)
            {
                case Misc.Waifu or Misc.husbando:
                    queryString += GetQueryString(name, anime, "name", "anime");
                    break;

                case Misc.quote:
                    queryString += GetQueryString(name, anime, "character", "anime");
                    break;
            }
            return await GetResponse<T>(queryString).ConfigureAwait(false);
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
            else
            {
                return string.Empty;
            }
        }

        //==========================================|make requests|==========================================
        /// <summary>
        /// Sends a request asynchronously.
        /// </summary>
        /// <param name="url">URL to get.</param>
        /// <typeparam name="T">Class to de-serialize from JSON.</typeparam>
        /// <returns>JSON-de-serialize class.</returns>
        private async Task<T> GetResponse<T>(string url)
        {
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers = { { "Authorization", _apiKey } },
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