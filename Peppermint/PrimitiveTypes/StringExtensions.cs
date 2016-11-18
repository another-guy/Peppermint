namespace Peppermint.PrimitiveTypes
{
    using System.Collections.Generic;

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
    }
}
