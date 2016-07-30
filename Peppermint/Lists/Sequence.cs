using System;
using System.Collections.Generic;

namespace Peppermint.Lists
{
    public class Sequence
    {
        public static Func<int, int, int> NaturalNumbers = (@base, current) => current + 1;

        public static Func<int, int, int> NonNegativeNumbers = (@base, current) => current;

        public static Func<int, int, int> CeilNumbers = (@base, current) => @base + current;

        public static IEnumerable<T> WithoutDuplicates<T>(
            Func<int, int, T> sequenceItemGenerator,
            int? baseOverride = null,
            int? stepOverride = null)
        {
            if (sequenceItemGenerator == null) throw new ArgumentNullException(nameof(sequenceItemGenerator));

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
