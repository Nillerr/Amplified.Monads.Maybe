using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using static Amplified.Monads.Maybe;

namespace Amplified.Monads.Extensions
{
    public static class AsyncMaybeOr
    {
        public static Task<T> OrReturn<T>(this AsyncMaybe<T> source, T value)
        {
            return source.Match(
                some => some,
                none => value
            );
        }

        public static Task<T> OrGet<T>(this AsyncMaybe<T> source, [InstantHandle, NotNull] Func<T> value)
        {
            return source.Match(
                some => some,
                none => value()
            );
        }

        public static Task<T> OrDefault<T>(this AsyncMaybe<T> source)
        {
            return source.Match(
                some => some,
                none => default(T)
            );
        }

        public static Task<T> OrThrow<T>(this AsyncMaybe<T> source, [InstantHandle, NotNull] Func<Exception> exception)
        {
            return source.Match(
                some => some,
                none: _ => throw exception()
            );
        }

        public static AsyncMaybe<T> Or<T>(this AsyncMaybe<T> source, AsyncMaybe<T> other)
        {
            return source.Match(
                some: Some,
                noneAsync: none => other.ToTask()
            ).ToAsyncMaybe();
        }

        public static AsyncMaybe<T> Or<T>(this AsyncMaybe<T> source, [InstantHandle, NotNull] Func<AsyncMaybe<T>> other)
        {
            return source.Match(
                some: Some,
                noneAsync: none => other().ToTask()
            ).ToAsyncMaybe();
        }
    }
}