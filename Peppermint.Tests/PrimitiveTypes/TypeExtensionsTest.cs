using System;
using System.Collections;
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

        public void IsStrictlyChildOfClassWorks(Type childType, Type parentType, bool expectedResult)
        {
            // Arrange
            // Act
            var actualResult = childType.IsStrictlyChildOfClass(parentType);
            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(typeof(object), typeof(ChildClass), true)]
        [InlineData(typeof(ParentClass), typeof(ChildClass), true)]
        [InlineData(typeof(ChildClass), typeof(GrandChildClass), true)]
        [InlineData(typeof(ParentClass), typeof(GrandChildClass), true)]
        [InlineData(typeof(ChildClass), typeof(ParentClass), false)]
        [InlineData(typeof(GrandChildClass), typeof(ChildClass), false)]
        [InlineData(typeof(GrandChildClass), typeof(ParentClass), false)]

        public void IsStrictlyParentClassOfWorks(Type parentType, Type childType, bool expectedResult)
        {
            // Arrange
            // Act
            var actualResult = parentType.IsStrictlyParentClassOf(childType);
            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(typeof(IList<int>), typeof(IList), false)]
        [InlineData(typeof(IList<int>), typeof(ICollection<int>), true)]
        [InlineData(typeof(IList<int>), typeof(IEnumerable<int>), true)]
        [InlineData(typeof(IList<int>), typeof(IEnumerable), true)]
        [InlineData(typeof(IList), typeof(ICollection), true)]
        [InlineData(typeof(IList), typeof(IEnumerable), true)]
        [InlineData(typeof(IList), typeof(IList<int>), false)]
        public void IsStrictlyChildOfInterfaceWorks(Type childType, Type parentInterfaceType, bool expectedResult)
        {
            // Arrange
            // Act
            var actualResult = childType.IsStrictlyChildOfInterface(parentInterfaceType);
            // Assert
            Assert.Equal(expectedResult, actualResult);
        }


        [Theory]
        [InlineData(typeof(IList), typeof(IList<int>), false)]
        [InlineData(typeof(ICollection<int>), typeof(IList<int>), true)]
        [InlineData(typeof(IEnumerable<int>), typeof(IList<int>), true)]
        [InlineData(typeof(IEnumerable), typeof(IList<int>), true)]
        [InlineData(typeof(ICollection), typeof(IList), true)]
        [InlineData(typeof(IEnumerable), typeof(IList), true)]
        [InlineData(typeof(IList<int>), typeof(IList), false)]
        public void IsStrictlyParentInterfaceOfWorks(Type parentInterfaceType, Type childType, bool expectedResult)
        {
            // Arrange
            // Act
            var actualResult = parentInterfaceType.IsStrictlyParentInterfaceOf(childType);
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

