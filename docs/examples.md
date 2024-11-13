# Code Examples

Here are some common usage examples for AnimuSharp.

## Character Examples

### Working with Waifus
```csharp
// Get a random waifu
var waifu = await client.GetWaifu();
Console.WriteLine($"Name: {waifu.Name.English}");
Console.WriteLine($"Description: {waifu.Description}");

// Get a specific waifu
var rem = await client.GetWaifu(name: "Rem");
Console.WriteLine($"Anime: {rem.Media.Nodes[0].Title.English}");

// Access different name formats
Console.WriteLine($"English: {waifu.Name.English}");
Console.WriteLine($"Japanese: {waifu.Name.Native}");
Console.WriteLine($"Full Name: {waifu.Name.Full}");
Console.WriteLine($"First Name: {waifu.Name.First}");
Console.WriteLine($"Last Name: {waifu.Name.Last}");

// Get character age and birthday
Console.WriteLine($"Age: {waifu.Age}");
if (waifu.DateOfBirth.Month.HasValue && waifu.DateOfBirth.Day.HasValue)
{
    Console.WriteLine($"Birthday: {waifu.DateOfBirth.Month}/{waifu.DateOfBirth.Day}");
}
```

### Working with Husbandos
```csharp
// Get a random husbando
var husbando = await client.GetHusbando();
Console.WriteLine($"Name: {husbando.Name.English}");

// Get from specific anime
var animeChar = await client.GetHusbando(anime: "Naruto");
Console.WriteLine($"From: {animeChar.Media.Nodes[0].Title.English}");
```

## Quote Examples

### Basic Quote Usage
```csharp
// Get a random quote
var quote = await client.GetQuote();
Console.WriteLine($"{quote.Content} - {quote.Author}");

// Get quote from specific character
var characterQuote = await client.GetQuote(character: "Saki Kusuo");
Console.WriteLine($"{characterQuote.Content} - {characterQuote.Author}");

// Get quote from specific anime
var animeQuote = await client.GetQuote(anime: "Death Note");
Console.WriteLine($"{animeQuote.Content} - {animeQuote.Author}");
```

### Quote Collection
```csharp
// Create a quote collection
var quotes = new List<Data.Quote>();

// Get multiple quotes from same anime
for (int i = 0; i < 5; i++)
{
    var quote = await client.GetQuote(anime: "One Piece");
    quotes.Add(quote);
    // Respect rate limits
    await Task.Delay(200);
}

// Display all quotes
foreach (var q in quotes)
{
    Console.WriteLine($"'{q.Content}' - {q.Author}");
}
```

## Image Examples

### Getting Reaction GIFs
```csharp
// Get a happy reaction
var happy = await client.GetURl(ImageContentType.happy);
Console.WriteLine($"Happy GIF: {happy.Url}");

// Get multiple reactions
var reactions = new Dictionary<string, Uri>();

reactions["happy"] = (await client.GetURl(ImageContentType.happy)).Url;
reactions["dance"] = (await client.GetURl(ImageContentType.dance)).Url;
reactions["wave"] = (await client.GetURl(ImageContentType.wave)).Url;

foreach (var reaction in reactions)
{
    Console.WriteLine($"{reaction.Key}: {reaction.Value}");
}
```

## Text Examples

### Text Transformations
```csharp
// Transform text to owo speak
var text = "Hello, how are you today?";

var owo = await client.GetURl(text, Textypes.owoify);
Console.WriteLine($"OwO: {owo.Content}");

var uwu = await client.GetURl(text, Textypes.uwuify);
Console.WriteLine($"UwU: {uwu.Content}");

var uvu = await client.GetURl(text, Textypes.uvuify);
Console.WriteLine($"UvU: {uvu.Content}");
```

## Media Examples

### Working with Character Media
```csharp
var character = await client.GetWaifu();

foreach (var mediaEntry in character.Media.Nodes)
{
    Console.WriteLine("Media Information:");
    Console.WriteLine($"Title: {mediaEntry.Title.English}");
    Console.WriteLine($"Type: {mediaEntry.Type}");
    Console.WriteLine($"Format: {mediaEntry.Format}");
    
    if (mediaEntry.CoverImage != null)
    {
        Console.WriteLine($"Cover Image: {mediaEntry.CoverImage.Medium}");
    }
    
    if (mediaEntry.BannerImage != null)
    {
        Console.WriteLine($"Banner Image: {mediaEntry.BannerImage}");
    }
    
    if (mediaEntry.Synonyms.Any())
    {
        Console.WriteLine($"Alternative Titles: {string.Join(", ", mediaEntry.Synonyms)}");
    }
}
```

## Error Handling Examples

### Basic Error Handling
```csharp
try
{
    var waifu = await client.GetWaifu();
    Console.WriteLine(waifu.Name.English);
}
catch (ArgumentNullException)
{
    Console.WriteLine("API key not provided");
}
catch (Exception ex) when (ex.Message.Contains("request limits"))
{
    Console.WriteLine("Rate limit exceeded. Please wait.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

### Rate Limit Handling
```csharp
async Task<T> WithRetry<T>(Func<Task<T>> action, int maxRetries = 3)
{
    for (int i = 0; i < maxRetries; i++)
    {
        try
        {
            return await action();
        }
        catch (Exception ex) when (ex.Message.Contains("request limits"))
        {
            if (i == maxRetries - 1) throw;
            await Task.Delay(1000 * (i + 1)); // Exponential backoff
        }
    }
    throw new Exception("Max retries exceeded");
}

// Usage
var waifu = await WithRetry(() => client.GetWaifu());
```

### Batch Processing
```csharp
async Task ProcessBatch<T>(IEnumerable<Func<Task<T>>> actions)
{
    var delay = TimeSpan.FromMilliseconds(200); // 5 requests per second
    foreach (var action in actions)
    {
        try
        {
            var result = await action();
            // Process result
            await Task.Delay(delay);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Usage
var names = new[] { "Rem", "Emilia", "Asuna" };
var actions = names.Select(name => 
    new Func<Task<Data.Waifu>>(() => client.GetWaifu(name: name)));

await ProcessBatch(actions);
```
