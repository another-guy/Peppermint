namespace Peppermint.Collections.Generic
{
    using System.Collections.Generic;

    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> NullToEmpty<T>(this IEnumerable<T> target)
        {
            return target ?? new T[0];
        }
    }
}
