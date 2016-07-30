using System.Collections.Generic;
using System.Linq;
using Peppermint.Lists;
using Xunit;

namespace Peppermint.Tests.Lists
{
    public class ListExtensionsTests
    {
        [Fact]
        public void SwapWorks()
        {
            // Arrange
            var list = new[] {1, 2};

            // Act
            list.SwapAt(0, 1);

            // Assert
            Assert.True(new[] {2, 1}.SequenceEqual(list));
        }

        [Fact]
        public void ShuffleWorks()
        {
            // Arrange
            var original = Sequence
                .WithoutDuplicates(Sequence.NaturalNumbers)
                .Take(50)
                .ToList();
            var clone = new List<int>(original);
            var clone2 = new List<int>(original);

            // Act
            original.Shuffle(1024);

            // Assert
            Assert.True(clone.SequenceEqual(clone2));
            Assert.False(clone.SequenceEqual(original));
        }
    }
}
