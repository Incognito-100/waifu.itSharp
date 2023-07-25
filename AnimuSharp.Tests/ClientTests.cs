using System;
using System.Threading.Tasks;
using Xunit;
using animuSharp.ClientClass;
using animuSharp.ClientClass.Internals.Enums;
using animuSharp.ClientClass.Internals.DataTypes;
using System.Diagnostics;

namespace animuSharp.Tests
{
    public class ClientTests
    {
        private const string apikey = "ee576a68fd737d63ca49ccdd9a6ed165c0de2146fa39";

        [Fact]
        public async Task GetGenericURl_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Client client = new Client(apikey);

            // Act
            var result = await client.GetGenericURl(ImageContentType.angry);

            var item = result.Url;

            // Assert
            Debug.WriteLine(item);
            Assert.NotNull(item);
        }

        [Fact]
        public async Task GetTextURl_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Client client = new Client(apikey);

            // Act
            var result = await client.GetTextURl(Textypes.owoify, "Hello world");

            var item = result.TText;

            // Assert
            Debug.WriteLine(item);
            Assert.NotNull(item);
        }

        [Fact]
        public async Task GetMiscURl_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Client client = new Client(apikey);

            // Act
            var result = await client.GetMiscURl<Data.Waifu>(Misc.Waifu);

            var item = result.Names;

            // Assert
            Debug.WriteLine(item);
            Assert.NotNull(item);
        }
    }
}