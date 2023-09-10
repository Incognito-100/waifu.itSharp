using animuSharp.ClientClass.Internals.DataTypes;
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
            Client client = new Client(apikey);

            // Act
            var result = await client.GetGenericURl(ImageContentType.angry);

            var item = result.Url;

            // Assert
            Assert.NotNull(item);
        }

        [Fact]
        public async Task GetTextURl_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Client client = new Client(apikey);

            // Act
            var result = await client.GetTextURl("Hello world", Textypes.owoify);

            var item = result.TText;

            // Assert
            Assert.Equal("Hewwo world", item);
        }

        [Fact]
        public async Task GetMiscURl_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Client client = new Client(apikey);

            // Act
            var result = await client.GetMiscURl<Data.Waifu>(Misc.Waifu);

            var item = result.Names.En;

            // Assert
            Assert.NotNull(item);
        }
    }
}