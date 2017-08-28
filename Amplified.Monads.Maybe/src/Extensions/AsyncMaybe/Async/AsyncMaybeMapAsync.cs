using System;
using System.Threading.Tasks;
using Amplified.Monads.Internal.Extensions;
using JetBrains.Annotations;
using static Amplified.Monads.Maybe;

namespace Amplified.Monads.Extensions
{
    public static class AsyncMaybeMapAsync
    {
        public static AsyncMaybe<TResult> MapAsync<T, TResult>(
            this AsyncMaybe<T> source,
            [NotNull] Func<T, Task<TResult>> mapperAsync)
        {
            return source.Match(some => mapperAsync(some).Then(Some), none => Maybe<TResult>.None()).ToAsyncMaybe();
        }
    }
}