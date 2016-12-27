using System.Diagnostics.Contracts;

namespace System
{
    public static class ClassExtensions
    {
        [Pure]
        public static T NullToNew<T>(this T target)
            where T : class, new()
        {
            return target.NullTo(new T());
        }

        [Pure]
        public static T NullTo<T>(this T target, T alternative)
            where T : class
        {
            return target ?? alternative;
        }

        [Pure]
        public static T1 NullToException<T1, T2>(this T1 target, T2 exception)
            where T1 : class
            where T2 : Exception
        {
            if (target == null)
                throw exception;
            return target;
        }
    }
}
