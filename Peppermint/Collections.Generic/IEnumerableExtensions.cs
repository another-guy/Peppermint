namespace Peppermint.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> NullToEmpty<T>(this IEnumerable<T> target)
        {
            return target ?? new T[0];
        }

        public static IEnumerable<TResult> FlexProject<T, TResult>(
            this IEnumerable<T> source,
            Func<T, ProjectAs<TResult>> smartSelector)
        {
            foreach (T item in source)
            {
                var selectorApplicationResult = smartSelector(item);
                if (selectorApplicationResult.DoProjectValue)
                    yield return selectorApplicationResult.Value;
            }
        }
        public static IEnumerable<TResult> FlexProject<T, TResult>(
            this IEnumerable<T> source,
            Func<T, ProjectAs<IEnumerable<TResult>>> smartSelector)
        {
            foreach (T item in source)
            {
                var selectorApplicationResult = smartSelector(item);
                if (selectorApplicationResult.DoProjectValue)
                    foreach (var projectedItemFromMany in selectorApplicationResult.Value)
                        yield return projectedItemFromMany;
            }
        }
    }
}
