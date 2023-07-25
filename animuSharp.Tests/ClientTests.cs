using Xunit;
using animuSharp.ClientClass;
using animuSharp.ClientClass.Internals.Enums;
using animuSharp.ClientClass.Internals.DataTypes;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace animuSharp.Tests
{
    public class ClientTests
    {
        private const string apikey = "2b5e4a39abf367d7992a49fea4ee9a70ec879f66e778";

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
            Assert.IsNotNull(item);
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
            Assert.AreEqual("Hewwo world", item);
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
            Assert.IsNotNull(item);
        }
    }
}