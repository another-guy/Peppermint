namespace Peppermint.Collections.Generic
{
    public static class ArrayExtensions
    {
        public static T[] NullToEmpty<T>(this T[] target)
        {
            return target ?? new T[0];
        }

        public static void SwapAt<T>(this T[] target, int index1, int index2)
        {   
            var temp = target[index1];
            target[index1] = target[index2];
            target[index2] = temp;
        }
    }
}
