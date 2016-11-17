namespace Peppermint.Collections.Generic
{
    public sealed class ProjectAs<TResult>
    {
        public static ProjectAs<TResult> Nothing =
            new ProjectAs<TResult>(false, default(TResult));

        public static implicit operator ProjectAs<TResult>(TResult result)
        {
            return new ProjectAs<TResult>(true, result);
        }

        public ProjectAs(bool doProjectValue, TResult value)
        {
            DoProjectValue = doProjectValue;
            Value = value;
        }

        public bool DoProjectValue { get; }
        public TResult Value { get; }
    }
}
