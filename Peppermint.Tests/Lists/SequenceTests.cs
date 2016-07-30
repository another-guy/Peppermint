using System.Linq;
using Peppermint.Lists;
using Xunit;

namespace Peppermint.Tests.Lists
{
    public class SequenceTests
    {
        [Fact]
        public void TestNaturalSequenceAllPositive()
        {
            // Arrange
            // Act
            var fiveNatural = Sequence
                .ListWithoutDuplicates(Sequence.Natural)
                .Take(5)
                .ToList();

            // Assert
            Assert.True(new[] { 1, 2, 3, 4, 5 }.SequenceEqual(fiveNatural));
        }

        [Fact]
        public void TestNaturalSequenceShifted()
        {
            // Arrange
            // Act
            var fiveNatural = Sequence
                .ListWithoutDuplicates(Sequence.Ceil, 2)
                .Take(5)
                .ToList();

            // Assert
            Assert.True(new[] { 2, 3, 4, 5, 6 }.SequenceEqual(fiveNatural));
        }

        [Fact]
        public void TestNaturalSequenceWithNegativeStep()
        {
            // Arrange
            // Act
            var fiveNatural = Sequence
                .ListWithoutDuplicates(Sequence.Ceil, stepOverride: -1)
                .Take(5)
                .ToList();

            // Assert
            Assert.True(new[] { 0, -1, -2, -3, -4 }.SequenceEqual(fiveNatural));
        }
    }
}
