# Basic Usage Guide

## Table of Contents
- [Setup](#setup)
- [Basic Operations](#basic-operations)
- [Working with Data](#working-with-data)
- [Best Practices](#best-practices)
- [Common Issues](#common-issues)

## Setup

### Installation
```cmd
dotnet add package animuSharp
```

### Basic Configuration
```csharp
using animuSharp.Client;
using animuSharp.Client.Internals.DataTypes;
using animuSharp.Client.Internals.Enums;

// Create client
var client = new Client("your_api_key_here");
```

## Basic Operations

### Getting Characters
```csharp
// Get a random waifu
var waifu = await client.GetWaifu();

// Get a specific waifu
var rem = await client.GetWaifu(name: "Rem");

// Get a husbando
var husbando = await client.GetHusbando();
```

### Getting Quotes
```csharp
// Random quote
var quote = await client.GetQuote();

// Quote from specific anime
var animeQuote = await client.GetQuote(anime: "Death Note");

// Quote from specific character
var characterQuote = await client.GetQuote(character: "Saki Kusuo");
```

### Getting Facts and Other Content
```csharp
// Get a random fact
var fact = await client.GetFact();

// Get a random password
var password = await client.GetPassword();

// Get available tags
var tags = await client.GetTags();
```

## Working with Data

### Character Information
```csharp
var character = await client.GetWaifu();

// Basic info
Console.WriteLine($"Name: {character.Name.English}");
Console.WriteLine($"Description: {character.Description}");
Console.WriteLine($"Age: {character.Age}");
Console.WriteLine($"Gender: {character.Gender}");

// Images
Console.WriteLine($"Large Image: {character.Image.Large}");
Console.WriteLine($"Medium Image: {character.Image.Medium}");

// Media appearances
foreach (var media in character.Media.Nodes)
{
    Console.WriteLine($"Appears in: {media.Title.English}");
}
```

### Name Formats
```csharp
var character = await client.GetWaifu();
var name = character.Name;

// Different name formats
string englishName = name.English;
string japaneseName = name.Native;
string fullName = name.Full;
string firstName = name.First;
string lastName = name.Last;
string preferredName = name.UserPreferred;

// Alternative names
foreach (var altName in name.Alternative)
{
    Console.WriteLine($"Also known as: {altName}");
}
```

### Media Information
```csharp
var character = await client.GetWaifu();

foreach (var media in character.Media.Nodes)
{
    Console.WriteLine($"Title: {media.Title.English}");
    Console.WriteLine($"Type: {media.Type}");
    Console.WriteLine($"Format: {media.Format}");
    Console.WriteLine($"MAL ID: {media.IdMal}");
    Console.WriteLine($"Popularity: {media.Popularity}");
}
```

## Best Practices

### 1. API Key Security
```csharp
// Don't hardcode API keys
var apiKey = Environment.GetEnvironmentVariable("WAIFU_API_KEY");
var client = new Client(apiKey);
```

### 2. Rate Limit Handling
```csharp
// Ensure you have: using animuSharp.Client.Internals.Exceptions;
try
{
    var result = await client.GetWaifu();
}
catch (AnimuSharpForbiddenException ex) // Catches 403 errors, often due to rate limits or invalid API key
{
    Console.WriteLine($"Rate limit likely hit or API key issue: {ex.Message}");
    // Wait before retrying if it's a rate limit issue
    await Task.Delay(1000);
    // Retry request
}
```

### 3. Null Checking
```csharp
var character = await client.GetWaifu();

// Check optional properties
if (character.Age.HasValue)
{
    Console.WriteLine($"Age: {character.Age}");
}

// Check nested objects
if (character.Media?.Nodes != null)
{
    foreach (var media in character.Media.Nodes)
    {
        if (media.Title?.English != null)
        {
            Console.WriteLine(media.Title.English);
        }
    }
}
```

### 4. Error Handling

The library now uses a set of custom exceptions to provide more detailed error information. These exceptions are located in the `animuSharp.Client.Internals.Exceptions` namespace. It's recommended to include this namespace when handling errors.

```csharp
using animuSharp.Client;
using animuSharp.Client.Internals.Exceptions; // Important for custom exceptions

// Assume 'client' is already initialized:
// var client = new Client("your_api_key_here");

try
{
    var waifu = await client.GetWaifu();
    // ... process data
}
catch (AnimuSharpNotFoundException ex)
{
    // Occurs when the requested resource (e.g., a specific character or image type) is not found (HTTP 404).
    Console.WriteLine($"Resource not found: {ex.Message}");
    // Handle cases where the specific waifu, quote, etc., isn't found.
}
catch (AnimuSharpForbiddenException ex)
{
    // Occurs when access to the resource is forbidden (HTTP 403).
    // This can be due to an invalid API key, or because request limits have been exceeded.
    Console.WriteLine($"Access forbidden: {ex.Message}");
    // Handle API key issues or rate limiting.
}
catch (AnimuSharpServerErrorException ex)
{
    // Occurs when the API server encounters an internal error (HTTP 500+).
    Console.WriteLine($"Server error: {ex.Message}");
    // Handle issues on the API provider's side, possibly by retrying later.
}
catch (AnimuSharpApiException ex)
{
    // This is a base class for other specific API exceptions.
    // It can also be thrown for other API-related errors that don't fit the more specific categories.
    Console.WriteLine($"API error: {ex.Message}");
    // Handle other API related errors.
}
catch (Exception ex)
{
    // Catches any other non-API related exceptions that might occur in your code.
    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
    // Handle other non-API errors.
}
```

**Brief explanation of common custom exceptions:**
-   `AnimuSharpNotFoundException`: Indicates that the requested resource could not be found on the server (404).
-   `AnimuSharpForbiddenException`: Indicates that access to the resource is denied, often due to an invalid/missing API key or exceeding rate limits (403).
-   `AnimuSharpServerErrorException`: Indicates an issue on the server-side (5xx errors).
-   `AnimuSharpApiException`: The base exception for API-related errors. Useful for catching any API error not handled by the more specific exceptions.

It's good practice to import the `animuSharp.Client.Internals.Exceptions` namespace to easily access these custom exception types.

## Common Issues

### Rate Limiting
The API has a rate limit of 5 requests per second. Implement delays between requests:

```csharp
foreach (var name in characterNames)
{
    await Task.Delay(200); // Wait 200ms between requests
    var character = await client.GetWaifu(name: name);
}
```

### Missing Data
Some characters might not have all properties filled:

```csharp
var character = await client.GetWaifu();

// Safe property access
var age = character.Age?.ToString() ?? "Unknown";
var birthMonth = character.DateOfBirth?.Month?.ToString() ?? "Unknown";
var mediaCount = character.Media?.Nodes?.Count ?? 0;
```

### Character Not Found
Handle cases where a character isn't found:

```csharp
try
{
    var character = await client.GetWaifu(name: "NonExistentCharacter");
}
catch (AnimuSharpNotFoundException ex)
{
    Console.WriteLine($"Character not found: {ex.Message}");
    // Fall back to random character or handle as appropriate
    // character = await client.GetWaifu();
}
```

### Invalid API Key
Handle invalid API key scenarios. This typically results in a `AnimuSharpForbiddenException`.

```csharp
// Ensure you have: using animuSharp.Client.Internals.Exceptions;
// Assume 'client' is initialized with an invalid key, e.g.:
// var client = new Client("invalid_or_empty_api_key");

try
{
    var result = await client.GetWaifu();
}
catch (AnimuSharpForbiddenException ex)
{
    Console.WriteLine($"Invalid API key or access forbidden: {ex.Message}");
    // Advise the user to check their API key and that it's correctly set up.
}
```
