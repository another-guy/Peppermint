namespace Peppermint.Tests.PrimitiveTypes
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using NSubstitute;
    using Xunit;
    using Peppermint.Tests.TestUtilities;

    public class RangeExtensionsTest
    {
        private readonly ITarget target;
        private readonly Action action;

        public RangeExtensionsTest()
        {
            target = Substitute.For<ITarget>();
            action = target.TestMethod;
        }

        [Theory]
        [MemberData(nameof(ToSequenceTestData))]
        public void ToSequenceWorks(int from, int to, int step, int[] expected)
        {
            // Arrange
            var range = new Range(from, to, step);

            // Act
            var list = range
                .ToSequence(i => i)
                .ToList();

            // Assert
            Assert.True(expected.SequenceEqual(list));
        }

        public static IEnumerable<object[]> ToSequenceTestData =
            new List<object[]>
            {
                new object[] { 0, 0, 10, new[] { 0 } },
                new object[] { 5, 5, 10, new[] { 5 } },
                new object[] { 0, 1, 10, new[] { 0 } },
                new object[] { 0, 0, 1, new[] { 0 } },
                new object[] { 5, 5, 1, new[] { 5 } },
                new object[] { 0, 1, 1, new[] { 0, 1 } },
                new object[] { 0, 5, 2, new[] { 0, 2, 4 } },
                new object[] { 1, 1, 1, new[] { 1 } },
                new object[] { 1, 6, 1, new[] { 1, 2, 3, 4, 5, 6 } },
                new object[] { 1, 2, 1, new[] { 1, 2 } },
                new object[] { 6, 1, -1, new[] { 6, 5, 4, 3, 2, 1 } },
                new object[] { 1, -1, -1, new[] { 1, 0, -1 } },
                new object[] { -2, -2, -1, new[] { -2 } },
                new object[] { 0, -10, -2, new[] { 0, -2, -4, -6, -8, -10 } }
            };

        [Theory]
        [MemberData(nameof(DoTestData))]
        public void DoWorks(int from, int to, int step, int totalCount)
        {
            // Arrange
            var range = new Range(from, to, step);

            // Act
            range.Do(action);

            // Assert
            target.Received(totalCount).TestMethod();
        }

        public static IEnumerable<object[]> DoTestData =
            new List<object[]>
            {
                new object[] { 0, 0, 10, 1 },
                new object[] { 5, 5, 10, 1 },
                new object[] { 0, 1, 10, 1 },
                new object[] { 0, 0, 1, 1 },
                new object[] { 5, 5, 1, 1 },
                new object[] { 0, 1, 1, 2 },
                new object[] { 0, 5, 2, 3 },
                new object[] { 1, 1, 1, 1 },
                new object[] { 1, 6, 1, 6 },
                new object[] { 1, 2, 1, 2 },
                new object[] { 6, 1, -1, 6 },
                new object[] { 1, -1, -1, 3 },
                new object[] { -2, -2, -1, 1 },
                new object[] { 0, -10, -2, 6 }
            };
    }
}
