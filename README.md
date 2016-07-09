## Synopsis

Provides a bit of C# syntactic sugar

## Code Example

StringToEnumExtension:

```cs
enum MyEnum
{
  One = 1,
  Two = 2
}

string @string = "One";
MyEnum value = @string.Parse<MyEnum>();
```

DictionaryExtensions:
```cs
IDictionary<string, object> dict = null;
dict = dict.NullToEmpty();
var size = dict.Count; // size == 0, no exception here.
```

## Motivation

Syntax sugar is syntax sugar: it's not a necessary thing per se but it can improve code quality.

## Installation

Peppermint is a available in a form of a NuGet package.
Follow regular installation process to bring it to your project.
https://www.nuget.org/packages/Peppermint/

## API Reference

// TODO

## Tests

There are no automated tests for the project at the moment.

## License

The code is distributed under the MIT license.