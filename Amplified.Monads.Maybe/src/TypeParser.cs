using System;
using System.Globalization;

namespace Amplified.Monads
{
    public delegate bool TypeParser<T>(string str, out T value);
    public delegate bool NumberTypeParser<T>(string str, NumberStyles style, IFormatProvider provider, out T value);
}