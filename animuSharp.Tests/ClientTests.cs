using animuSharp.Client.Internals.DataTypes.ExposedTypes;
using animuSharp.Client.Internals.Enums;

namespace animuSharp.Tests
{
	public class ClientTests
	{
		private const string Apikey = "";

		[Fact]
		public async Task GetGenericURl_StateUnderTest_ExpectedBehavior()
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
		public async Task GetTextURl_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			Client.Client client = new(Apikey);

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
			Client.Client client = new(Apikey);

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
			Client.Client client = new(Apikey);

			// Act
			var result = await client.GetURl<Data.Waifu>(Misc.Waifu, name: "Reiko Terayama");

			var item = result.Gender;

			// Assert
			Assert.Equal("Female", item);
		}

		[Fact]
		public async Task Gethusbando_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			Client.Client client = new(Apikey);

			// Act
			var result = await client.GetURl<Data.Husbando>(Misc.husbando);

			var item = result.Gender;

			// Assert
			Assert.Equal("Male", item);
		}

		[Fact]
		public async Task GetQuote_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			Client.Client client = new(Apikey);

			// Act
			var result = await client.GetURl<Data.Quote>(Misc.quote, anime: "death note");

			var item = result.Anime;

			// Assert
			Assert.Equal("Death Note", item);
		}
	}
}