using System;
using System.Threading.Tasks;
using Amplified.Monads.Internal.Extensions;
using JetBrains.Annotations;

namespace Amplified.Monads.Extensions
{
    public static class AsyncMaybeFilterAsync
    {
        public static AsyncMaybe<T> FilterAsync<T>(
            this AsyncMaybe<T> source,
            [InstantHandle, NotNull] Func<T, Task<bool>> predicate)
        {
            return source.Match(
                some => predicate(some).Then(
                    it => it
                        ? Maybe<T>.Some(some)
                        : Maybe<T>.None()
                ),
                none => Maybe<T>.None()
            ).ToAsyncMaybe();
        }
    }
}