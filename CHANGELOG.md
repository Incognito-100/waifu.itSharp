# Changelog

## [2.0.0] - 2024

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

### Developer Experience
- Added more intuitive method names
- Improved IntelliSense support with specific return types
- Added XML documentation for better IDE support
- Simplified API usage by removing need for generic type parameters
- Added comprehensive examples and best practices
- Improved documentation organization and accessibility