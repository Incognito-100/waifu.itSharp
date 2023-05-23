using animuSharp.Client;
using animuSharp.Client.Internals.Enums;
using Xunit;

namespace AnimuSharp.Tests
{
    public class ClientTests
    {
        public ClientTests()
        {
        }

        public const string apikey = "";

        [Fact]
        public async Task GetURl_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Client client = new(apikey);
            ContentType content = ContentType.angry;

            // Act
            var result = await client.GetURl(content);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetwaifuURl_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Client client = new(apikey);

            // Act
            var result = await client.GetwaifuURl();

            // Assert
            Assert.NotNull(result);
        }
    }
}