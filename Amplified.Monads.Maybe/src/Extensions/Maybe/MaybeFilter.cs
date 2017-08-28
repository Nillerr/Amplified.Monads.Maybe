using System;
using JetBrains.Annotations;
using static Amplified.Monads.Maybe;

namespace Amplified.Monads.Extensions
{
    public static class MaybeFilter
    {
        public static Maybe<T> Filter<T>(this Maybe<T> source, [InstantHandle, NotNull] Func<T, bool> predicate)
        {
            return source.Match(
                some => predicate(some) ? Some(some) : Maybe<T>.None(),
                none => Maybe<T>.None()
            );
        }
    }
}