﻿using animuSharp.ClientClass.Internals.DataTypes;
using animuSharp.ClientClass.Internals.Enums;
using Newtonsoft.Json;
using System.Net;
using System.Web;

namespace animuSharp.ClientClass
{
    /// <summary>
    /// main method for interacting with the api
    /// </summary>
    public class Client
    {
        private const string BaseUrl = "https://waifu.it/api/v4";
        private readonly string Key;
        private static HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="apiKey">apiKey for making requests NOTE: it has a 5 requests/second rate-limit</param>
        public Client(string apiKey)
        {
            Key = apiKey;
        }

        /// <summary>
        /// Gets a URL of the desired content.
        /// </summary>
        /// <param name="content">The type of content you want to get, select from <see cref="ImageContentType"/>.</param>
        /// <returns>A URL of the selected item.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Data.Generic> GetURl(ImageContentType content)
        {
            string endpoint = $"/{content.ToString().ToLower()}";

            string nl = $"{BaseUrl}{endpoint}";

            return await GetResponse<Data.Generic>(nl).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a URL of the desired content.
        /// </summary>
        /// <param name="content">The type of content you want to get, select from <see cref="Textypes"/>.</param>
        /// <param name="text"> the text you want to be used in the api call</param>
        /// <returns>A URL of the selected item.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Data.Text> GetURl(string text, Textypes content)
        {
            string endpoint = $"/{content.ToString().ToLower()}";

            string nl = $"{BaseUrl}{endpoint}";

            string encodedText = Uri.EscapeDataString(text);

            string recont = $"{nl}?text={encodedText}";

            return await GetResponse<Data.Text>(recont).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a URL of the desired content.
        /// </summary>
        /// <param name="content">The type of content you want to get, select from <see cref="Misc"/>.</param>
        /// <returns>A URL of the selected item.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<T> GetURl<T>(Misc content, string name = null, string anime = null)
        {
            string endpoint = $"/{content.ToString().ToLower()}";

            if (content == Misc.Waifu || content == Misc.husbando)
            {
                endpoint += GetQueryString(name, anime, "name", "anime");
            }
            else if (content == Misc.quote)
            {
                endpoint += GetQueryString(name, anime, "character", "anime");
            }
            string url = $"{BaseUrl}{endpoint}";
            return await GetResponse<T>(url).ConfigureAwait(false);
        }

        private static string GetQueryString(string name, string anime, string nameParam, string animeParam)
        {
            var queryParams = new List<string>();

            if (!string.IsNullOrEmpty(name))
            {
                string f = $"{nameParam}={HttpUtility.UrlEncode(name)}";
                queryParams.Add(f);
            }

            if (!string.IsNullOrEmpty(anime))
            {
                string f = $"{animeParam}={HttpUtility.UrlEncode(anime)}";
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
                Headers = { { "Authorization", Key } },
            };

            var response = await httpClient.SendAsync(request);

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