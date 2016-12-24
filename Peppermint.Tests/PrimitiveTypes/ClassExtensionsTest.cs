using System;
using Xunit;

namespace Peppermint.Tests.PrimitiveTypes
{
    public class ClassExtensionsTest
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

        [Fact]
        public void NullToExceptionThrowsOnNullObject()
        {
            object target = null;
            var name = nameof(target);

            var caught = Assert.Throws<ArgumentNullException>(() =>
                target.NullToException(new ArgumentNullException(name)));

            Assert.Equal(name, caught.ParamName);
        }

        [Fact]
        public void NullToExceptionReturnsSelfWhenObjectIsNotNull()
        {
            var target = new object();
            var name = nameof(target);

            var result = target.NullToException(new ArgumentNullException(name));

            Assert.Same(target, result);
        }
    }
}
