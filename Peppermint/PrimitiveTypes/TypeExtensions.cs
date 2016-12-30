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

            var childTypeInfo = childType.GetTypeInfo();
            if (childTypeInfo.IsGenericType == false)
                return false;
            
            var parentTypeInfo = parentClassType.GetTypeInfo();
            if (parentTypeInfo.IsGenericTypeDefinition)
            {
                var childTypesGenericArgs = childType.GenericTypeArguments;
                if (childTypesGenericArgs.Length != parentTypeInfo.GenericTypeParameters.Length)
                    return false;

                Type parentGenericTypeClosedToChildArgument;
                try
                {
                    parentGenericTypeClosedToChildArgument =
                        parentClassType.MakeGenericType(childTypesGenericArgs);
                }
                catch (ArgumentException)
                {
                    // This happens when closing argument type violates the declared paramter's constraints.
                    // It is not easy to check whether the constraint is met or violated, this is why this code relies on exception.
                    // http://stackoverflow.com/a/4864565/482868
                    return false;
                }

                if (childType.IsChildTypeOf(parentGenericTypeClosedToChildArgument))
                    return true;
            }

            return false;
        }
    }
}
