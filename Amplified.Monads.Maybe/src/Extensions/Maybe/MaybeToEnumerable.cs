using System.Collections.Generic;
using System.Linq;

namespace Amplified.Monads.Maybe.Extensions
{
    public static class MaybeToEnumerable
    {
        public static IEnumerable<T> ToEnumerable<T>(this Maybe<T> source)
        {
            return source.Match(
                some => Enumerable.Repeat(some, 1),
                none => none.ToEnumerable<T>()
            );
        }
    }
}