using animuSharp.Client.Internals.Enums;

namespace animuSharp.Tests
{
    public class ClientTests
    {
        private static readonly string Apikey = "ANIMU_API_KEY";

        [Fact]
        public async Task GetUrl_WithAngryContentType_ReturnsValidUrl()
        {
            // Arrange
            Client.Client client = new(Apikey);

            // Act
            var result = await client.GetURl(ImageContentType.angry);
            var item = result.Url;

            // Assert
            Assert.NotNull(item);
        }

        [Fact]
        public async Task GetUrl_WithOwoifyTextType_ReturnsCorrectlyTransformedText()
        {
            // Arrange
            Client.Client client = new(Apikey);

            // Act
            var result = await client.GetURl("Hello world", Textypes.owoify);
            var item = result.Content;

            // Assert
            Assert.Equal("Hewwo world", item);
        }

        [Fact]
        public async Task GetWaifu_DefaultCall_ReturnsValidCharacter()
        {
            // Arrange
            Client.Client client = new(Apikey);

            // Act
            var result = await client.GetWaifu();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Id);
            Assert.NotNull(result.Gender);
            Assert.NotEmpty(result.Gender);
        }

        [Fact]
        public async Task GetWaifuByName_ReturnsCorrectCharacter()
        {
            // Arrange
            Client.Client client = new(Apikey);

            // Act
            var result = await client.GetWaifu(name: "Reiko Terayama");
            var item = result.Gender;

            // Assert
            Assert.Equal("Female", item);
        }

        [Fact]
        public async Task GetHusbando_DefaultCall_ReturnsValidCharacter()
        {
            // Arrange
            Client.Client client = new(Apikey);

            // Act
            var result = await client.GetHusbando();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Id);
            Assert.NotNull(result.Gender);
            Assert.NotEmpty(result.Gender);
        }

        [Fact]
        public async Task GetQuote_WithSpecificAnime_ReturnsCorrectQuote()
        {
            // Arrange
            Client.Client client = new(Apikey);

            // Act
            var result = await client.GetQuote(anime: "death note");
            var item = result.Anime;

            // Assert
            Assert.Equal("Death Note", item);
        }

        [Fact]
        public async Task GetQuote_WithSpecificCharacter_ReturnsValidQuote()
        {
            // Arrange
            Client.Client client = new(Apikey);

            // Act
            var result = await client.GetQuote(character: "Saiki Kusuo");

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Content);
            Assert.NotNull(result.Author);
            Assert.Contains("Saiki Kusuo", result.Author, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public async Task GetFact_DefaultCall_ReturnsValidFact()
        {
            // Arrange
            Client.Client client = new(Apikey);

            // Act
            var result = await client.GetFact();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Content);
            Assert.NotEmpty(result.Content);
        }

        [Fact]
        public async Task GetPassword_DefaultCall_ReturnsValidPassword()
        {
            // Arrange
            Client.Client client = new(Apikey);

            // Act
            var result = await client.GetPassword();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.NotEmpty(result.Value);
        }

        [Fact]
        public async Task GetTags_DefaultCall_ReturnsValidTags()
        {
            // Arrange
            Client.Client client = new(Apikey);

            // Act
            var result = await client.GetTags();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Url);
        }

        [Fact]
        public async Task GetWaifu_ValidatesAllProperties()
        {
            // Arrange
            Client.Client client = new(Apikey);

            // Act
            var result = await client.GetWaifu();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Id);
            Assert.NotNull(result.Name);
            Assert.NotNull(result.Name.Full);
            Assert.NotNull(result.Image);
            Assert.NotNull(result.Image.Large);
            Assert.NotNull(result.Description);
            Assert.NotNull(result.Gender);
            Assert.NotNull(result.Media);
        }

        [Fact]
        public async Task GetCharacterWithDateOfBirth_ValidatesDateProperties()
        {
            // Arrange
            Client.Client client = new(Apikey);

            // Act
            var result = await client.GetWaifu();

            // Assert
            Assert.NotNull(result.DateOfBirth);
            if (result.DateOfBirth.Year.HasValue)
            {
                Assert.True(result.DateOfBirth.Year > 0);
            }
            if (result.DateOfBirth.Month.HasValue)
            {
                Assert.True(result.DateOfBirth.Month >= 1 && result.DateOfBirth.Month <= 12);
            }
            if (result.DateOfBirth.Day.HasValue)
            {
                Assert.True(result.DateOfBirth.Day >= 1 && result.DateOfBirth.Day <= 31);
            }
        }

        [Fact]
        public async Task GetCharacterMedia_ValidatesMediaProperties()
        {
            // Arrange
            Client.Client client = new(Apikey);

            // Act
            var result = await client.GetWaifu();

            // Assert
            Assert.NotNull(result.Media);
            Assert.NotNull(result.Media.Nodes);

            foreach (var mediaEntry in result.Media.Nodes)
            {
                Assert.NotNull(mediaEntry.Id);
                Assert.NotNull(mediaEntry.Title);
                Assert.NotNull(mediaEntry.Title.UserPreferred);
                if (mediaEntry.CoverImage != null)
                {
                    Assert.NotNull(mediaEntry.CoverImage.Medium);
                }
                Assert.NotNull(mediaEntry.Type);
                Assert.NotNull(mediaEntry.Format);
            }
        }

        [Fact]
        public async Task GetCharacterName_ValidatesNameProperties()
        {
            // Arrange
            Client.Client client = new(Apikey);

            // Act
            var result = await client.GetWaifu();

            // Assert
            Assert.NotNull(result.Name);
            Assert.NotNull(result.Name.First);
            Assert.NotNull(result.Name.Full);
            Assert.NotNull(result.Name.Native);
            Assert.NotNull(result.Name.UserPreferred);
            Assert.NotNull(result.Name.Alternative);
            Assert.NotNull(result.Name.AlternativeSpoiler);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public async Task GetWaifu_WithInvalidName_ReturnsDefaultWaifu(string name)
        {
            // Arrange
            Client.Client client = new(Apikey);

            // Act
            var result = await client.GetWaifu(name: name);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Id);
        }
    }
}