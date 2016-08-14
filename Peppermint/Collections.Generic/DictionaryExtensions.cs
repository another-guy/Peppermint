namespace Peppermint.Collections.Generic
{
    using System.Collections.Generic;

    public static class DictionaryExtensions
    {
        public static IDictionary<TK, TV> NullToEmpty<TK, TV>(this IDictionary<TK, TV> target)
        {
            return target ?? new Dictionary<TK, TV>();
        }
    }
}
