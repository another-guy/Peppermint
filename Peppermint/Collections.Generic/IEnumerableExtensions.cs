namespace System.Collections.Generic
{
    using System;

    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> NullToEmpty<T>(this IEnumerable<T> target)
        {
            return target ?? new T[0];
        }

        public static IEnumerable<TResult> TakeProject<T, TResult>(
            this IEnumerable<T> source,
            Predicate<T> takePredicate,
            Func<T, TResult> projectFunction)
        {
            foreach (T item in source)
                if (takePredicate(item))
                    yield return projectFunction(item);
        }

        public static IEnumerable<TResult> SkipProject<T, TResult>(
            this IEnumerable<T> source,
            Predicate<T> skipPredicate,
            Func<T, TResult> projectFunction)
        {
            Predicate<T> takePredicate = element => skipPredicate(element) == false;
            return source.TakeProject(takePredicate, projectFunction);
        }

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

        public static IEnumerable<TResult> SkipProjectMany<T, TResult>(
            this IEnumerable<T> source,
            Predicate<T> skipPredicate,
            Func<T, IEnumerable<TResult>> projectFunction)
        {
            Predicate<T> takePredicate = element => skipPredicate(element) == false;
            return source.TakeProjectMany(takePredicate, projectFunction);
        }

        public static void ForAll<T>(
            this IEnumerable<T> source,
            Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }
    }
}
