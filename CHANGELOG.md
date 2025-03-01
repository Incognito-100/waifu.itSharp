# Changelog

## [2.4.2] - 2025
### Changed
- changed `animuSharpClient` to use a primary constructor

## [2.4.1] - 2024
### Added
- Added comprehensive user-friendly documentation for all data types
- Added detailed explanations for anime/manga-specific concepts
- Added context-specific documentation for properties like blood types and character names
- Added clear descriptions for all character attributes and media information
- documentation strings for

### Changed
- Converted all classes to records in Data.cs for better immutability and value semantics
- Improved property documentation to be more approachable for non-technical users
- Enhanced readability of documentation with practical examples
- Reorganized properties for better logical grouping

### Improved
- Documentation now explains anime-specific terms and concepts
- Better descriptions for multilingual properties (names, titles)
- Clearer explanations for media types and formats
- More intuitive property descriptions for character information

## [2.4.0] - 2024

### Breaking Changes
- Removed generic `GetURl<T>` method for Misc endpoints in favor of specific endpoint methods
- Renamed `Node` class to `MediaEntry` for better clarity
- Changed property names to be more descriptive (e.g., `QuoteQuote` to `Content`, `FactFact` to `Content`)

### Added
- New specific endpoint methods:
  - `GetWaifu()` - Get a waifu character
  - `GetHusbando()` - Get a husbando character
  - `GetQuote()` - Get an anime quote
  - `GetFact()` - Get a random anime fact
  - `GetPassword()` - Get a random password
  - `GetTags()` - Get available tags
- Added proper XML documentation for all public methods and classes
- Added collection initializers to prevent null reference exceptions
- Added comprehensive test coverage for all endpoints and properties
- Added GitHub-based documentation:
  - Getting Started guide
  - Basic Usage guide
  - API Reference
  - Code Examples
  - Best Practices

### Changed
- Optimized code structure by removing duplicate classes
- Consolidated shared character properties into `CharacterBase` class
- Improved type safety by replacing `dynamic` types with specific types
- Renamed properties for better clarity:
  - `TText` -> `Content` in Text class
  - `QuoteQuote` -> `Content` in Quote class
  - `FactFact` -> `Content` in Fact class
  - `Pass` -> `Value` in Password class
  - `Node` -> `MediaEntry` in Media class
- Improved parameter names (e.g., `character` instead of `name` for quotes)
- Reduced code size from ~500 to ~110 lines while maintaining functionality
- Migrated documentation from GitBook to GitHub for better maintainability

### Fixed
- Fixed potential null reference issues with collections
- Improved type safety for date properties
- Made property names more consistent across classes