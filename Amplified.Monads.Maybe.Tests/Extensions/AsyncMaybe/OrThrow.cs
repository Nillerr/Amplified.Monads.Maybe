using System.Threading.Tasks;
using Amplified.Monads.Extensions;
using Amplified.Monads.Util;
using Xunit;
using static Amplified.Monads.Maybe;

namespace Amplified.Monads
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
