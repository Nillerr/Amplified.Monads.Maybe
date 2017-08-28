using System.Threading.Tasks;
using Amplified.Monads.Extensions;
using Amplified.Monads.Util;
using Xunit;

namespace Amplified.Monads
{
    // ReSharper disable once InconsistentNaming
    public class AsyncMaybe_MapAsync
    {
        #region AsyncMaybe<TResult> MapAsync<TResult>(Func<T, Task<TResult>> mapperAsync)
        
        [Fact]
        public async Task Async_WhenSome_ReturnsMappedResult()
        {
            const int expected = 5;
            var result = await AsyncMaybe<int>.Some(2).MapAsync(some => Task.FromResult(some + 3)).OrFail();
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task Async_WhenNone_ReturnsNone()
        {
            var isNone = await AsyncMaybe<int>.None().MapAsync(some => Task.FromResult(some + 3)).IsNone;
            Assert.True(isNone);
        }
        
        #endregion
    }
}