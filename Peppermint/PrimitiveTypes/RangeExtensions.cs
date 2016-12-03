namespace System
{
    using Collections.Generic;

    public static class RangeExtensions
    {
        public static void Do(this Range target, Action action)
        {
            target.ForEach(_ => action());
        }
    }
}
