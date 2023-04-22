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

        public const string apikey = "76a65670f12f6f6546b24c90335b88456ee5e864fce3";

        [Fact]
        public async Task GetURl_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Client client = new Client(apikey);
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
            Client client = new Client(apikey);

            // Act
            var result = await client.GetwaifuURl();

            // Assert
            Assert.NotNull(result);
        }
    }
}