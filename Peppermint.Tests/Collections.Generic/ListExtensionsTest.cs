namespace Peppermint.Tests.Collections.Generic
{
    using System.Collections.Generic;
    using System.Linq;
    using Peppermint.Collections.Generic;
    using Xunit;

    public class ListExtensionsTest
    {
        [Theory]
        [MemberData(nameof(SwapAtWorksData))]
        public void SwapAtWorksOnArray(int index1, int index2, object[] initial, object[] expected)
        {
            // Arrange
            // Act
            initial.SwapAt(index1, index2);
            var result = initial;

            // Assert
            Assert.True(expected.SequenceEqual(result));
        }

        [Theory]
        [MemberData(nameof(SwapAtWorksData))]
        public void SwapAtWorksOnList(int index1, int index2, object[] initial, object[] expected)
        {
            // Arrange
            List<object> list = initial.ToList();

            // Act
            list.SwapAt(index1, index2);
            var result = list;

            // Assert
            Assert.True(expected.SequenceEqual(result), $"{expected} != {result}");
        }

        public static IEnumerable<object[]> SwapAtWorksData =
            new List<object[]> {
                new object[] { 0, 1, new object[] { 0, 1 }, new object[] { 1, 0 } },
                new object[] { 1, 0, new object[] { 0, 1 }, new object[] { 1, 0 } },
                new object[] { 0, 1, new object[] { 0, 1, 2 }, new object[] { 1, 0, 2 } },
                new object[] { 0, 2, new object[] { 0, 1, 2 }, new object[] { 2, 1, 0 } },
                new object[] { 1, 2, new object[] { 0, 1, 2 }, new object[] { 0, 2, 1 } },
                new object[] { 1, 0, new object[] { 0, 1, 2 }, new object[] { 1, 0, 2 } }
            };

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
