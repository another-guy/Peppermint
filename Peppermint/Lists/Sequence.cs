using System;
using System.Collections.Generic;

namespace Peppermint.Lists
{
    public class Sequence
    {
        public static Func<int, int, int> Natural = (@base, current) => current + 1;

        public static Func<int, int, int> NonNegative = (@base, current) => current;

        public static Func<int, int, int> Ceil = (@base, current) => @base + current;

        public static Func<int, int, int> ZeroPositiveNegative = (@base, current) => @base + current * (current % 2 == 1 ? 1 : -1);

        public static IEnumerable<T> ListWithoutDuplicates<T>(
            Func<int, int, T> sequenceItemGenerator,
            int? baseOverride = null,
            int? stepOverride = null)
        {
            var @base = baseOverride ?? 0;
            var step = stepOverride ?? 1;

            var current = 0;
            while (true)
            {
                var item = sequenceItemGenerator(@base, current);
                current += step;
                yield return item;
            }
        }
    }
}
