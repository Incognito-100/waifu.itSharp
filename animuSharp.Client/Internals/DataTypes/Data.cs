using Newtonsoft.Json;

namespace animuSharp.Client.Internals.DataTypes
{
    /// <summary>
    /// Get random waifus
    /// </summary>
    public class Data
    {
        /// <summary>
        /// Get random waifus or husbandos
        /// </summary>
        public class Waifu
        {
            /// <summary>
            /// the id of the request
            /// </summary>
            [JsonProperty("_id")]
            public long Id { get; set; }

            /// <summary>
            /// the links of the images
            /// </summary>
            [JsonProperty("images")]
            public List<Uri> Images { get; set; }

            /// <summary>
            /// the names in english japaneese and alternative
            /// </summary>
            [JsonProperty("names")]
            public Names Names { get; set; }

            /// <summary>
            /// get info about the anime the character belongs to
            /// </summary>
            [JsonProperty("from")]
            public From From { get; set; }

            /// <summary>
            /// statistics of the character
            /// </summary>
            [JsonProperty("statistics")]
            public Statistics Statistics { get; set; }
        }

        /// <summary>
        /// get info about the anime the character belongs to (only for waifu endpoint)
        /// </summary>
        public partial class From
        {
            /// <summary>
            /// name of the anime the character belongs to
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// the type of anime the character origenated from
            /// </summary>
            [JsonProperty("type")]
            public string Type { get; set; }
        }

        /// <summary>
        /// the names in english japaneese and alternative
        /// </summary>
        public partial class Names
        {
            /// <summary>
            /// the characters name in english
            /// </summary>
            [JsonProperty("en")]
            public string En { get; set; }

            /// <summary>
            /// the characters name in japaneese
            /// </summary>
            [JsonProperty("jp")]
            public string Jp { get; set; }

            /// <summary>
            /// alternative name for the character
            /// </summary>
            [JsonProperty("alt")]
            public object Alt { get; set; }
        }

        /// <summary>
        /// statistics of the character
        /// </summary>
        public partial class Statistics
        {
            /// <summary>
            /// a number that represent the amount of people who favorited this character
            /// </summary>
            [JsonProperty("fav")]
            public long Fav { get; set; }

            /// <summary>
            /// a number that represents the amount of people that loved this character
            /// </summary>
            [JsonProperty("love")]
            public long Love { get; set; }

            /// <summary>
            /// a number that represents the amount of people that hate this character
            /// </summary>
            [JsonProperty("hate")]
            public long Hate { get; set; }

            /// <summary>
            /// a number that represents the amount of upvotes this character has
            /// </summary>
            [JsonProperty("upvote")]
            public long Upvote { get; set; }

            /// <summary>
            /// a number that represents the amount of downvotes this character has
            /// </summary>
            [JsonProperty("downvote")]
            public long Downvote { get; set; }
        }

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
}