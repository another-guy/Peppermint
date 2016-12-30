using System;
using Xunit;

namespace Peppermint.Tests.PrimitiveTypes
{
    public class ClassExtensionsTest
    {
        [Fact]
        public void NullToNewCreatesNewObjectFromOriginalNull()
        {
            // Arrange
            object sut = null;

            // Act
            sut = sut.NullToNew();

            // Assert
            Assert.NotNull(sut);
        }

        [Fact]
        public void NullToNewReturnsOriginalObjectFromNonNull()
        {
            // Arrange
            var sut = new object();
            var hashCode = sut.GetHashCode();

            // Act
            sut = sut.NullToNew();

            // Assert
            Assert.NotNull(sut);
            Assert.Equal(hashCode, sut.GetHashCode());
        }

        [Fact]
        public void NullToExceptionThrowsOnNullObject()
        {
            object target = null;
            var name = nameof(target);

            var caught = Assert.Throws<ArgumentNullException>(() =>
                target.NullToException(new ArgumentNullException(name)));

            Assert.Equal(name, caught.ParamName);
        }

        [Fact]
        public void NullToExceptionReturnsSelfWhenObjectIsNotNull()
        {
            var target = new object();
            var name = nameof(target);

            var result = target.NullToException(new ArgumentNullException(name));

            Assert.Same(target, result);
        }

        [Fact]
        public void UseAsArgForCanInvokeAction()
        {
            // Arrange
            const string target = "some string";
            object trackedObject = null;
            Action<string> action = argument => trackedObject = argument;

            // Act
            target.UseAsArgFor(action);

            // Assert
            Assert.Equal(target, trackedObject);
        }

        [Fact]
        public void UseAsArgThrowsOnNullAction()
        {
            // Arrange
            const string target = "some string";
            Action<string> action = null;

            // Act, Assert
            Assert.Throws<NullReferenceException>(() => target.UseAsArgFor(action));
        }

        [Fact]
        public void UseAsArgForCanInvokeFunction()
        {
            // Arrange
            const string target = "some string";
            const string expectedResult = "SOME STRING";
            Func<string, string> action = argument => argument.ToUpperInvariant();

            // Act
            var actualResult = target.UseAsArgFor(action);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void UseAsArgThrowsOnNullFunction()
        {
            // Arrange
            const string target = "some string";
            Func<string, string> action = null;

            // Act, Assert
            Assert.Throws<NullReferenceException>(() => target.UseAsArgFor(action));
        }
    }
}
