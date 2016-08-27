## Synopsis

[![Peppermint](https://github.com/another-guy/Peppermint/raw/master/Peppermint.png)](https://github.com/another-guy/Peppermint)

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

## Tests

Unit tests are available in Peppermint.Tests project.

## License

The code is distributed under the MIT license.

## Reporting an Issue

Reporting an issue, proposing a feature, or asking a question are all great ways to improve software quality.

Here are a few important things that package contributors will expect to see in a new born GitHub issue:
* the relevant version of the package;
* the steps to reproduce;
* the expected result;
* the observed result;
* some code samples illustrating current inconveniences and/or proposed improvements.

## Contributing

Contribution is the best way to improve any project!

1. Fork it!
2. Create your feature branch (```git checkout -b my-new-feature```).
3. Commit your changes (```git commit -am 'Added some feature'```)
4. Push to the branch (```git push origin my-new-feature```)
5. Create new Pull Request

...or follow steps described in a nice [fork guide](http://kbroman.org/github_tutorial/pages/fork.html) by Karl Broman
