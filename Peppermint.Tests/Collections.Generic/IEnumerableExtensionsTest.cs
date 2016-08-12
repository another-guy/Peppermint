using System.Collections.Generic;
using System.Linq;
using Xunit;
using Peppermint.Collections.Generic;

namespace Peppermint.Tests.Collections.Generic
{
    public class IEnumerableExtensionsTest
    {
        [Fact]
        public void NullToEmptyReturnsOriginalForNonNullArray()
        {
            // Arrange
            IEnumerable<int> ints = new[] { 1, 2, 3 };

            // Act
            var result = ints.NullToEmpty();

            // Assert
            Assert.True(result.SequenceEqual(ints));
        }

        [Fact]
        public void NullToEmptyReturnsEmptyForNullArray()
        {
            // Arrange
            IEnumerable<int> ints = null;

            // Act
            var result = ints.NullToEmpty();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Count());
        }
    }
}
