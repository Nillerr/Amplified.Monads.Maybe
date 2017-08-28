namespace Amplified.Monads.Maybe.Extensions
{
    public static class MaybeToNone
    {
        public static None ToNone<T>(this Maybe<T> source)
        {
            return default(None);
        }
    }
}