using Newtonsoft.Json;
using Xunit;

namespace Amplified.Monads.Json
{
    public class JsonConverterTests
    {
        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            Converters = { new MaybeJsonConverter() }
        };
        
        [Fact]
        public void SerializesSomeInt()
        {
            var source = new { Value = Maybe.Some(123) };
            var result = JsonConvert.SerializeObject(source, _settings);
            Assert.Equal("{\"Value\":123}", result);
        }
        
        [Fact]
        public void SerializeSomeString()
        {
            var source = new { Value = Maybe.Some("Hello") };
            var result = JsonConvert.SerializeObject(source, _settings);
            Assert.Equal("{\"Value\":\"Hello\"}", result);
        }
        
        [Fact]
        public void SerializeSomeObject()
        {
            var source = new { Value = Maybe.Some(new { Foo = "bar" }) };
            var result = JsonConvert.SerializeObject(source, _settings);
            Assert.Equal("{\"Value\":{\"Foo\":\"bar\"}}", result);
        }

        [Fact]
        public void SerializeNone()
        {
            var source = new { Value = Maybe<int>.None() };
            var result = JsonConvert.SerializeObject(source, _settings);
            Assert.Equal("{\"Value\":null}", result);
        }

        [Fact]
        public void DeserializeSomeInt()
        {
            var source = "{\"Value\":834534}";
            var result = JsonConvert.DeserializeObject<ValueContainer<Maybe<int>>>(source, _settings);
            Assert.Equal(result.Value, Maybe.Some(834534));
        }

        [Fact]
        public void DeserializeSomeString()
        {
            var source = "{\"Value\":\"World\"}";
            var result = JsonConvert.DeserializeObject<ValueContainer<Maybe<string>>>(source, _settings);
            Assert.Equal(result.Value, Maybe.Some("World"));
        }

        [Fact]
        public void DeserializeSomeObject()
        {
            var source = "{\"Value\":{\"Value\":\"Mr. Worldwide\"}}";
            var result = JsonConvert.DeserializeObject<ValueContainer<ValueContainer<Maybe<string>>>>(source, _settings);
            Assert.Equal(result.Value.Value, Maybe.Some("Mr. Worldwide"));
        }

        [Fact]
        public void DeserializeNoneToPrimitive()
        {
            var source = "{\"Value\":null}";
            var result = JsonConvert.DeserializeObject<ValueContainer<Maybe<int>>>(source, _settings);
            Assert.Equal(result.Value, Maybe<int>.None());
        }

        [Fact]
        public void DeserializeNoneToObject()
        {
            var source = "{\"Value\":null}";
            var result = JsonConvert.DeserializeObject<ValueContainer<Maybe<object>>>(source, _settings);
            Assert.Equal(result.Value, Maybe<object>.None());
        }

        private sealed class ValueContainer<T>
        {
            public T Value { get; set; }
        }
    }
}