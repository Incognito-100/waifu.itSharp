# AnimuSharp Documentation

Welcome to the AnimuSharp documentation! AnimuSharp is a C# wrapper for the Waifu.it API, providing easy access to anime-related content.

## Quick Navigation

- [Getting Started](getting-started.md)
- [Basic Usage](basic-usage.md)
- [API Reference](api-reference.md)
- [Examples](examples.md)
- [Changelog](../CHANGELOG.md)

## Quick Start

```cmd
dotnet add package animuSharp
```

```csharp
using animuSharp.Client;

// Create client
var client = new Client("your_api_key_here");

// Get a waifu
var waifu = await client.GetWaifu();
Console.WriteLine($"Name: {waifu.Name.English}");

// Get a quote
var quote = await client.GetQuote();
Console.WriteLine($"{quote.Content} - {quote.Author}");
```

## Features

- 🎯 Easy-to-use API methods
- 📝 Strongly-typed responses
- 🔒 Secure authentication
- ⚡ Async/await support
- 🛠️ Comprehensive error handling
- 📚 Rich documentation

## Need Help?

- [Read the full documentation](getting-started.md)
- [View examples](examples.md)
- [Check the changelog](../CHANGELOG.md)
- [Report an issue](https://github.com/Incognito-100/AnimuSharp/issues)
- [Join Discord](https://discord.gg/yyW389c)
