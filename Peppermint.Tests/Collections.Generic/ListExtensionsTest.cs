namespace Peppermint.Tests.Collections.Generic
{
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class ListExtensionsTest
    {
        [Theory]
        [MemberData(nameof(ArraySwapAtWorksData))]
        public void SwapAtWorksOnArray(int index1, int index2, object[] initial, object[] expected)
        {
            // Arrange
            // Act
            initial.SwapAt(index1, index2);
            var result = initial;

            // Assert
            Assert.True(expected.SequenceEqual(result));
        }

        public static IEnumerable<object[]> ArraySwapAtWorksData =
            new List<object[]> {
                new object[] { 0, 0, new object[] { 1 }, new object[] { 1 } },
                new object[] { 0, 1, new object[] { 0, 1 }, new object[] { 1, 0 } },
                new object[] { 1, 0, new object[] { 0, 1 }, new object[] { 1, 0 } },
                new object[] { 0, 1, new object[] { 0, 1, 2 }, new object[] { 1, 0, 2 } },
                new object[] { 0, 2, new object[] { 0, 1, 2 }, new object[] { 2, 1, 0 } },
                new object[] { 1, 2, new object[] { 0, 1, 2 }, new object[] { 0, 2, 1 } },
                new object[] { 1, 0, new object[] { 0, 1, 2 }, new object[] { 1, 0, 2 } }
            };

        [Theory]
        [MemberData(nameof(ListSwapAtWorksData))]
        public void SwapAtWorksOnList(int index1, int index2, object[] initial, object[] expected)
        {
            // Arrange
            List<object> list = initial.ToList();

            // Act
            list.SwapAt(index1, index2);
            var result = list;

            // Assert
            Assert.True(expected.SequenceEqual(result), $"{expected.AsString()} != {result.AsString()}");
        }

        public static IEnumerable<object[]> ListSwapAtWorksData =
            new List<object[]> {
                new object[] { 0, 0, new object[] { 1 }, new object[] { 1 } },
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
