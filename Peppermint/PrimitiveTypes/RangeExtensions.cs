namespace Peppermint.PrimitiveTypes
{
    using System;
    using System.Collections.Generic;

    public static class RangeExtensions
    {
        public static void Do(this Range target, Action action)
        {
            // TODO Test me
            for (var current = target.from;
                target.step > 0 ? current <= target.to : current >= target.to;
                current += target.step)
                action();
        }

        public static IEnumerable<T> ToSequence<T>(this Range target, Func<int, T> gen)
        {
            // TODO Test me
            for (var current = target.from;
                target.step > 0 ? current <= target.to : current >= target.to;
                current += target.step)
                yield return gen(current);
        }
    }
}
