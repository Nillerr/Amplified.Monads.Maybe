using System.Threading.Tasks;
using Amplified.Monads.Maybe.Extensions;
using Amplified.Monads.Maybe.Util;
using Xunit;
using static Amplified.Monads.Maybe.Maybe;

namespace Amplified.Monads.Maybe
{
    // ReSharper disable once InconsistentNaming
    public class AsyncMaybe_OrThrow
    {
        [Fact]
        public async Task Sync_OnSome_WithFunction_ReturnsResultOfSome()
        {
            const int expected = 123132;
            var source = Some(expected).ToAsync();
            var result = await source.OrThrow(() => new ExpectedException());
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public async Task Sync_OnNone_WithFunction_ThrowsException()
        {
            var source = AsyncMaybe<int>.None();
            await Assert.ThrowsAsync<ExpectedException>(() => source.OrThrow(() => new ExpectedException()));
        }
        
        [Fact]
        public async Task Async_OnSome_WithFunction_ReturnsResultOfSome()
        {
            const int expected = 123132;
            var source = Some(expected).ToAsync();
            var result = await source.OrThrow(() => new ExpectedException());
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public async Task Async_OnNone_WithFunction_ThrowsException()
        {
            var source = AsyncMaybe<int>.None();
            await Assert.ThrowsAsync<ExpectedException>(() => source.OrThrow(() => new ExpectedException()));
        }
    }
}
