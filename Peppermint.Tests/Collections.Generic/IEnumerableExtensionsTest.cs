﻿namespace Peppermint.Tests.Collections.Generic
{
    using NSubstitute;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class IEnumerableExtensionsTest
    {
        private readonly IEnumerable<int> ints = new[] { 1, 2, 3 };

        [Fact]
        public void NullToEmptyReturnsOriginalForNonNullArray()
        {
            // Act
            var result = ints.NullToEmpty();

            // Assert
            Assert.True(result.SequenceEqual(ints));
        }

        [Fact]
        public void NullToEmptyReturnsEmptyForNullArray()
        {
            // Act
            var result = ((IEnumerable<int>)null).NullToEmpty();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Count());
        }

        [Fact]
        public void CanTakeProjectEverythingAsIs()
        {
            // Act
            var projected = ints.TakeProject(item => true, item => item);

            // Assert
            Assert.True(ints.SequenceEqual(projected));
        }

        [Fact]
        public void CanTakeProjectNothing()
        {
            // Act
            var projected = ints.TakeProject(item => false, item => item);

            // Assert
            Assert.True(new List<int>().SequenceEqual(projected));
        }

        [Fact]
        public void CanTakeProjectAndChangeType()
        {
            // Act
            var projected = ints.TakeProject(item => true, item => item.ToString());

            // Assert
            Assert.True(new string[] { "1", "2", "3" }.SequenceEqual(projected));
        }

        [Fact]
        public void CanTakeProjectPartially()
        {
            // Act
            var projected = ints.TakeProject(item => item % 2 == 0, item => item);

            // Assert
            Assert.True(new int[] { 2 }.SequenceEqual(projected));
        }

        [Fact]
        public void CanTakeProjectMany()
        {
            // Act
            var projected = ints.TakeProjectMany(item => true, item => new List<int> { item, item, item });

            // Assert
            Assert.True(new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3 }.SequenceEqual(projected));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(1024)]
        public void ForEach(int totalItems)
        {
            // Arrange
            var helper = Substitute.For<ITestHelper<int>>();
            var enumerable = new List<int>();
            for (var i = 0; i < totalItems; i++)
                enumerable.Add(i + 1);

            // Act
            IEnumerableExtensions.ForEach(enumerable, item => helper.Register(item));

            // Assert
            foreach (var value in enumerable)
                helper.Received(1).Register(value);
        }

        [Fact]
        public void NoneCanCorrectlyReturnTrue()
        {
            // Act
            var noneAreGreaterThanFive = ints.None(item => item > 5);
            // Assert
            Assert.True(noneAreGreaterThanFive);
        }

        [Fact]
        public void NoneCanCorrectlyReturnFalse()
        {
            // Act
            var noneAreLessThanFive = ints.None(item => item < 5);
            // Assert
            Assert.False(noneAreLessThanFive);
        }
    }

    public interface ITestHelper<T>
    {
        void Register(T item);
    }
}
