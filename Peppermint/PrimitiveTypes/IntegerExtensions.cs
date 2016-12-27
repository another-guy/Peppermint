using System.Diagnostics.Contracts;

namespace System
{
    using Collections.Generic;

    public static class IntegerExtensions
    {
        [Pure]
        public static IEnumerable<T> Times<T>(this int number, Func<T> func)
        {
            for (var count = 1; count <= number; count++)
                yield return func();
        }

        public static void Times(this int number, Action action)
        {
            for (var count = 1; count <= number; count++)
                action();
        }

        [Pure]
        public static Range To(this int from, int to, int step = 0)
        {
            return new Range(from, to, step);
        }
    }
}
