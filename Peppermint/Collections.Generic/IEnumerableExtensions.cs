using System.Collections.Generic;

namespace Peppermint.Collections.Generic
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> NullToEmpty<T>(this IEnumerable<T> target)
        {
            return target ?? new T[0];
        }
    }
}
