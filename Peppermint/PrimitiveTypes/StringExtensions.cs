namespace System
{
    using Collections.Generic;

    public static class StringExtensions
    {
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

        public static string NullToEmpty(this string target)
        {
            return target.NullTo(string.Empty);
        }

        public static string NullTo(this string target, string replacingValue)
        {
            return target ?? replacingValue;
        }

        public static string NullOrEmptyTo(this string target, string replacingValue)
        {
            return string.IsNullOrEmpty(target) ? target : replacingValue;
        }

        public static string NullOrWhiteSpaceTo(this string target, string replacingValue)
        {
            return string.IsNullOrWhiteSpace(target) ? target : replacingValue;
        }

        public static string WithSuffix(this string target, string suffix)
        {
            var suffixToApply = suffix.NullToException(new ArgumentNullException(nameof(suffix)));
            return $"{target}{suffixToApply}";
        }

        public static string WithPrefix(this string target, string prefix)
        {
            var prefixToApply = prefix.NullToException(new ArgumentNullException(nameof(prefix)));
            return $"{prefixToApply}{target}";
        }
    }
}
