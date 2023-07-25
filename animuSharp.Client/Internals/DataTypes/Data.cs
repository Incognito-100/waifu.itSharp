using Newtonsoft.Json;

namespace animuSharp.ClientClass.Internals.DataTypes
{
    /// <summary>
    /// Data class containing various partial classes representing different data types.
    /// </summary>
    public class Data
    {
        /// <summary>
        /// Partial class representing Text data type.
        /// </summary>
        public partial class Text
        {
            /// <summary>
            /// Gets or sets the text value.
            /// </summary>
            [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
            public string TText { get; set; }
        }

        /// <summary>
        /// Partial class representing Quote data type.
        /// </summary>
        public partial class Quote
        {
            /// <summary>
            /// Gets or sets the ID of the quote.
            /// </summary>
            [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
            public long? Id { get; set; }

            /// <summary>
            /// Gets or sets the quote text.
            /// </summary>
            [JsonProperty("quote", NullValueHandling = NullValueHandling.Ignore)]
            public string QuoteQuote { get; set; }

            /// <summary>
            /// Gets or sets the anime associated with the quote.
            /// </summary>
            [JsonProperty("anime", NullValueHandling = NullValueHandling.Ignore)]
            public string Anime { get; set; }

            /// <summary>
            /// Gets or sets the author of the quote.
            /// </summary>
            [JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)]
            public string Author { get; set; }
        }

        /// <summary>
        /// Partial class representing Password data type.
        /// </summary>
        public partial class Password
        {
            /// <summary>
            /// Gets or sets the password value.
            /// </summary>
            [JsonProperty("pass", NullValueHandling = NullValueHandling.Ignore)]
            public string Pass { get; set; }
        }

        /// <summary>
        /// Partial class representing Waifu data type.
        /// </summary>
        public partial class Waifu
        {
            /// <summary>
            /// Gets or sets the ID of the waifu.
            /// </summary>
            [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
            public long? Id { get; set; }

            /// <summary>
            /// Gets or sets the list of images associated with the waifu.
            /// </summary>
            [JsonProperty("images", NullValueHandling = NullValueHandling.Ignore)]
            public List<Uri> Images { get; set; }

            /// <summary>
            /// Gets or sets the names of the waifu in different languages.
            /// </summary>
            [JsonProperty("names", NullValueHandling = NullValueHandling.Ignore)]
            public Names Names { get; set; }

            /// <summary>
            /// Gets or sets the origin of the waifu.
            /// </summary>
            [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
            public From From { get; set; }

            /// <summary>
            /// Gets or sets the statistics of the waifu.
            /// </summary>
            [JsonProperty("statistics", NullValueHandling = NullValueHandling.Ignore)]
            public Statistics Statistics { get; set; }
        }

        /// <summary>
        /// Partial class representing the origin of the waifu.
        /// </summary>
        public partial class From
        {
            /// <summary>
            /// Gets or sets the name of the origin.
            /// </summary>
            [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets the type of the origin.
            /// </summary>
            [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
            public string Type { get; set; }
        }

        /// <summary>
        /// Partial class representing the names of the waifu in different languages.
        /// </summary>
        public partial class Names
        {
            /// <summary>
            /// Gets or sets the English name of the waifu.
            /// </summary>
            [JsonProperty("en", NullValueHandling = NullValueHandling.Ignore)]
            public string En { get; set; }

            /// <summary>
            /// Gets or sets the Japanese name of the waifu.
            /// </summary>
            [JsonProperty("jp", NullValueHandling = NullValueHandling.Ignore)]
            public string Jp { get; set; }

            /// <summary>
            /// Gets or sets alternative names of the waifu.
            /// </summary>
            [JsonProperty("alt")]
            public object Alt { get; set; }
        }

        /// <summary>
        /// Partial class representing the statistics of the waifu.
        /// </summary>
        public partial class Statistics
        {
            /// <summary>
            /// Gets or sets the number of favorites for the waifu.
            /// </summary>
            [JsonProperty("fav", NullValueHandling = NullValueHandling.Ignore)]
            public long? Fav { get; set; }

            /// <summary>
            /// Gets or sets the number of loves for the waifu.
            /// </summary>
            [JsonProperty("love", NullValueHandling = NullValueHandling.Ignore)]
            public long? Love { get; set; }

            /// <summary>
            /// Gets or sets the number of hates for the waifu.
            /// </summary>
            [JsonProperty("hate", NullValueHandling = NullValueHandling.Ignore)]
            public long? Hate { get; set; }

            /// <summary>
            /// Gets or sets the number of upvotes for the waifu.
            /// </summary>
            [JsonProperty("upvote", NullValueHandling = NullValueHandling.Ignore)]
            public long? Upvote { get; set; }

            /// <summary>
            /// Gets or sets the number of downvotes for the waifu.
            /// </summary>
            [JsonProperty("downvote", NullValueHandling = NullValueHandling.Ignore)]
            public long? Downvote { get; set; }
        }

        /// <summary>
        /// Partial class representing Fact data type.
        /// </summary>
        public partial class Fact
        {
            /// <summary>
            /// Gets or sets the ID of the fact.
            /// </summary>
            [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
            public long? Id { get; set; }

            /// <summary>
            /// Gets or sets the list of tags associated with the fact.
            /// </summary>
            [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
            public List<object> Tags { get; set; }

            /// <summary>
            /// Gets or sets the fact text.
            /// </summary>
            [JsonProperty("fact", NullValueHandling = NullValueHandling.Ignore)]
            public string FactFact { get; set; }
        }

        /// <summary>
        /// Partial class representing Generic data type.
        /// </summary>
        public partial class Generic
        {
            /// <summary>
            /// Gets or sets the URL value.
            /// </summary>
            [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
            public Uri Url { get; set; }
        }
    }
}