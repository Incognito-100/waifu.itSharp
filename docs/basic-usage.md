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
try
{
    var result = await client.GetWaifu();
}
catch (Exception ex) when (ex.Message.Contains("request limits"))
{
    // Wait before retrying
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
```csharp
try
{
    var result = await client.GetWaifu();
}
catch (ArgumentNullException)
{
    // Handle missing API key
}
catch (Exception ex) when (ex.Message == "Not Found")
{
    // Handle not found
}
catch (Exception ex) when (ex.Message.Contains("request limits"))
{
    // Handle rate limit
}
catch (Exception ex)
{
    // Handle other errors
    Console.WriteLine($"Error: {ex.Message}");
}
```

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
catch (Exception ex) when (ex.Message == "Not Found")
{
    Console.WriteLine("Character not found");
    // Fall back to random character
    character = await client.GetWaifu();
}
```

### Invalid API Key
Handle invalid API key scenarios:

```csharp
try
{
    var client = new Client("invalid_key");
    var result = await client.GetWaifu();
}
catch (Exception ex) when (ex.Message == "Forbidden")
{
    Console.WriteLine("Invalid API key. Please check your credentials.");
}
```
