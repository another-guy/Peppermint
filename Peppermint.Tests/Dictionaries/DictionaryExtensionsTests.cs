using System.Collections.Generic;
using System.Linq;
using Peppermint.Dictionaries;
using Xunit;

namespace Peppermint.Tests.Dictionaries
{
    public class DictionaryExtensionsTests
    {
        [Fact]
        public void NullToEmptyReturnsOriginalForNonNullDictionary()
        {
            // Arrange
            var ints = new Dictionary<int, int>
            {
                { 1, 1 }
            };

            // Act
            var result = ints.NullToEmpty();

            // Assert
            Assert.Equal(result, ints);
        }

        [Fact]
        public void NullToEmptyReturnsEmptyForNullDictionary()
        {
            // Arrange
            Dictionary<int, int> ints = null;

            // Act
            var result = ints.NullToEmpty();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Count);
        }
    }
}
