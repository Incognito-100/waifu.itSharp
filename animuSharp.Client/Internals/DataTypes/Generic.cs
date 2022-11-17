using Newtonsoft.Json;

namespace animuSharp.Client.Internals.DataTypes
{
    /// <summary>
    /// Get data from endpoints
    /// </summary>
    public class Generic
    {
        /// <summary>
        /// the url of the requested item
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}