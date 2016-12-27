using System.Diagnostics.Contracts;

namespace System
{
    public static class StringToEnumExtension
    {
        [Pure]
        public static TEnum Parse<TEnum>(this string @string)
            where TEnum : struct, IComparable, IConvertible, IFormattable
        {
            return (TEnum)Enum.Parse(typeof(TEnum), @string, true);
        }
    }
}
