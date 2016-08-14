namespace Peppermint.Tests.Collections.Generic
{
    using System;
    using System.Linq;
    using Peppermint.Collections.Generic;
    using Xunit;

    public class SequenceTest
    {
        [Fact]
        public void ThrowsException()
        {
            // Arrange
            var sequence = Sequence.WithoutDuplicates<int>(null);

            // Act
            var caught = Assert.Throws<ArgumentNullException>(() => sequence.Take(1).ToList());

            // Assert
            Assert.True(caught.Message.Contains("sequenceItemGenerator"));
        }

        [Fact]
        public void NaturalSequenceAllPositive()
        {
            // Arrange
            // Act
            var fiveNatural = Sequence
                .WithoutDuplicates(Sequence.NaturalNumbers)
                .Take(5)
                .ToList();

            // Assert
            Assert.True(new[] { 1, 2, 3, 4, 5 }.SequenceEqual(fiveNatural));
        }

        [Fact]
        public void CeilSequenceShifted()
        {
            // Arrange
            // Act
            var fiveNatural = Sequence
                .WithoutDuplicates(Sequence.CeilNumbers, baseOverride: 2)
                .Take(5)
                .ToList();

            // Assert
            Assert.True(new[] { 2, 3, 4, 5, 6 }.SequenceEqual(fiveNatural));
        }

        [Fact]
        public void CeilSequenceWithNegativeStep()
        {
            // Arrange
            // Act
            var fiveNatural = Sequence
                .WithoutDuplicates(Sequence.CeilNumbers, stepOverride: -1)
                .Take(5)
                .ToList();

            // Assert
            Assert.True(new[] { 0, -1, -2, -3, -4 }.SequenceEqual(fiveNatural));
        }

        [Fact]
        public void CeilSequenceShiftedAndWithNegativeStep()
        {
            // Arrange
            // Act
            var fiveNatural = Sequence
                .WithoutDuplicates(Sequence.CeilNumbers, baseOverride: 2, stepOverride: -1)
                .Take(5)
                .ToList();

            // Assert
            Assert.True(new[] { 2, 1, 0, -1, -2 }.SequenceEqual(fiveNatural));
        }
    }
}
