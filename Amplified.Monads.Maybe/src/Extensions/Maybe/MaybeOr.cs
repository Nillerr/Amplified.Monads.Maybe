using System;
using JetBrains.Annotations;
using static Amplified.Monads.Maybe;

namespace Amplified.Monads.Extensions
{
    public static class MaybeOr
    {
        public static T OrReturn<T>(this Maybe<T> source, T value)
        {
            return source.Match(
                some => some,
                none => value
            );
        }

        public static T OrGet<T>(this Maybe<T> source, [InstantHandle, NotNull] Func<T> value)
        {
            return source.Match(
                some => some,
                none => value()
            );
        }

        public static T OrDefault<T>(this Maybe<T> source)
        {
            return source.Match(
                some => some,
                none => default(T)
            );
        }

        public static T OrThrow<T>(this Maybe<T> source, [InstantHandle, NotNull] Func<Exception> exception)
        {
            return source.Match(
                some => some,
                none => throw exception()
            );
        }

        public static Maybe<T> Or<T>(this Maybe<T> source, Maybe<T> other)
        {
            return source.Match(Some, none => other);
        }

        public static Maybe<T> Or<T>(this Maybe<T> source, [InstantHandle, NotNull] Func<Maybe<T>> other)
        {
            return source.Match(Some, none => other());
        }
    }
}