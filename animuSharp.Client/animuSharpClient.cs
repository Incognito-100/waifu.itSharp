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
        private const string BaBaseUrl = "https://animu.ml/api";
        private static string key;

        /// <summary>
        ///  Create a new instance of the client
        /// </summary>
        /// <param name="apiKey">apiKey for making requests NOTE: it has a 5 requests/second rate-limit</param>
        public Client(string apiKey)
        {
            key = apiKey;
            HttpClient client = new();
            // API requires use of a key, so add it to the headers
            client.DefaultRequestHeaders.Add("Auth", key);
        }

        /// <summary>
        /// get a url if the desired content
        /// </summary>
        /// <param name="content">the type of content you want to get select from <see cref="ContentType"/></param>
        /// <returns>a url of the selected item</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Generic> GetURl(ContentType content)
        {
            var endpoint = $"/{content.ToString().ToLower()}";

            string nl = $"{BaBaseUrl}{endpoint}";

            return await GetResponse<Generic>(nl).ConfigureAwait(false);
        }

        /// <summary>
        /// returns info about a random waifu
        /// </summary>
        /// <returns>a random waifu and associated info</returns>
        public async Task<Waifu> GetwaifuURl()
        {
            const string endpoint = $"/waifu";

            string end = $"{BaBaseUrl}{endpoint}";

            return await GetResponse<Waifu>(end).ConfigureAwait(false);
        }

        //==========================================|make requests|==========================================
        /// <summary>
        ///     Send the request asynchronously (Dont use this method).
        /// </summary>
        /// <param name="destination">Url to get.</param>
        /// <typeparam name="T">Class to deserialize from JSON.</typeparam>
        /// <returns>JSON-deserialized class.</returns>
        public static async Task<T> GetResponse<T>(string destination)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Auth", key);
            var req = new HttpRequestMessage(HttpMethod.Get, destination);
            var res = await httpClient.SendAsync(req);

            if (!res.IsSuccessStatusCode)
            {
                throw new Exception($"Request failed with status code {res.StatusCode}");
            }

            var response = await res.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}