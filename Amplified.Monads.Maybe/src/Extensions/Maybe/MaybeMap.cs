using System;
using JetBrains.Annotations;

namespace Amplified.Monads.Maybe.Extensions
{
    public static class MaybeMap
    {
        public static Maybe<TResult> Map<T, TResult>(
            this Maybe<T> source,
            [InstantHandle, NotNull] Func<T, TResult> mapper)
        {
            return source.Match(
                some => Maybe<TResult>.Some(mapper(some)),
                none => Maybe<TResult>.None()
            );
        }
    }
}