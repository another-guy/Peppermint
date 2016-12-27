using System.Diagnostics.Contracts;

namespace System.Collections.Generic
{
    public static class ArrayExtensions
    {
        [Pure]
        public static T[] NullToEmpty<T>(this T[] target)
        {
            return target ?? new T[0];
        }
    }
}
