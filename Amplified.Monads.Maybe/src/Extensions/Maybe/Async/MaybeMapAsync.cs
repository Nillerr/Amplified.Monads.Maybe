using System;
using System.Threading.Tasks;
using Amplified.Monads.Internal.Extensions;
using JetBrains.Annotations;

namespace Amplified.Monads.Extensions
{
    public static class MaybeMapAsync
    {
        public static AsyncMaybe<TResult> MapAsync<T, TResult>(
            this Maybe<T> source,
            [InstantHandle, NotNull] Func<T, Task<TResult>> mapper)
        {
            return source.Match(
                some => mapper(some).Then(Maybe<TResult>.Some),
                none => Task.FromResult(Maybe<TResult>.None())
            ).ToAsyncMaybe();
        }
    }
}