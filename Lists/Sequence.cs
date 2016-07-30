using System;
using System.Collections.Generic;

namespace Peppermint.Lists
{
    public class Sequence
    {
        public static Func<int, int, int, int> Natural = (min, max, current) => current + 1;

        public static Func<int, int, int, int> NonNegative = (min, max, current) => current;

        public static Func<int, int, int, int> Ceil = (min, max, current) => current - max / 2;

        public static Func<int, int, int, int> ZeroPositiveNegative = (min, max, current) => current * (current % 2 == 1 ? 1 : -1);

        public static List<T> ListWithoutDuplicates<T>(
            int elementNumber,
            Func<int, int, int, T> sequenceItemGenerator)
        {
            var result = new List<T>();
            for (var count = 0; count < elementNumber; count++)
                result.Add(sequenceItemGenerator(0, elementNumber - 1, count));
            return result;
        }
    }
}
