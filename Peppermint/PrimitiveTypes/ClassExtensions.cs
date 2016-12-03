namespace System
{
    public static class ClassExtensions
    {
        public static T NullToNew<T>(this T target)
            where T: class, new()
        {
            return target.NullTo(new T());
        }

        public static T NullTo<T>(this T target, T alternative)
            where T: class
        {
            return target ?? alternative;
        }
    }
}
