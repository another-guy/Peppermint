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
        
        public static bool IsStrictlyChildOfClass(this Type childClassType, Type parentClassType)
        {
            return childClassType.GetAllBaseTypes().Any(baseType => baseType == parentClassType);
        }

        public static bool IsStrictlyParentClassOf(this Type parentClassType, Type childClassType)
        {
            return childClassType.IsStrictlyChildOfClass(parentClassType);
        }

        public static bool IsStrictlyChildOfInterface(this Type childType, Type parentInterfaceType)
        {
            return childType.GetInterfaces().Any(baseInterface => baseInterface == parentInterfaceType);
        }

        public static bool IsStrictlyParentInterfaceOf(this Type parentInterfaceType, Type childType)
        {
            return childType.IsStrictlyChildOfInterface(parentInterfaceType);
        }
    }
}
