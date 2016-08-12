using System.Linq;
using Peppermint.Arrays;
using Xunit;

namespace Peppermint.Tests.Arrays
{
    public class ArrayExtensionsTest
    {
        [Fact]
        public void NullToEmptyReturnsOriginalForNonNullArray()
        {
            // Arrange
            var ints = new[] {1, 2, 3};

            // Act
            var result = ints.NullToEmpty();

            // Assert
            Assert.True(result.SequenceEqual(ints));
        }

        [Fact]
        public void NullToEmptyReturnsEmptyForNullArray()
        {
            // Arrange
            int[] ints = null;

            // Act
            var result = ints.NullToEmpty();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Length);
        }
    }
}
