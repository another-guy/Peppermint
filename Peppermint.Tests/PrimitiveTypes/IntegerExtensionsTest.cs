namespace Peppermint.Tests.PrimitiveTypes
{
    using System;
    using System.Linq;
    using NSubstitute;
    using Xunit;
    using TestUtilities;

    public class IntegerExtensionsTest
    {
        private readonly ITarget target;
        private readonly Action action;

        public IntegerExtensionsTest()
        {
            target = Substitute.For<ITarget>();
            action = target.TestMethod;
        }

        [Fact]
        public void TimesActionWorksForPositive()
        {
            // Arrange
            var times = 5;

            // Act
            times.Times(action);

            // Assert
            target.Received(times).TestMethod();
        }

        [Theory]
        [InlineData(-1024)]
        [InlineData(-1)]
        [InlineData(0)]
        public void TimesActionWorksForPositiveAndNegative(int times)
        {
            // Arrange
            // Act
            times.Times(action);

            // Assert
            target.Received(0).TestMethod();
        }

        [Fact]
        public void TimesFuncWorksForPositive()
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
        public void TimesFuncWorksForPositiveAndNegative(int target)
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
    }
}
