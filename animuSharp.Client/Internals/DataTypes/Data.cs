using Newtonsoft.Json;
using static animuSharp.ClientClass.Internals.DataTypes.Data;
using static animuSharp.ClientClass.Internals.DataTypes.Data.husbandodata;

namespace animuSharp.ClientClass.Internals.DataTypes
{
    namespace ExposedTypes
    {
        public class Data
        {
            public class Generic
            {
                [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
                public Uri? Url { get; set; }
            }

            public class Waifu
            {
                [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
                public long? Id { get; set; }

                [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
                public Name Name { get; set; }

                [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
                public Image Image { get; set; }

                [JsonProperty("favourites", NullValueHandling = NullValueHandling.Ignore)]
                public long? Favourites { get; set; }

                [JsonProperty("siteUrl", NullValueHandling = NullValueHandling.Ignore)]
                public Uri SiteUrl { get; set; }

                [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
                public string Description { get; set; }

                [JsonProperty("age")]
                public dynamic Age { get; set; }

                [JsonProperty("gender", NullValueHandling = NullValueHandling.Ignore)]
                public string Gender { get; set; }

                [JsonProperty("bloodType")]
                public dynamic BloodType { get; set; }

                [JsonProperty("dateOfBirth", NullValueHandling = NullValueHandling.Ignore)]
                public DateOfBirth DateOfBirth { get; set; }

                [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
                public Media Media { get; set; }
            }

            public class Husbando
            {
                [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
                public long? Id { get; set; }

                [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
                public Name Name { get; set; }

                [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
                public Image Image { get; set; }

                [JsonProperty("favourites", NullValueHandling = NullValueHandling.Ignore)]
                public long? Favourites { get; set; }

                [JsonProperty("siteUrl", NullValueHandling = NullValueHandling.Ignore)]
                public Uri SiteUrl { get; set; }

                [JsonProperty("description")]
                public dynamic Description { get; set; }

                [JsonProperty("age")]
                public dynamic Age { get; set; }

                [JsonProperty("gender", NullValueHandling = NullValueHandling.Ignore)]
                public string Gender { get; set; }

                [JsonProperty("bloodType")]
                public dynamic BloodType { get; set; }

                [JsonProperty("dateOfBirth", NullValueHandling = NullValueHandling.Ignore)]
                public DateOfBirth DateOfBirth { get; set; }

                [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
                public Media Media { get; set; }
            }

            public class Quote
            {
                [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
                public long? Id { get; set; }

                [JsonProperty("quote", NullValueHandling = NullValueHandling.Ignore)]
                public string? QuoteQuote { get; set; }

                [JsonProperty("anime", NullValueHandling = NullValueHandling.Ignore)]
                public string? Anime { get; set; }

                [JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)]
                public string? Author { get; set; }
            }

            public class Fact
            {
                [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
                public long? Id { get; set; }

                [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
                public List<object>? Tags { get; set; }

                [JsonProperty("fact", NullValueHandling = NullValueHandling.Ignore)]
                public string? FactFact { get; set; }
            }
        }
    }

    /// <summary>
    /// Data class containing various partial classes representing different data types.
    /// </summary>

    #region Data

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
            public string? TText { get; set; }
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
            public string? QuoteQuote { get; set; }

            /// <summary>
            /// Gets or sets the anime associated with the quote.
            /// </summary>
            [JsonProperty("anime", NullValueHandling = NullValueHandling.Ignore)]
            public string? Anime { get; set; }

            /// <summary>
            /// Gets or sets the author of the quote.
            /// </summary>
            [JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)]
            public string? Author { get; set; }
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
            public string? Pass { get; set; }
        }

        /// <summary>
        /// Partial class representing Waifu data type.
        /// </summary>
        public partial class waifudata
        {
            public partial class Waifu
            {
                [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
                public long? Id { get; set; }

                [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
                public Name Name { get; set; }

                [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
                public Image Image { get; set; }

                [JsonProperty("favourites", NullValueHandling = NullValueHandling.Ignore)]
                public long? Favourites { get; set; }

                [JsonProperty("siteUrl", NullValueHandling = NullValueHandling.Ignore)]
                public Uri SiteUrl { get; set; }

                [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
                public string Description { get; set; }

                [JsonProperty("age")]
                public dynamic Age { get; set; }

                [JsonProperty("gender", NullValueHandling = NullValueHandling.Ignore)]
                public string Gender { get; set; }

                [JsonProperty("bloodType")]
                public dynamic BloodType { get; set; }

                [JsonProperty("dateOfBirth", NullValueHandling = NullValueHandling.Ignore)]
                public DateOfBirth DateOfBirth { get; set; }

                [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
                public Media Media { get; set; }
            }

            public partial class DateOfBirth
            {
                [JsonProperty("year")]
                public dynamic Year { get; set; }

                [JsonProperty("month")]
                public dynamic Month { get; set; }

                [JsonProperty("day")]
                public dynamic Day { get; set; }
            }

            public partial class Image
            {
                [JsonProperty("large", NullValueHandling = NullValueHandling.Ignore)]
                public Uri Large { get; set; }
            }

            public partial class Media
            {
                [JsonProperty("nodes", NullValueHandling = NullValueHandling.Ignore)]
                public List<Node> Nodes { get; set; }
            }

            public partial class Node
            {
                [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
                public long? Id { get; set; }

                [JsonProperty("idMal", NullValueHandling = NullValueHandling.Ignore)]
                public long? IdMal { get; set; }

                [JsonProperty("coverImage", NullValueHandling = NullValueHandling.Ignore)]
                public CoverImage CoverImage { get; set; }

                [JsonProperty("bannerImage")]
                public dynamic BannerImage { get; set; }

                [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
                public Title Title { get; set; }

                [JsonProperty("synonyms", NullValueHandling = NullValueHandling.Ignore)]
                public List<string> Synonyms { get; set; }

                [JsonProperty("popularity", NullValueHandling = NullValueHandling.Ignore)]
                public long? Popularity { get; set; }

                [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
                public string Type { get; set; }

                [JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)]
                public string Format { get; set; }
            }

            public partial class CoverImage
            {
                [JsonProperty("medium", NullValueHandling = NullValueHandling.Ignore)]
                public Uri Medium { get; set; }
            }

            public partial class Title
            {
                [JsonProperty("romaji", NullValueHandling = NullValueHandling.Ignore)]
                public string Romaji { get; set; }

                [JsonProperty("english", NullValueHandling = NullValueHandling.Ignore)]
                public string English { get; set; }

                [JsonProperty("native", NullValueHandling = NullValueHandling.Ignore)]
                public string Native { get; set; }

                [JsonProperty("userPreferred", NullValueHandling = NullValueHandling.Ignore)]
                public string UserPreferred { get; set; }
            }

            public partial class Name
            {
                [JsonProperty("first", NullValueHandling = NullValueHandling.Ignore)]
                public string First { get; set; }

                [JsonProperty("middle")]
                public dynamic Middle { get; set; }

                [JsonProperty("last")]
                public dynamic Last { get; set; }

                [JsonProperty("full", NullValueHandling = NullValueHandling.Ignore)]
                public string Full { get; set; }

                [JsonProperty("native", NullValueHandling = NullValueHandling.Ignore)]
                public string Native { get; set; }

                [JsonProperty("userPreferred", NullValueHandling = NullValueHandling.Ignore)]
                public string UserPreferred { get; set; }

                [JsonProperty("alternative", NullValueHandling = NullValueHandling.Ignore)]
                public List<dynamic> Alternative { get; set; }

                [JsonProperty("alternativeSpoiler", NullValueHandling = NullValueHandling.Ignore)]
                public List<dynamic> AlternativeSpoiler { get; set; }
            }
        }

        public class husbandodata
        {
            public partial class Husbando
            {
                [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
                public long? Id { get; set; }

                [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
                public Name Name { get; set; }

                [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
                public Image Image { get; set; }

                [JsonProperty("favourites", NullValueHandling = NullValueHandling.Ignore)]
                public long? Favourites { get; set; }

                [JsonProperty("siteUrl", NullValueHandling = NullValueHandling.Ignore)]
                public Uri SiteUrl { get; set; }

                [JsonProperty("description")]
                public dynamic Description { get; set; }

                [JsonProperty("age")]
                public dynamic Age { get; set; }

                [JsonProperty("gender", NullValueHandling = NullValueHandling.Ignore)]
                public string Gender { get; set; }

                [JsonProperty("bloodType")]
                public dynamic BloodType { get; set; }

                [JsonProperty("dateOfBirth", NullValueHandling = NullValueHandling.Ignore)]
                public DateOfBirth DateOfBirth { get; set; }

                [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
                public Media Media { get; set; }
            }

            public partial class DateOfBirth
            {
                [JsonProperty("year")]
                public dynamic Year { get; set; }

                [JsonProperty("month", NullValueHandling = NullValueHandling.Ignore)]
                public long? Month { get; set; }

                [JsonProperty("day", NullValueHandling = NullValueHandling.Ignore)]
                public long? Day { get; set; }
            }

            public partial class Image
            {
                [JsonProperty("large", NullValueHandling = NullValueHandling.Ignore)]
                public Uri Large { get; set; }
            }

            public partial class Media
            {
                [JsonProperty("nodes", NullValueHandling = NullValueHandling.Ignore)]
                public List<Node> Nodes { get; set; }
            }

            public partial class Node
            {
                [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
                public long? Id { get; set; }

                [JsonProperty("idMal", NullValueHandling = NullValueHandling.Ignore)]
                public long? IdMal { get; set; }

                [JsonProperty("coverImage", NullValueHandling = NullValueHandling.Ignore)]
                public CoverImage CoverImage { get; set; }

                [JsonProperty("bannerImage", NullValueHandling = NullValueHandling.Ignore)]
                public Uri BannerImage { get; set; }

                [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
                public Title Title { get; set; }

                [JsonProperty("synonyms", NullValueHandling = NullValueHandling.Ignore)]
                public List<string> Synonyms { get; set; }

                [JsonProperty("popularity", NullValueHandling = NullValueHandling.Ignore)]
                public long? Popularity { get; set; }

                [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
                public string Type { get; set; }

                [JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)]
                public string Format { get; set; }
            }

            public partial class CoverImage
            {
                [JsonProperty("medium", NullValueHandling = NullValueHandling.Ignore)]
                public Uri Medium { get; set; }
            }

            public partial class Title
            {
                [JsonProperty("romaji", NullValueHandling = NullValueHandling.Ignore)]
                public string Romaji { get; set; }

                [JsonProperty("english", NullValueHandling = NullValueHandling.Ignore)]
                public string English { get; set; }

                [JsonProperty("native", NullValueHandling = NullValueHandling.Ignore)]
                public string Native { get; set; }

                [JsonProperty("userPreferred", NullValueHandling = NullValueHandling.Ignore)]
                public string UserPreferred { get; set; }
            }

            public partial class Name
            {
                [JsonProperty("first", NullValueHandling = NullValueHandling.Ignore)]
                public string First { get; set; }

                [JsonProperty("middle")]
                public dynamic Middle { get; set; }

                [JsonProperty("last", NullValueHandling = NullValueHandling.Ignore)]
                public string Last { get; set; }

                [JsonProperty("full", NullValueHandling = NullValueHandling.Ignore)]
                public string Full { get; set; }

                [JsonProperty("native", NullValueHandling = NullValueHandling.Ignore)]
                public string Native { get; set; }

                [JsonProperty("userPreferred", NullValueHandling = NullValueHandling.Ignore)]
                public string UserPreferred { get; set; }

                [JsonProperty("alternative", NullValueHandling = NullValueHandling.Ignore)]
                public List<dynamic> Alternative { get; set; }

                [JsonProperty("alternativeSpoiler", NullValueHandling = NullValueHandling.Ignore)]
                public List<dynamic> AlternativeSpoiler { get; set; }
            }
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
            public List<object>? Tags { get; set; }

            /// <summary>
            /// Gets or sets the fact text.
            /// </summary>
            [JsonProperty("fact", NullValueHandling = NullValueHandling.Ignore)]
            public string? FactFact { get; set; }
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
            public Uri? Url { get; set; }
        }
    }

    #endregion Data
}