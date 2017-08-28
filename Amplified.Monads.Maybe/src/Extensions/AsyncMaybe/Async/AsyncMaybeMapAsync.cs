using System;
using System.Threading.Tasks;
using Amplified.Monads.Maybe.Internal.Extensions;
using JetBrains.Annotations;
using static Amplified.Monads.Maybe.Maybe;

namespace Amplified.Monads.Maybe.Extensions
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