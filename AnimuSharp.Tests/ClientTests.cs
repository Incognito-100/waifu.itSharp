using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;
using animuSharp.Client;
using animuSharp.Client.Internals.Enums;
using NSubstitute.Core;
using static AnimuSharp.Tests.ClientTests;

namespace AnimuSharp.Tests
{
    public class ClientTests
    {
        public ClientTests()
        {
        }

        private const string apikey = "76a65670f12f6f6546b24c90335b88456ee5e864fce3";

        private Client CreateClient()
        {
            return new Client(apikey);
        }

        [Fact]
        public async Task GetURl_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var client = this.CreateClient();
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
            var client = this.CreateClient();

            // Act
            var result = await client.GetwaifuURl();

            // Assert
            Assert.NotNull(result);
        }
    }
}