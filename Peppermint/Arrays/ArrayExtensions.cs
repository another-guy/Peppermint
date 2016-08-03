﻿namespace Peppermint.Arrays
{
    public static class ArrayExtensions
    {
        public static T[] NullToEmpty<T>(this T[] target)
        {
            return target ?? new T[0];
        }
    }
}