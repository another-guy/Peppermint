using System.Diagnostics.Contracts;

namespace System.Collections.Generic
{
    using System;
    using System.Linq;

    public static class IEnumerableExtensions
    {
        [Pure]
        public static IEnumerable<T> NullToEmpty<T>(this IEnumerable<T> target)
        {
            return target ?? new T[0];
        }

        [Pure]
        public static IEnumerable<TResult> TakeProject<T, TResult>(
            this IEnumerable<T> source,
            Predicate<T> takePredicate,
            Func<T, TResult> projectFunction)
        {
            foreach (T item in source)
                if (takePredicate(item))
                    yield return projectFunction(item);
        }

        [Pure]
        public static IEnumerable<TResult> SkipProject<T, TResult>(
            this IEnumerable<T> source,
            Predicate<T> skipPredicate,
            Func<T, TResult> projectFunction)
        {
            Predicate<T> takePredicate = element => skipPredicate(element) == false;
            return source.TakeProject(takePredicate, projectFunction);
        }

        [Pure]
        public static IEnumerable<TResult> TakeProjectMany<T, TResult>(
            this IEnumerable<T> source,
            Predicate<T> takePredicate,
            Func<T, IEnumerable<TResult>> projectFunction)
        {
            foreach (T item in source)
                if (takePredicate(item))
                    foreach (var projectedResult in projectFunction(item))
                        yield return projectedResult;
        }

        [Pure]
        public static IEnumerable<TResult> SkipProjectMany<T, TResult>(
            this IEnumerable<T> source,
            Predicate<T> skipPredicate,
            Func<T, IEnumerable<TResult>> projectFunction)
        {
            Predicate<T> takePredicate = element => skipPredicate(element) == false;
            return source.TakeProjectMany(takePredicate, projectFunction);
        }
        
        public static void ForEach<T>(
            this IEnumerable<T> source,
            Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }

        [Pure]
        public static bool None<T>(
            this IEnumerable<T> source,
            Predicate<T> predicate)
        {
            return source.All(item => predicate(item) == false);
        }
    }
}
