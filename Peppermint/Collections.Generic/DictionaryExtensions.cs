using System.Diagnostics.Contracts;

namespace System.Collections.Generic
{
    public static class DictionaryExtensions
    {
        [Pure]
        public static IDictionary<TK, TV> NullToEmpty<TK, TV>(this IDictionary<TK, TV> target)
        {
            return target ?? new Dictionary<TK, TV>();
        }
    }
}
