using System;
using Xunit;

namespace Peppermint.Tests.PrimitiveTypes
{
    public class ClassExtensionTest
    {
        [Fact]
        public void NullToNewCreatesNewObjectFromOriginalNull()
        {
            // Arrange
            object sut = null;

            // Act
            sut = sut.NullToNew();

            // Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void NullToNewReturnsOriginalObjectFromNonNull()
        {
            // Arrange
            var sut = new object();
            var hashCode = sut.GetHashCode();

            // Act
            sut = sut.NullToNew();

            // Assert
            Assert.NotNull(sut);
            Assert.Equal(hashCode, sut.GetHashCode());
        }
    }
}
