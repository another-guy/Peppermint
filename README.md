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

ArrayExtensions:
```cs
string[] array = null;
array = array.NullToEmpty();
var length = array.Length; // length == 0, no exception here.
```

ListExtensions:
```cs
string[] ints = new[] { "Alice", "Bob" };
list.SwapAt(0, 1); // Swaps items in place. The array is now []{ "Bob", "Alice" }
```

Sequence:
```cs
// Other sequence types or even custom sequence generators can be used.
var integers = Sequence
	.WithoutDuplicates(Sequence.NaturalNumbers)
	.Take(5)
	.ToList(); // Results in a List<int>() { 1, 2, 3, 4, 5 }

// Sequence start number and sequence step can be explicitly provided if necessary.
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

Unit tests are available in Peppermint.Tests project.

## License

The code is distributed under the MIT license.