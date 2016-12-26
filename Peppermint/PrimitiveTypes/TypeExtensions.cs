using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace System
{
    public static class TypeExtensions
    {
        // TODO Test this
        public static IEnumerable<Type> GetAllBaseTypes(this Type type)
        {
            var currentType = type;
            while (true)
            {
                currentType = currentType.GetTypeInfo().BaseType;

                if (currentType == typeof(object))
                    yield break;

                yield return currentType;
            }
        }
    }
}
