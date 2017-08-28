using System.Threading.Tasks;
using Amplified.Monads.Maybe.Extensions;
using Xunit;
using static Amplified.Monads.Maybe.Maybe;

namespace Amplified.Monads.Maybe
{
    // ReSharper disable once InconsistentNaming
    public class AsyncMaybe_OrGet
    {
        [Fact]
        public async Task Sync_OnSome_ReturnsResultOfSome()
        {
            const int expected = 123;
            var result = await Some(expected).ToAsync().OrGet(() => 321);
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public async Task Sync_OnNone_ReturnsResultOfFunction()
        {
            const int expected = 321;
            var result = await Maybe<int>.None().ToAsync().OrGet(() => expected);
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public async Task Async_OnSome_ReturnsResultOfSome()
        {
            const int expected = 123;
            var result = await Some(expected).ToAsync().OrGetAsync(async () => await Task.FromResult(321));
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public async Task Async_OnNone_ReturnsResultOfFunction()
        {
            const int expected = 321;
            var result = await Maybe<int>.None().ToAsync().OrGetAsync(async () => await Task.FromResult(expected));
            Assert.Equal(expected, result);
        }
    }
}
