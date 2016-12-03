namespace Peppermint.Tests.PrimitiveTypes
{
    using System;
    using System.Linq;
    using Xunit;

    public class RangeTests
    {

        [Theory]
        [InlineData(0, 10, -1, "From (0) must be greater or equal to To (10) for step=-1")]
        [InlineData(10, 0, +1, "To (0) must be greater or equal to From (10) for step=1")]
        public void InvalidRangesThrowException(int from, int to, int step, string error)
        {
            // Arrange
            // Act
            var caught = Assert.Throws<InvalidOperationException>(() => new Range(from, to, step));

            // Assert
            Assert.Equal(error, caught.Message);
        }

        [Fact]
        public void RangeWithPositiveStepTranslatesIntoCorrectEnumerable()
        {
            // Arrange
            var range = new Range(-5, 5, +2);
            var expected = new[] { -5, -3, -1, 1, 3, 5 };

            // Act
            var rangeAsEnumerable = range.ToList();

            // Assert
            Assert.True(expected.SequenceEqual(range));
        }

        [Fact]
        public void RangeWithNegativeStepTranslatesIntoCorrectEnumerable()
        {
            // Arrange
            var range = new Range(5, -5, -2);
            var expected = new[] { 5, 3, 1, -1, -3, -5 };

            // Act
            var rangeAsEnumerable = range.ToList();

            // Assert
            Assert.True(expected.SequenceEqual(range));
        }
    }
}
