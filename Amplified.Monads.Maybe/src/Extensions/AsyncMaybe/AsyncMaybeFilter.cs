using System;
using JetBrains.Annotations;

namespace Amplified.Monads.Extensions
{
    public static class AsyncMaybeFilter
    {
        public static AsyncMaybe<T> Filter<T>(
            this AsyncMaybe<T> source,
            [InstantHandle, NotNull] Func<T, bool> predicate)
        {
            return source.Match(
                some => predicate(some)
                    ? Maybe<T>.Some(some)
                    : Maybe<T>.None(),
                none => Maybe<T>.None()
            ).ToAsyncMaybe();
        }
    }
}