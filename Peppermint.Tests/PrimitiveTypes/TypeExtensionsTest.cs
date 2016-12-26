using System;
using System.Linq;
using Xunit;

namespace Peppermint.Tests.PrimitiveTypes
{
    public class TypeExtensionsTest
    {
        public void GetAllBaseTypesWorks()
        {
            // Arrange
            var type = typeof(GrandChildClass);
            var expected = new[] {typeof(ChildClass), typeof(ParentClass)};
            // Act
            var allBaseTypes = type.GetAllBaseTypes();
            // Assert
            Assert.True(expected.SequenceEqual(allBaseTypes));
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
