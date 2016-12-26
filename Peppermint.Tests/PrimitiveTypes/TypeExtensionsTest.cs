using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Peppermint.Tests.PrimitiveTypes
{
    public class TypeExtensionsTest
    {
        [Fact]
        public void GetAllBaseTypesWorks()
        {
            // Arrange
            var type = typeof(GrandChildClass);
            var expected = new[] {typeof(ChildClass), typeof(ParentClass), typeof(object)};
            // Act
            var allBaseTypes = type.GetAllBaseTypes();
            // Assert
            Assert.True(expected.SequenceEqual(allBaseTypes));
        }

        [Theory]
        [InlineData(typeof(ChildClass), typeof(object), true)]
        [InlineData(typeof(ChildClass), typeof(ParentClass), true)]
        [InlineData(typeof(GrandChildClass), typeof(ChildClass), true)]
        [InlineData(typeof(GrandChildClass), typeof(ParentClass), true)]
        [InlineData(typeof(ParentClass), typeof(ChildClass), false)]
        [InlineData(typeof(ChildClass), typeof(GrandChildClass), false)]
        [InlineData(typeof(ParentClass), typeof(GrandChildClass), false)]

        public void IsStrictlyChildClassOfWorks(Type childType, Type parentType, bool expectedResult)
        {
            // Arrange
            // Act
            var actualResult = childType.IsStrictlyChildClassOf(parentType);
            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }

    public interface ParentInterface { }
    public interface ChildInterface : ParentInterface { }
    public class ParentClass: ParentInterface { }
    public class ChildClass : ParentClass { }
    public class GrandChildClass : ChildClass { }
    public enum DemoEnum { }
    public struct DemoStruct { }
}
