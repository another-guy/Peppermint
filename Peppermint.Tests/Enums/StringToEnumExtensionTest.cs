using System;
using Peppermint.Enums;
using Xunit;

namespace Peppermint.Tests.Enums
{
    public class StringToEnumExtensionTest
    {
        [Theory]
        [InlineData("ValueA", TestEnum.ValueA)]
        [InlineData("valuea", TestEnum.ValueA)]
        [InlineData("ValueB", TestEnum.ValueB)]
        [InlineData("valueb", TestEnum.ValueB)]
        public void CanParseCorrectValues(string stringValue, TestEnum expected)
        {
            // Arrange
            // Act
            var result = stringValue.Parse<TestEnum>();
            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData("", typeof(ArgumentException))]
        [InlineData("noSuchValue", typeof(ArgumentException))]
        public void ThrowsExceptionOnIncorrectValue(string stringValue, Type exceptionType)
        {
            // Arrange
            // Act
            var e = Assert.Throws(exceptionType, () => stringValue.Parse<TestEnum>());
            
            // Assert
            Assert.Equal(exceptionType, e.GetType());
        }
    }

    public enum TestEnum
    {
        ValueA,
        ValueB
    }
}
