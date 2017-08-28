using System.Collections.Generic;
using System.Linq;

namespace Amplified.Monads.Extensions
{
    public static class NoneToEnumerableExtensions
    {
        public static IEnumerable<T> ToEnumerable<T>(this None source)
        {
            return Enumerable.Empty<T>();
        }
    }
}