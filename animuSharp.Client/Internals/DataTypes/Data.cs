using Newtonsoft.Json;

namespace animuSharp.Client.Internals.DataTypes
{
    public class DateOfBirth
    {
        [JsonProperty("year")]
        public int? Year { get; set; }

        [JsonProperty("month")]
        public int? Month { get; set; }

        [JsonProperty("day")]
        public int? Day { get; set; }
    }

    public class Image
    {
        [JsonProperty("large", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Large { get; set; }
    }

    public class Media
    {
        [JsonProperty("nodes", NullValueHandling = NullValueHandling.Ignore)]
        public List<MediaEntry> Nodes { get; set; } = new();
    }

    public class MediaEntry
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("idMal", NullValueHandling = NullValueHandling.Ignore)]
        public long? IdMal { get; set; }

        [JsonProperty("coverImage", NullValueHandling = NullValueHandling.Ignore)]
        public CoverImage CoverImage { get; set; }

        [JsonProperty("bannerImage")]
        public Uri BannerImage { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public Title Title { get; set; }

        [JsonProperty("synonyms", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Synonyms { get; set; } = new();

        [JsonProperty("popularity", NullValueHandling = NullValueHandling.Ignore)]
        public long? Popularity { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)]
        public string Format { get; set; }
    }

    public class CoverImage
    {
        [JsonProperty("medium", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Medium { get; set; }
    }

    public class Title
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

    public class Name
    {
        [JsonProperty("first", NullValueHandling = NullValueHandling.Ignore)]
        public string First { get; set; }

        [JsonProperty("middle")]
        public string Middle { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }

        [JsonProperty("full", NullValueHandling = NullValueHandling.Ignore)]
        public string Full { get; set; }

        [JsonProperty("native", NullValueHandling = NullValueHandling.Ignore)]
        public string Native { get; set; }

        [JsonProperty("userPreferred", NullValueHandling = NullValueHandling.Ignore)]
        public string UserPreferred { get; set; }

        [JsonProperty("alternative", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Alternative { get; set; } = new();

        [JsonProperty("alternativeSpoiler", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> AlternativeSpoiler { get; set; } = new();
    }

    public abstract class CharacterBase
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
        public string Description { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }

        [JsonProperty("gender", NullValueHandling = NullValueHandling.Ignore)]
        public string Gender { get; set; }

        [JsonProperty("bloodType")]
        public string BloodType { get; set; }

        [JsonProperty("dateOfBirth", NullValueHandling = NullValueHandling.Ignore)]
        public DateOfBirth DateOfBirth { get; set; }

        [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
        public Media Media { get; set; }
    }

    public static class Data
    {
        public class Generic
        {
            [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
            public Uri Url { get; set; }
        }

        public class Waifu : CharacterBase
        { }

        public class Husbando : CharacterBase
        { }

        public class Quote
        {
            [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
            public long? Id { get; set; }

            [JsonProperty("quote", NullValueHandling = NullValueHandling.Ignore)]
            public string Content { get; set; }

            [JsonProperty("anime", NullValueHandling = NullValueHandling.Ignore)]
            public string Anime { get; set; }

            [JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)]
            public string Author { get; set; }
        }

        public class Fact
        {
            [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
            public long? Id { get; set; }

            [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
            public List<string> Tags { get; set; } = new();

            [JsonProperty("fact", NullValueHandling = NullValueHandling.Ignore)]
            public string Content { get; set; }
        }

        public class Text
        {
            [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
            public string Content { get; set; }
        }

        public class Password
        {
            [JsonProperty("pass", NullValueHandling = NullValueHandling.Ignore)]
            public string Value { get; set; }
        }
    }
}