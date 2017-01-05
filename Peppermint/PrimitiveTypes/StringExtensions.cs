using System.Diagnostics.Contracts;

namespace System
{
    using Collections.Generic;

    public static class StringExtensions
    {
        [Pure]
        public static string Reverse(this string target)
        {
            if (target == null) return null;
            if (target == "") return "";

            var chars = target.ToCharArray();

            var left = 0;
            var right = chars.Length - 1;
            while (left < right)
            {
                chars.SwapAt(left, right);

                left += 1;
                right -= 1;
            }
            return new string(chars);
        }

        [Pure]
        public static string NullToEmpty(this string target)
        {
            return target.NullTo(string.Empty);
        }

        [Pure]
        public static string NullTo(this string target, string replacingValue)
        {
            return target ?? replacingValue;
        }

        [Pure]
        public static string NullOrEmptyTo(this string target, string replacingValue)
        {
            return string.IsNullOrEmpty(target) ? target : replacingValue;
        }

        [Pure]
        public static string NullOrWhiteSpaceTo(this string target, string replacingValue)
        {
            return string.IsNullOrWhiteSpace(target) ? target : replacingValue;
        }

        [Pure]
        public static string WithSuffix(this string target, string suffix)
        {
            var suffixToApply = suffix.NullToException(new ArgumentNullException(nameof(suffix)));
            return $"{target}{suffixToApply}";
        }

        [Pure]
        public static string WithPrefix(this string target, string prefix)
        {
            var prefixToApply = prefix.NullToException(new ArgumentNullException(nameof(prefix)));
            return $"{prefixToApply}{target}";
        }

        [Pure]
        public static string TrimFirst(this string target, int count)
        {
            var possibleOutOfBoundaryStartIndex = count;
            var startIndex = Math.Min(target.Length, possibleOutOfBoundaryStartIndex);
            return target.Substring(startIndex);
        }

        [Pure]
        public static string TrimLast(this string target, int count)
        {
            var possibleNegativeLength = target.Length - count;
            var length = Math.Max(0, possibleNegativeLength);
            return target.Substring(0, length);
        }

        [Pure]
        public static bool IsNullOrEmpty(this string target)
        {
            return string.IsNullOrEmpty(target);
        }

        [Pure]
        public static bool IsNullOrWhiteSpace(this string target)
        {
            return string.IsNullOrWhiteSpace(target);
        }
    }
}
