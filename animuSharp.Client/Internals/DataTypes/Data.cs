using Newtonsoft.Json;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace animuSharp.Client.Internals.DataTypes
{
    /// <summary>
    /// Stores a character's birthday information. Some characters might not have complete birthday details available.
    /// </summary>
    public record DateOfBirth
    {
        /// <summary>
        /// The year the character was born
        /// </summary>
        [JsonProperty("year")] public int? Year { get; init; }

        /// <summary>
        /// The month of the character's birthday (1-12)
        /// </summary>
        [JsonProperty("month")] public int? Month { get; init; }

        /// <summary>
        /// The day of the character's birthday (1-31)
        /// </summary>
        [JsonProperty("day")] public int? Day { get; init; }
    }

    /// <summary>
    /// Contains links to a character's images in different sizes
    /// </summary>
    public record Image
    {
        /// <summary>
        /// Link to the high-quality, large version of the character's image
        /// </summary>
        [JsonProperty("large", NullValueHandling = NullValueHandling.Ignore)] public Uri Large { get; init; }
    }

    /// <summary>
    /// A list of anime or manga that the character appears in
    /// </summary>
    public record Media
    {
        /// <summary>
        /// All the anime and manga featuring this character
        /// </summary>
        [JsonProperty("nodes", NullValueHandling = NullValueHandling.Ignore)] public List<MediaEntry> Nodes { get; init; } = new();
    }

    /// <summary>
    /// Detailed information about an anime or manga series
    /// </summary>
    public record MediaEntry
    {
        /// <summary>
        /// The unique ID for this anime/manga on our platform
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)] public long? Id { get; init; }

        /// <summary>
        /// The ID of this anime/manga on MyAnimeList
        /// </summary>
        [JsonProperty("idMal", NullValueHandling = NullValueHandling.Ignore)] public long? IdMal { get; init; }

        /// <summary>
        /// The cover art/poster for this anime/manga
        /// </summary>
        [JsonProperty("coverImage", NullValueHandling = NullValueHandling.Ignore)] public CoverImage CoverImage { get; init; }

        /// <summary>
        /// The wide banner image used for this anime/manga
        /// </summary>
        [JsonProperty("bannerImage")] public Uri BannerImage { get; init; }

        /// <summary>
        /// The title of this anime/manga in different languages
        /// </summary>
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)] public Title Title { get; init; }

        /// <summary>
        /// Alternative titles or nicknames for this anime/manga
        /// </summary>
        [JsonProperty("synonyms", NullValueHandling = NullValueHandling.Ignore)] public List<string> Synonyms { get; init; } = new();

        /// <summary>
        /// How popular this anime/manga is among users
        /// </summary>
        [JsonProperty("popularity", NullValueHandling = NullValueHandling.Ignore)] public long? Popularity { get; init; }

        /// <summary>
        /// Whether this is an anime or manga
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)] public string Type { get; init; }

        /// <summary>
        /// The format (TV show, movie, manga volume, etc.)
        /// </summary>
        [JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)] public string Format { get; init; }
    }

    /// <summary>
    /// The cover art/poster image for an anime or manga
    /// </summary>
    public record CoverImage
    {
        /// <summary>
        /// Link to the medium-sized version of the cover art
        /// </summary>
        [JsonProperty("medium", NullValueHandling = NullValueHandling.Ignore)] public Uri Medium { get; init; }
    }

    /// <summary>
    /// The title of an anime/manga in different languages and formats
    /// </summary>
    public record Title
    {
        /// <summary>
        /// The title written in English letters (romanized from Japanese)
        /// </summary>
        [JsonProperty("romaji", NullValueHandling = NullValueHandling.Ignore)] public string Romaji { get; init; }

        /// <summary>
        /// The official English title
        /// </summary>
        [JsonProperty("english", NullValueHandling = NullValueHandling.Ignore)] public string English { get; init; }

        /// <summary>
        /// The original Japanese title
        /// </summary>
        [JsonProperty("native", NullValueHandling = NullValueHandling.Ignore)] public string Native { get; init; }

        /// <summary>
        /// The title in your preferred language
        /// </summary>
        [JsonProperty("userPreferred", NullValueHandling = NullValueHandling.Ignore)] public string UserPreferred { get; init; }
    }

    /// <summary>
    /// A character's name in different languages and formats
    /// </summary>
    public record Name
    {
        /// <summary>
        /// The character's first/given name
        /// </summary>
        [JsonProperty("first", NullValueHandling = NullValueHandling.Ignore)] public string First { get; init; }

        /// <summary>
        /// The character's middle name (if they have one)
        /// </summary>
        [JsonProperty("middle")] public string Middle { get; init; }

        /// <summary>
        /// The character's last name/family name
        /// </summary>
        [JsonProperty("last")] public string Last { get; init; }

        /// <summary>
        /// The character's complete name
        /// </summary>
        [JsonProperty("full", NullValueHandling = NullValueHandling.Ignore)] public string Full { get; init; }

        /// <summary>
        /// The character's name in Japanese
        /// </summary>
        [JsonProperty("native", NullValueHandling = NullValueHandling.Ignore)] public string Native { get; init; }

        /// <summary>
        /// The character's name in your preferred language
        /// </summary>
        [JsonProperty("userPreferred", NullValueHandling = NullValueHandling.Ignore)] public string UserPreferred { get; init; }

        /// <summary>
        /// Other names this character might be known by
        /// </summary>
        [JsonProperty("alternative", NullValueHandling = NullValueHandling.Ignore)] public List<string> Alternative { get; init; } = [];

        /// <summary>
        /// Alternative names that might contain story spoilers
        /// </summary>
        [JsonProperty("alternativeSpoiler", NullValueHandling = NullValueHandling.Ignore)] public List<string> AlternativeSpoiler { get; init; } = [];
    }

    /// <summary>
    /// Basic information that all anime/manga characters share
    /// </summary>
    public abstract record CharacterBase
    {
        /// <summary>
        /// The unique ID that identifies this character
        /// </summary>
        [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)] public long? Id { get; init; }

        /// <summary>
        /// The character's name in different languages and formats
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)] public Name Name { get; init; }

        /// <summary>
        /// Pictures of the character
        /// </summary>
        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)] public Image Image { get; init; }

        /// <summary>
        /// How many users have marked this character as a favorite
        /// </summary>
        [JsonProperty("favourites", NullValueHandling = NullValueHandling.Ignore)] public long? Favourites { get; init; }

        /// <summary>
        /// Link to this character's full profile page
        /// </summary>
        [JsonProperty("siteUrl", NullValueHandling = NullValueHandling.Ignore)] public Uri SiteUrl { get; init; }

        /// <summary>
        /// The character's background story and details
        /// </summary>
        [JsonProperty("description")] public string Description { get; init; }

        /// <summary>
        /// The character's age (might be a number or description like "teenager")
        /// </summary>
        [JsonProperty("age")] public dynamic? Age { get; init; }

        /// <summary>
        /// The character's gender
        /// </summary>
        [JsonProperty("gender", NullValueHandling = NullValueHandling.Ignore)] public string Gender { get; init; }

        /// <summary>
        /// The character's blood type (common in anime character profiles)
        /// </summary>
        [JsonProperty("bloodType")] public string BloodType { get; init; }

        /// <summary>
        /// The character's birthday information
        /// </summary>
        [JsonProperty("dateOfBirth", NullValueHandling = NullValueHandling.Ignore)] public DateOfBirth DateOfBirth { get; init; }

        /// <summary>
        /// List of anime and manga this character appears in
        /// </summary>
        [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)] public Media Media { get; init; }
    }

    /// <summary>
    /// Contains different types of anime/manga-related information
    /// </summary>
    public static class Data
    {
        /// <summary>
        /// A simple type that just contains a URL link
        /// </summary>
        public record Generic
        {
            /// <summary>
            /// The web address (URL) for this item
            /// </summary>
            [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)] public Uri Url { get; init; }
        }

        /// <summary>
        /// Information about a female anime/manga character
        /// </summary>
        public record Waifu : CharacterBase;

        /// <summary>
        /// Information about a male anime/manga character
        /// </summary>
        public record Husbando : CharacterBase;

        /// <summary>
        /// A memorable quote from an anime
        /// </summary>
        public record Quote
        {
            /// <summary>
            /// Unique ID for this quote
            /// </summary>
            [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)] public long? Id { get; init; }

            /// <summary>
            /// The actual words that were said
            /// </summary>
            [JsonProperty("quote", NullValueHandling = NullValueHandling.Ignore)] public string Content { get; init; }

            /// <summary>
            /// The anime this quote is from
            /// </summary>
            [JsonProperty("anime", NullValueHandling = NullValueHandling.Ignore)] public string Anime { get; init; }

            /// <summary>
            /// The character who said this quote
            /// </summary>
            [JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)] public string Author { get; init; }
        }

        /// <summary>
        /// An interesting piece of trivia about anime
        /// </summary>
        public record Fact
        {
            /// <summary>
            /// Unique ID for this fact
            /// </summary>
            [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)] public long? Id { get; init; }

            /// <summary>
            /// Categories or topics this fact relates to
            /// </summary>
            [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)] public List<string> Tags { get; init; } = new();

            /// <summary>
            /// The actual interesting fact
            /// </summary>
            [JsonProperty("fact", NullValueHandling = NullValueHandling.Ignore)] public string Content { get; init; }
        }

        /// <summary>
        /// A simple piece of text
        /// </summary>
        public record Text
        {
            /// <summary>
            /// The text content
            /// </summary>
            [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)] public string Content { get; init; }
        }

        /// <summary>
        /// A secure way to store password information
        /// </summary>
        public record Password
        {
            /// <summary>
            /// The password value
            /// </summary>
            [JsonProperty("pass", NullValueHandling = NullValueHandling.Ignore)] public string Value { get; init; }
        }
    }
}

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member