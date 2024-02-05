using animuSharp.ClientClass.Internals.DataTypes.ExposedTypes;
using animuSharp.ClientClass.Internals.Enums;
using animuSharp.ClientClass;

namespace animuSharp.Tests
{
    public class ClientTests
    {
        private const string apikey = "";

        [Fact]
        public async Task GetGenericURl_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Client client = new(apikey);

            // Act
            var result = await client.GetURl(ImageContentType.angry);

            var item = result.Url;

            // Assert
            Assert.NotNull(item);
        }

        [Fact]
        public async Task GetTextURl_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Client client = new(apikey);

            // Act
            var result = await client.GetURl("Hello world", Textypes.owoify);

            var item = result.TText;

            // Assert
            Assert.Equal("Hewwo world", item);
        }

        [Fact]
        public async Task GetMiscURl_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Client client = new(apikey);

            // Act
            var result = await client.GetURl<Data.Waifu>(Misc.Waifu);

            var item = result.Gender;

            // Assert
            Assert.Equal("Female", item);
        }

        [Fact]
        public async Task GetWaifuName_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Client client = new(apikey);

            // Act
            var result = await client.GetURl<Data.Waifu>(Misc.Waifu, "Kokomi Teruhashi");

            var item = result.Name.Full;

            // Assert
            Assert.Equal("Kokomi Teruhashi", item);
        }

        [Fact]
        public async Task Gethusbando_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Client client = new(apikey);

            // Act
            var result = await client.GetURl<Data.Husbando>(Misc.husbando);

            var item = result.Gender;

            // Assert
            Assert.Equal("Male", item);
        }
    }
}