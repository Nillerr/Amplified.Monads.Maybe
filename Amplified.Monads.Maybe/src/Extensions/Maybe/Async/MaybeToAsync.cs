using System.Threading.Tasks;

namespace Amplified.Monads.Extensions
{
    public static class MaybeToAsync
    {
        public static AsyncMaybe<T> ToAsync<T>(this Maybe<T> source)
        {
            return new AsyncMaybe<T>(Task.FromResult(source));
        }
    }
}