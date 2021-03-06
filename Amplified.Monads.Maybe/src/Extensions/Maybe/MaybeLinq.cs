﻿using System;
using JetBrains.Annotations;
using static Amplified.Monads.Maybe;

namespace Amplified.Monads.Extensions
{
    public static class MaybeLinq
    {
        public static Maybe<TResult> Select<T, TResult>(
            this Maybe<T> source,
            [InstantHandle, NotNull] Func<T, TResult> mapper
        )
        {
            return source.Match(some => Some(mapper(some)), none => Maybe<TResult>.None());
        }

        public static Maybe<T> Where<T>(this Maybe<T> source, [InstantHandle, NotNull] Func<T, bool> predicate)
        {
            return source.Match(
                some => predicate(some) ? Some(some) : Maybe<T>.None(),
                none => Maybe<T>.None()
            );
        }
    }
}