namespace Peppermint.Tests.PrimitiveTypes
{
    using System;
    using Xunit;

    public class StringExtensionsTest
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("a", "a")]
        [InlineData("b", "b")]
        [InlineData("ab", "ba")]
        [InlineData("xz", "zx")]
        [InlineData("abc", "cba")]
        [InlineData("xyz", "zyx")]
        public void ReverseWorks(string target, string expected)
        {
            // Arrange
            var sut = target;

            // Act
            var result = sut.Reverse();

            // Assert
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData("", "", "")]
        [InlineData("", "suffix", "suffix")]
        [InlineData("value", "-suffix", "value-suffix")]
        [InlineData("value", "", "value")]
        public void WithSuffixWorks(string original, string suffix, string result)
        {
            // Arrange
            // Act
            var actualResult = original.WithSuffix(suffix);

            // Assert
            Assert.Equal(result, actualResult);
        }

        [Fact]
        public void WithSuffixThrowsExceptionForNullPrefix()
        {
            // Arrange
            // Act
            var caught = Assert.Throws<ArgumentNullException>(() => "value".WithSuffix(null));
            // Assert
            Assert.True(caught.Message.Contains("suffix"));
        }

        [Theory]
        [InlineData("", "", "")]
        [InlineData("", "prefix", "prefix")]
        [InlineData("value", "prefix-", "prefix-value")]
        [InlineData("value", "", "value")]
        public void WithPrefixWorks(string original, string prefix, string result)
        {
            // Arrange
            // Act
            var actualResult = original.WithPrefix(prefix);

            // Assert
            Assert.Equal(result, actualResult);
        }

        [Fact]
        public void WithPrefixThrowsExceptionForNullPrefix()
        {
            // Arrange
            // Act
            var caught = Assert.Throws<ArgumentNullException>(() => "value".WithPrefix(null));
            // Assert
            Assert.True(caught.Message.Contains("prefix"));
        }

        [Theory]
        [InlineData("test", 1, "est")]
        [InlineData("test", 2, "st")]
        [InlineData("test", 3, "t")]
        [InlineData("test", 4, "")]
        [InlineData("test", 5, "")]
        public void TrimFirstWorks(string original, int trimCount, string expected)
        {
            // Arrange
            // Act
            var actual = original.TrimFirst(trimCount);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("test", 1, "tes")]
        [InlineData("test", 2, "te")]
        [InlineData("test", 3, "t")]
        [InlineData("test", 4, "")]
        [InlineData("test", 5, "")]
        public void TrimLastWorks(string original, int trimCount, string expected)
        {
            // Arrange
            // Act
            var actual = original.TrimLast(trimCount);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\t")]
        [InlineData("word")]
        public void IsNullOrEmptyWorks(string target)
        {
            // Assert
            Assert.Equal(string.IsNullOrEmpty(target), target.IsNullOrEmpty());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\t")]
        [InlineData("word")]
        public void IsNullOrWhiteSpaceWorks(string target)
        {
            // Assert
            Assert.Equal(string.IsNullOrWhiteSpace(target), target.IsNullOrWhiteSpace());
        }
    }
}
