using System;
using JetBrains.Annotations;

namespace Amplified.Monads.Maybe.Extensions
{
    public static class MaybeFlatMap
    {
        public static Maybe<TResult> FlatMap<T, TResult>(
            this Maybe<T> source,
            [InstantHandle, NotNull] Func<T, Maybe<TResult>> mapper
        )
        {
            return source.Match(mapper, none => Maybe<TResult>.None());
        }
    }
}