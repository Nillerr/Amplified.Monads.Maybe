using System.Threading.Tasks;
using Amplified.Monads.Maybe.Internal.Extensions;
using static Amplified.Monads.Maybe.Maybe;

namespace Amplified.Monads.Maybe.Extensions
{
    public static class TaskToAsyncMaybe
    {
        public static AsyncMaybe<T> ToAsyncMaybe<T>(this Task<Maybe<T>> source)
        {
            return new AsyncMaybe<T>(source);
        }

        public static AsyncMaybe<T> ToAsyncMaybe<T>(this Task<AsyncMaybe<T>> source)
        {
            return source.Then(it => it.Match(some: Some, none: none => none)).ToAsyncMaybe();
        }
    }
}
