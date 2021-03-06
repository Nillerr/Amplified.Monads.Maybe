using System;
using JetBrains.Annotations;

namespace Amplified.Monads.Extensions
{
    public static class AsyncMaybeLinq
    {
        public static AsyncMaybe<TResult> Select<T, TResult>(
            this AsyncMaybe<T> source,
            [NotNull] Func<T, TResult> mapper
        ) => source.Map(mapper);

        public static AsyncMaybe<T> Where<T>(
            this AsyncMaybe<T> source,
            [NotNull] Func<T, bool> predicate
        ) => source.Filter(predicate);
    }
}