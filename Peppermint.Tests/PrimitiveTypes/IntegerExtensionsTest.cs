using System.Linq;
using Xunit;
using Peppermint.PrimitiveTypes;
using System;

namespace Peppermint.Tests.PrimitiveTypes
{
    public class IntegerExtensionsTest
    {
        [Fact]
        public void TimesWorksForPositive()
        {
            // Arrange
            var target = 5;
            var c = 0;

            // Act
            var indices = target.Times(() => c++);

            // Assert
            Assert.True(new[] { 0, 1, 2, 3, 4 }.SequenceEqual(indices));
        }

        [Theory]
        [InlineData(-1024)]
        [InlineData(-1)]
        [InlineData(-0)]
        public void TimesWorksForPositiveAndNegative(int target)
        {
            // Arrange
            var c = 0;

            // Act
            var indices = target.Times(() => c++);

            // Assert
            Assert.True(new int[0].SequenceEqual(indices));
        }

        [Theory]
        [InlineData(0, 10, +1)]
        [InlineData(10, 0, -1)]
        [InlineData(0, 10, +10)]
        [InlineData(10, 0, -10)]
        [InlineData(1, 1, +1)]
        [InlineData(1, 1, -1)]
        public void ValidRangesCreatedAsIs(int from, int to, int step)
        {
            // Arrange
            // Act
            var range = from.To(to, step);

            // Assert
            Assert.Equal(from, range.from);
            Assert.Equal(to, range.to);
            Assert.Equal(step, range.step);
        }

        [Theory]
        [InlineData(0, 10, +1)]
        [InlineData(10, 0, -1)]
        public void ValidRangesWithoutStepHaveGuessedSteps(int from, int to, int expextedStep)
        {
            // Arrange
            // Act
            var range = from.To(to);

            // Assert
            Assert.Equal(from, range.from);
            Assert.Equal(to, range.to);
            Assert.Equal(expextedStep, range.step);
        }
    }
}
