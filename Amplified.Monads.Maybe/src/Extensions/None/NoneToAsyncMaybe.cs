using System;
using System.Threading.Tasks;
using Amplified.Monads.Maybe.Internal.Extensions;
using static Amplified.Monads.Maybe.Maybe;

namespace Amplified.Monads.Maybe.Extensions
{
    public static class NoneToAsyncMaybe
    {
        public static AsyncMaybe<T> ToAsyncMaybe<T>(this None none)
        {
            return AsyncMaybe<T>.None();
        }
        
        public static AsyncMaybe<TResult> ToSomeAsync<TResult>(this None none, Task<TResult> some)
        {
            return new AsyncMaybe<TResult>(some.Then(Some));
        }

        public static AsyncMaybe<TResult> ToSomeAsync<TResult>(this None none, Func<Task<TResult>> some)
        {
            return new AsyncMaybe<TResult>(some().Then(Some));
        }
    }
}