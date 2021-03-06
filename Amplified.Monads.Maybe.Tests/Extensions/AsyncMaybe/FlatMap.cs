using System.Threading.Tasks;
using Amplified.Monads.Extensions;
using Xunit;
using static Amplified.Monads.Maybe;

namespace Amplified.Monads
{
    // ReSharper disable once InconsistentNaming
    public class AsyncMaybe_FlatMap
    {
        [Fact]
        public async Task Sync_ReturningSome_WhenSome_ReturnsResultOfInner()
        {
            const int expected = 5;
            var result = await Some(2).ToAsync().FlatMap(some => Some(some + 3)).OrFail();
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Async_ReturningSome_WhenSome_ReturnsResultOfInner()
        {
            const int expected = 5;
            var result = await Some(2).ToAsync().FlatMapAsync(some => Task.FromResult(Some(some + 3))).OrFail();
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public async Task Sync_ReturningAsyncSome_WhenSome_ReturnsResultOfInner()
        {
            const int expected = 5;
            var result = await Some(2).ToAsync().FlatMap(some => Some(some + 3).ToAsync()).OrFail();
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Async_ReturningAsyncSome_WhenSome_ReturnsResultOfInner()
        {
            const int expected = 5;
            var result = await Some(2).ToAsync().FlatMapAsync(some => Task.FromResult(Some(some + 3).ToAsync())).OrFail();
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Sync_ReturningSome_WhenNone_ReturnsNone()
        {
            var isNone = await AsyncMaybe<int>.None().FlatMap(some => Some(some + 3)).IsNone;
            Assert.True(isNone);
        }

        [Fact]
        public async Task Async_ReturningSome_WhenNone_ReturnsNone()
        {
            var isNone = await AsyncMaybe<int>.None().FlatMapAsync(some => Task.FromResult(Some(some + 3))).IsNone;
            Assert.True(isNone);
        }

        [Fact]
        public async Task Sync_ReturningAsyncSome_WhenNone_ReturnsNone()
        {
            var isNone = await AsyncMaybe<int>.None().FlatMap(some => Some(some + 3).ToAsync()).IsNone;
            Assert.True(isNone);
        }

        [Fact]
        public async Task Async_ReturningAsyncSome_WhenNone_ReturnsNone()
        {
            var isNone = await AsyncMaybe<int>.None().FlatMapAsync(some => Task.FromResult(Some(some + 3).ToAsync())).IsNone;
            Assert.True(isNone);
        }
    }
}
