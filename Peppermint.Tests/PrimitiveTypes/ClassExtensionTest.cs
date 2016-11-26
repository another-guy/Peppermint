using System;
using Xunit;

namespace Peppermint.Tests.PrimitiveTypes
{
    public class ClassExtensionTest
    {
        [Fact]
        public void NullToEmptyCreatesNewObjectFromOriginalNull()
        {
            // Arrange
            object sut = null;

            // Act
            sut = sut.NullToEmpty();

            // Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void NullToEmptyReturnsOriginalObjectFromNonNull()
        {
            // Arrange
            var sut = new object();
            var hashCode = sut.GetHashCode();

            // Act
            sut = sut.NullToEmpty();

            // Assert
            Assert.NotNull(sut);
            Assert.Equal(hashCode, sut.GetHashCode());
        }
    }
}
