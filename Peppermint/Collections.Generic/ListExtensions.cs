using System.Diagnostics.Contracts;

namespace System.Collections.Generic
{
    using System;
    using System.Linq;

    public static class ListExtensions
    {
        public static void Shuffle<T>(this IList<T> collection, int swapsNumber = -1, int seed = 1)
        {
            var random = new Random(seed);
            var elementNumber = collection.Count;

            if (swapsNumber == -1) swapsNumber = elementNumber * 3;

            for (var swaps = 1; swaps <= swapsNumber; swaps++)
                SwapAt(collection, random.Next(elementNumber), random.Next(elementNumber));
        }

        public static void SwapAt<T>(this IList<T> collection, int index1, int index2)
        {
            var temp = collection[index1];
            collection[index1] = collection[index2];
            collection[index2] = temp;
        }

        [Pure]
        public static string AsString<T>(this IList<T> collection)
        {
            var items = collection
                .Skip(1)
                .Aggregate("", (accumulate, item) => accumulate + ", " + item);
            items = collection.First() + items;

            return "[" + items + "]";
        }
    }
}
