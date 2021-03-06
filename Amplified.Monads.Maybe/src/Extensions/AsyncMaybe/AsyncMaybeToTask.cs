using System.Threading.Tasks;
using static Amplified.Monads.Maybe;

namespace Amplified.Monads.Extensions
{
    public static class AsyncMaybeToTask
    {
        public static Task<Maybe<T>> ToTask<T>(this AsyncMaybe<T> source)
        {
            return source.Match(some: Some, none: none => Maybe<T>.None());
        }
    }
}
