using System;
using System.Diagnostics;
using Amplified.Monads.Maybe.Attributes;

namespace Amplified.Monads.Maybe
{
    public abstract class EnumsBase<TEnum>
    {
        [ExcludeFromCoverage]
        internal EnumsBase()
        {
        }

        [DebuggerStepThrough]
        public static Maybe<T> Parse<T>(string str)
            where T : struct, TEnum
            => Enum.TryParse(str, out T value)
                ? Maybe<T>.Some(value)
                : Maybe<T>.None();   
    }
    
    public sealed class Enums : EnumsBase<Enum>
    {
        [ExcludeFromCoverage]
        private Enums()
        {
        }
    }
}