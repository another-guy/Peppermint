﻿using System;

namespace Peppermint.Enums
{
    public static class StringToEnumExtension
    {
        public static TEnum Parse<TEnum>(this string @string)
            where TEnum : struct, IComparable, IConvertible, IFormattable
        {
            return (TEnum)Enum.Parse(typeof(TEnum), @string, true);
        }
    }
}
