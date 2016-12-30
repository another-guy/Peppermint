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
        public void GetAllBaseTypes()
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
        [InlineData(typeof(GenericChildClass<ChildInterface>), typeof(GenericParentClass<ChildInterface>), true)]

        [InlineData(typeof(IList<int>), typeof(IList), false)]
        [InlineData(typeof(IList<int>), typeof(ICollection<int>), true)]
        [InlineData(typeof(IList<int>), typeof(IEnumerable<int>), true)]
        [InlineData(typeof(IList<int>), typeof(IEnumerable), true)]
        [InlineData(typeof(IList), typeof(ICollection), true)]
        [InlineData(typeof(IList), typeof(IEnumerable), true)]
        [InlineData(typeof(IList), typeof(IList<int>), false)]
        [InlineData(typeof(GenericChildClass<ParentInterface>), typeof(GenericInterfaceWithTasOut<ParentInterface>), true)]
        [InlineData(typeof(GenericChildClass<ChildInterface>), typeof(GenericInterfaceWithTasOut<ParentInterface>), true)]
        public void IsChildTypeOf(Type childType, Type parentType, bool expectedResult)
        {
            // Arrange
            // Act
            var actualResult = childType.IsChildTypeOf(parentType);
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
        [InlineData(typeof(GenericParentClass<ChildInterface>), typeof(GenericChildClass<ChildInterface>), true)]

        [InlineData(typeof(IList), typeof(IList<int>), false)]
        [InlineData(typeof(ICollection<int>), typeof(IList<int>), true)]
        [InlineData(typeof(IEnumerable<int>), typeof(IList<int>), true)]
        [InlineData(typeof(IEnumerable), typeof(IList<int>), true)]
        [InlineData(typeof(ICollection), typeof(IList), true)]
        [InlineData(typeof(IEnumerable), typeof(IList), true)]
        [InlineData(typeof(IList<int>), typeof(IList), false)]
        public void IsParentTypeOf(Type parentType, Type childType, bool expectedResult)
        {
            // Arrange
            // Act
            var actualResult = parentType.IsParentTypeOf(childType);
            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        // Same as for IsCompatibleChildOfClass
        [InlineData(typeof(ChildClass), typeof(object), true)]
        [InlineData(typeof(ChildClass), typeof(ParentClass), true)]
        [InlineData(typeof(GrandChildClass), typeof(ChildClass), true)]
        [InlineData(typeof(GrandChildClass), typeof(ParentClass), true)]
        [InlineData(typeof(ParentClass), typeof(ChildClass), false)]
        [InlineData(typeof(ChildClass), typeof(GrandChildClass), false)]
        [InlineData(typeof(ParentClass), typeof(GrandChildClass), false)]
        [InlineData(typeof(GenericChildClass<ChildInterface>), typeof(GenericParentClass<ChildInterface>), true)]

        [InlineData(typeof(IList<int>), typeof(IList), false)]
        [InlineData(typeof(IList<int>), typeof(ICollection<int>), true)]
        [InlineData(typeof(IList<int>), typeof(IEnumerable<int>), true)]
        [InlineData(typeof(IList<int>), typeof(IEnumerable), true)]
        [InlineData(typeof(IList), typeof(ICollection), true)]
        [InlineData(typeof(IList), typeof(IEnumerable), true)]
        [InlineData(typeof(IList), typeof(IList<int>), false)]
        [InlineData(typeof(GenericChildClass<ParentInterface>), typeof(GenericInterfaceWithTasOut<ParentInterface>), true)]
        [InlineData(typeof(GenericChildClass<ChildInterface>), typeof(GenericInterfaceWithTasOut<ParentInterface>), true)]
        // Softer rules
        [InlineData(typeof(GenericChildClass<>), typeof(GenericChildClass<>), true)]
        [InlineData(typeof(GenericInterfaceWithTasOut<>), typeof(GenericInterfaceWithTasOut<>), true)]

        [InlineData(typeof(GenericInterfaceWithTasOut<ChildInterface>), typeof(GenericInterfaceWithTasOut<>), true)]
        [InlineData(typeof(GenericInterfaceWithTasOut<>), typeof(GenericInterfaceWithTasOut<ChildInterface>), false)]

        [InlineData(typeof(GenericChildClass<ChildInterface>), typeof(GenericParentClass<>), true)]
        [InlineData(typeof(GenericParentClass<>), typeof(GenericChildClass<ChildInterface>), false)]

        [InlineData(typeof(GenericChildClass<ChildInterface>), typeof(GenericInterfaceWithTasOut<>), true)]
        [InlineData(typeof(GenericInterfaceWithTasOut<>), typeof(GenericChildClass<ChildInterface>), false)]

        [InlineData(typeof(GenericChildClass<string>), typeof(GenericChildClass<string>), true)]
        [InlineData(typeof(GenericChildClass<string>), typeof(GenericChildClass<>), true)]
        [InlineData(typeof(GenericChildClass<>), typeof(GenericChildClass<string>), false)]

        [InlineData(typeof(IDictionary<,>), typeof(IDictionary<,>), true)]
        [InlineData(typeof(IDictionary<string,int>), typeof(IDictionary<,>), true)]
        [InlineData(typeof(IDictionary<,>), typeof(IDictionary<string, int>), false)]

        [InlineData(typeof(IDictionary<int,string>), typeof(IDictionary<string, int>), false)]
        [InlineData(typeof(IDictionary<string, int>), typeof(IDictionary), false)]

        [InlineData(typeof(Tuple<>), typeof(Tuple<,>), false)]
        [InlineData(typeof(Tuple<,>), typeof(Tuple<,,>), false)]
        [InlineData(typeof(Tuple<,>), typeof(Tuple<>), false)]
        [InlineData(typeof(Tuple<,,>), typeof(Tuple<,>), false)]
        [InlineData(typeof(Tuple<string, int, object>), typeof(Tuple<,>), false)]
        [InlineData(typeof(Tuple<string, int, object>), typeof(Tuple<,,>), true)]
        [InlineData(typeof(Tuple<,,>), typeof(Tuple<string, int, object>), false)]
        [InlineData(typeof(Tuple<object, object, object>), typeof(Tuple<string, int, object>), false)]

        [InlineData(typeof(List<int>), typeof(Nullable<>), false)]
        [InlineData(typeof(Nullable<>), typeof(List<int>), false)]
        public void IsChildTypeOfPossiblyOpenGeneric(Type childType, Type parentType, bool expectedResult)
        {
            // Arrange
            // Act
            var actualResult = childType.IsChildTypeOfPossiblyOpenGeneric(parentType);
            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }

    public interface GenericInterfaceWithTasOut<out T> { }
    public class GenericParentClass<T> : GenericInterfaceWithTasOut<T> { }
    public class GenericChildClass<T> : GenericParentClass<T> { }

    public interface ParentInterface { }
    public interface ChildInterface : ParentInterface { }

    public class ParentClass: ParentInterface { }
    public class ChildClass : ParentClass { }
    public class GrandChildClass : ChildClass { }
}
