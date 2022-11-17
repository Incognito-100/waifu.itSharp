using animuSharp.Client;
using animuSharp.Client.Internals.Enums;

namespace AnimuSharp.Tests
{
    public class ClientTests
    {
        [Fact]
        public async Task GetURl_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var client = new Client("Key");

            // Act
            var result = await client.GetURl(ContentType.angry);
            var url = result.Url;

            // Assert
            Assert.NotNull(url);
        }

        [Fact]
        public async Task GetwaifuURl_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var client = new Client("Key");

            // Act
            var result = await client.GetwaifuURl();
            var wurl = result.Names.En;

            // Assert
            Assert.NotNull(wurl);
        }
    }
}