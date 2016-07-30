using System.Collections.Generic;

namespace Peppermint.Dictionaries
{
    public static class DictionaryExtensions
    {
        public static IDictionary<TK, TV> NullToEmpty<TK, TV>(this IDictionary<TK, TV> target)
        {
            return target ?? new Dictionary<TK, TV>();
        }
    }
}
