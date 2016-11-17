using Xunit;
namespace Peppermint.Tests.Collections.Generic
{
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using Peppermint.Collections.Generic;
    using System;

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
        public void CanFlexProjectEverythingAsIs()
        {
            // Act
            var projected = ints.FlexProject(item => (ProjectAs<int>)item);

            // Assert
            Assert.True(ints.SequenceEqual(projected));
        }

        [Fact]
        public void CanFlexProjectNothing()
        {
            // Act
            var projected = ints.FlexProject(item => ProjectAs<int>.Nothing);

            // Assert
            Assert.True(new List<int>().SequenceEqual(projected));
        }

        [Fact]
        public void CanFlexProjectAndChangeType()
        {
            // Act
            var projected = ints.FlexProject(item => (ProjectAs<string>)item.ToString());

            // Assert
            Assert.True(new string[] { "1", "2", "3" }.SequenceEqual(projected));
        }

        [Fact]
        public void CanFlexProjectPartially()
        {
            // Act
            var projected = ints.FlexProject(item => item % 2 == 0 ? item : ProjectAs<int>.Nothing);

            // Assert
            Assert.True(new int[] { 2 }.SequenceEqual(projected));
        }

        [Fact]
        public void CanFlexProjectToEnumerable()
        {
            // Act
            var projected = ints.FlexProject(item => ((ProjectAs<IEnumerable<int>>)new[] { item, item, item }));

            // Assert
            Assert.True(new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3 }.SequenceEqual(projected));
        }

        [Fact]
        public void CanFlexProjectToEnumerableWithBetterSyntax()
        {
            // Act
            var projected = ints.FlexProject(item => {
                return item == 2 ?
                    ProjectAs<IEnumerable<int>>.Nothing:
                    new[] { item, item, item };
            });

            // Assert
            Assert.True(new int[] { 1, 1, 1, 3, 3, 3 }.SequenceEqual(projected));
        }
    }
}
