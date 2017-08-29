using System;
using System.Collections.Concurrent;
using Amplified.Monads.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Amplified.Monads.Json
{
    public sealed class MaybeJsonConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var maybeValue = (Maybe<T>) value;
            maybeValue.Match(some => serializer.Serialize(writer, some), none => writer.WriteNull());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = serializer.Deserialize<JToken>(reader);
            if (token.Type == JTokenType.Null)
                return Maybe<T>.None();

            var value = token.ToObject<T>(serializer);
            return Maybe<T>.Some(value);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Maybe<T>);
        }
    }

    public sealed class MaybeJsonConverter : JsonConverter
    {
        private static readonly ConcurrentDictionary<Type, JsonConverter> Converters =
            new ConcurrentDictionary<Type, JsonConverter>();

        private static JsonConverter GetConverter(Type type)
        {
            return Converters.GetOrAdd(type, CreateConverter);
        }

        private static JsonConverter CreateConverter(Type type)
        {
            var valueType = type.GenericTypeArguments[0];
            var converterType = typeof(MaybeJsonConverter<>).MakeGenericType(valueType);
            var converter = (JsonConverter) Activator.CreateInstance(converterType);
            return converter;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var actualConverter = GetConverter(value.GetType());
            actualConverter.WriteJson(writer, value, serializer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var actualConverter = GetConverter(objectType);
            return actualConverter.ReadJson(reader, objectType, existingValue, serializer);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsConstructedGenericType && objectType.GetGenericTypeDefinition() == typeof(Maybe<>);
        }
    }
}