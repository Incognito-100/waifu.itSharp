# API Reference

## Character Endpoints

### GetWaifu
```csharp
Task<Data.Waifu> GetWaifu(string name = null, string anime = null)
```
Get a female character from the database.

**Parameters:**
- `name` (optional): Filter by character name
- `anime` (optional): Filter by anime name

**Returns:** Waifu object with the following properties:
```csharp
public class Waifu
{
    public long? Id { get; set; }           // Character ID
    public Name Name { get; set; }          // Character names
    public Image Image { get; set; }        // Character images
    public string Description { get; set; } // Character description
    public int? Age { get; set; }          // Character age
    public string Gender { get; set; }     // Character gender
    public string BloodType { get; set; }  // Blood type
    public DateOfBirth DateOfBirth { get; set; }
    public Media Media { get; set; }       // Related media
}
```

### GetHusbando
```csharp
Task<Data.Husbando> GetHusbando(string name = null, string anime = null)
```
Get a male character from the database.

**Parameters:**
- `name` (optional): Filter by character name
- `anime` (optional): Filter by anime name

**Returns:** Husbando object (same properties as Waifu)

## Quote Endpoints

### GetQuote
```csharp
Task<Data.Quote> GetQuote(string character = null, string anime = null)
```
Get an anime quote.

**Parameters:**
- `character` (optional): Filter by character name
- `anime` (optional): Filter by anime name

**Returns:**
```csharp
public class Quote
{
    public long? Id { get; set; }      // Quote ID
    public string Content { get; set; } // Quote text
    public string Author { get; set; }  // Character who said it
    public string Anime { get; set; }   // Anime source
}
```

## Image Endpoints

### GetURl (Image)
```csharp
Task<Data.Generic> GetURl(ImageContentType content)
```
Get an image URL for the specified content type.

**Parameters:**
- `content`: Image content type (enum)

Available content types:
- angry
- baka
- bite
- blush
- bonk
- bored
- cry
- cuddle
- dance
- happy
- kiss
- laugh
- pat
- smile
- wave
- wink

**Returns:**
```csharp
public class Generic
{
    public Uri Url { get; set; } // Image URL
}
```

## Text Endpoints

### GetURl (Text)
```csharp
Task<Data.Text> GetURl(string text, Textypes content)
```
Transform text using specified type.

**Parameters:**
- `text`: Text to transform
- `content`: Transformation type

Available types:
- owoify
- uvuify
- uwuify

**Returns:**
```csharp
public class Text
{
    public string Content { get; set; } // Transformed text
}
```

## Miscellaneous Endpoints

### GetFact
```csharp
Task<Data.Fact> GetFact()
```
Get a random anime fact.

**Returns:**
```csharp
public class Fact
{
    public long? Id { get; set; }         // Fact ID
    public string Content { get; set; }    // Fact text
}
```

### GetPassword
```csharp
Task<Data.Password> GetPassword()
```
Get a random password.

**Returns:**
```csharp
public class Password
{
    public string Value { get; set; } // Generated password
}
```

### GetTags
```csharp
Task<Data.Generic> GetTags()
```
Get available tags.

**Returns:**
```csharp
public class Generic
{
    public Uri Url { get; set; } // Tags URL
}
```

## Common Types

### Name
```csharp
public class Name
{
    public string First { get; set; }          // First name
    public string Last { get; set; }           // Last name
    public string Full { get; set; }           // Full name
    public string Native { get; set; }         // Native (Japanese) name
    public string English { get; set; }        // English name
    public string UserPreferred { get; set; }  // Preferred name format
    public List<string> Alternative { get; set; }        // Alternative names
    public List<string> AlternativeSpoiler { get; set; } // Spoiler names
}
```

### Media
```csharp
public class Media
{
    public List<MediaEntry> Nodes { get; set; } // Related media entries
}

public class MediaEntry
{
    public long? Id { get; set; }           // Media ID
    public long? IdMal { get; set; }        // MyAnimeList ID
    public Title Title { get; set; }        // Media titles
    public string Type { get; set; }        // Media type
    public string Format { get; set; }      // Media format
    public CoverImage CoverImage { get; set; }
    public Uri BannerImage { get; set; }
    public List<string> Synonyms { get; set; }
    public long? Popularity { get; set; }
}
```

## Error Handling

The client throws exceptions for various scenarios:

```csharp
try
{
    var result = await client.GetWaifu();
}
catch (ArgumentNullException)
{
    // API key was null
}
catch (Exception ex) when (ex.Message == "Not Found")
{
    // Resource not found
}
catch (Exception ex) when (ex.Message.Contains("request limits"))
{
    // Rate limit exceeded
}
catch (Exception ex) when (ex.Message == "Internal Server Error")
{
    // API server error
}
```
