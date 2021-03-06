﻿namespace Amplified.Monads.Extensions
{
    public static class NullableToMaybe
    {
        public static Maybe<TSource> ToMaybe<TSource>(this TSource? source) where TSource : struct
        {
            return Maybe.OfNullable(source);
        }
    }
}