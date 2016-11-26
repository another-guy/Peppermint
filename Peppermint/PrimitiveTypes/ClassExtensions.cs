namespace System
{
    public static class ClassExtensions
    {
        public static T NullToEmpty<T>(this T target)
            where T: class, new()
        {
            return target ?? new T();
        }
    }
}
