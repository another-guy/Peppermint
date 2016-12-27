using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;

namespace System
{
    public static class TypeExtensions
    {
        [Pure]
        public static IEnumerable<Type> GetAllBaseTypes(this Type type)
        {
            var currentType = type;
            while (true)
            {
                if ((currentType = currentType.GetTypeInfo().BaseType) == null)
                    yield break;
                yield return currentType;
            }
        }

        [Pure]
        public static bool IsParentTypeOf(this Type parentType, Type childType)
        {
            return childType.IsChildTypeOf(parentType);
        }

        [Pure]
        public static bool IsChildTypeOf(this Type childType, Type parentType)
        {
            return parentType.IsAssignableFrom(childType);
        }

        [Pure]
        public static bool IsParentOrPossiblyOpenGenericParentOf(this Type parentType, Type childType)
        {
            return childType.IsChildTypeOfPossiblyOpenGeneric(parentType);
        }

        [Pure]
        public static bool IsChildTypeOfPossiblyOpenGeneric(this Type childType, Type parentClassType)
        {
            if (childType.IsChildTypeOf(parentClassType))
                return true;

            var parentTypeInfo = parentClassType.GetTypeInfo();
            if (parentTypeInfo.IsGenericTypeDefinition)
            {
                var childArgs = childType.GetGenericArguments();
                var constraints = parentTypeInfo
                    .GetGenericArguments()
                    .Select(genericArgument => genericArgument.GetTypeInfo().GetGenericParameterConstraints())
                    .ToArray();

                return childArgs.Length == constraints.Length;
            }

            return false;
        }
    }
}
