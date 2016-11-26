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
    }
}
