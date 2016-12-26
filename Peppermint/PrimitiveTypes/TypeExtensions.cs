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

        // TODO Rename these methods !!!
        public static bool IsStrictlyChildOfClass(this Type childClassType, Type parentClassType)
        {
            return childClassType.GetAllBaseTypes().Any(baseType => baseType == parentClassType);
        }

        public static bool IsStrictlyParentOfClass(this Type parentClassType, Type childClassType)
        {
            return childClassType.IsStrictlyChildOfClass(parentClassType);
        }

        public static bool IsStrictlyChildOfInterface(this Type childType, Type parentInterfaceType)
        {
            return childType.GetInterfaces().Any(baseInterface => baseInterface == parentInterfaceType);
        }
    }
}
