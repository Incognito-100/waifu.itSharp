# Getting Started with AnimuSharp

## Installation

Install AnimuSharp via NuGet:

```cmd
dotnet add package animuSharp
```

## Prerequisites

1. Get your API key from the [Waifu.it Discord](https://discord.gg/yyW389c):
   - Join the Discord server
   - Use `-claim` command in #bot-commands
   - Save your API key securely

2. Add the required using statements:
```csharp
using animuSharp.Client;
using animuSharp.Client.Internals.DataTypes;
using animuSharp.Client.Internals.Enums;
```

## Creating a Client

```csharp
// Create a new client instance
var client = new Client("your_api_key_here");

// Best practice: Use configuration or environment variables
var apiKey = Environment.GetEnvironmentVariable("WAIFU_API_KEY");
var client = new Client(apiKey);
```

## Rate Limits

- The API has a rate limit of 5 requests per second
- Handle rate limits appropriately in your code:

```csharp
try
{
    var waifu = await client.GetWaifu();
}
catch (Exception ex) when (ex.Message.Contains("request limits"))
{
    // Wait and retry or implement backoff strategy
    await Task.Delay(1000);
    // Retry request
}
```

## Basic Examples

### Getting Character Information
```csharp
// Get a random waifu
var waifu = await client.GetWaifu();
Console.WriteLine($"Name: {waifu.Name.English}");
Console.WriteLine($"Description: {waifu.Description}");

// Get a specific character
var rem = await client.GetWaifu(name: "Rem");
Console.WriteLine($"From: {rem.Media.Nodes[0].Title.English}");

// Get a husbando
var husbando = await client.GetHusbando();
Console.WriteLine($"Name: {husbando.Name.English}");
```

### Getting Quotes
```csharp
// Random quote
var quote = await client.GetQuote();
Console.WriteLine($"{quote.Content} - {quote.Author}");

// Quote from specific anime
var animeQuote = await client.GetQuote(anime: "Death Note");
Console.WriteLine($"{animeQuote.Content} - {animeQuote.Author}");
```

### Getting Facts
```csharp
var fact = await client.GetFact();
Console.WriteLine($"Did you know? {fact.Content}");
```

## Next Steps

- Check out the [Basic Usage Guide](basic-usage.md) for more examples
- See the [API Reference](api-reference.md) for detailed endpoint documentation
- View [Examples](examples.md) for common scenarios
- Read about [Best Practices](basic-usage.md#best-practices)

## Need Help?

- [Report issues on GitHub](https://github.com/Incognito-100/AnimuSharp/issues)
- [Join our Discord community](https://discord.gg/yyW389c)
- Check the [API Reference](api-reference.md) for detailed documentation
