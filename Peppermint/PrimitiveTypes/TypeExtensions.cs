using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace System
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetAllBaseTypes(this Type type)
        {
            var currentType = type;
            while (true)
            {
                currentType = currentType.GetTypeInfo().BaseType;

                if (currentType == null)
                    yield break;

                yield return currentType;
            }
        }

        public static bool IsStrictlyChildClassOf(this Type childType, Type parentType)
        {
            return childType.GetAllBaseTypes().Any(baseType => baseType == parentType);
        }

        public static bool IsStrictlyParentClassOf(this Type parentType, Type childType)
        {
            return childType.IsStrictlyChildClassOf(parentType);
        }
    }
}
