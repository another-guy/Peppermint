namespace Peppermint.Tests.PrimitiveTypes
{
    using System;
    using Xunit;
    using Peppermint.PrimitiveTypes;

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
    }
}
