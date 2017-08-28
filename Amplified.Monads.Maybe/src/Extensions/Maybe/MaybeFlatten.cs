namespace Amplified.Monads.Maybe.Extensions
{
    public static class MaybeFlatten
    {
        public static Maybe<T> Flatten<T>(this Maybe<Maybe<T>> source)
        {
            return source.Match(
                some => some,
                none => none
            );
        }
    }
}
