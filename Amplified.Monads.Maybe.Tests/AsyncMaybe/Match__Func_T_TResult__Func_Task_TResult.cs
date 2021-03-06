using System.Threading.Tasks;
using Xunit;

namespace Amplified.Monads
{
    // ReSharper disable once InconsistentNaming
    public class AsyncMaybe__Match__Func_T_TResult__Func_Task_TResult
    {
        [Fact]
        public async Task NoneValue_WithLambdas()
        {
            var invocations = 0;
            var source = AsyncMaybe<int>.None();
            var result = await source.Match(some => some + 1, () => { invocations++; return Task.FromResult(0); });
            Assert.Equal(0, result);
            Assert.Equal(1, invocations);
        }
        
        [Fact]
        public async Task WithLambdas()
        {
            var source = AsyncMaybe<int>.Some(1);
            var result = await source.Match(some => some + 1, () => Task.FromResult(0));
            Assert.Equal(2, result);
        }
        
        [Fact]
        public async Task WithSomeLambda_AndNoneReference()
        {
            Task<int> MatchNone() => Task.FromResult(0);
            
            var source = AsyncMaybe<int>.Some(1);
            var result = await source.Match(some => some + 1, noneAsync: MatchNone);
            Assert.Equal(2, result);
        }
        
        [Fact]
        public async Task WithSomeReference_AndNoneLambda()
        {
            int MatchSome(int some) => some + 1;
            
            var source = AsyncMaybe<int>.Some(1);
            var result = await source.Match(some: MatchSome, noneAsync: () => Task.FromResult(0));
            Assert.Equal(2, result);
        }
        
        [Fact]
        public async Task WithReferences()
        {
            int MatchSome(int some) => some + 1;
            Task<int> MatchNone() => Task.FromResult(0);
            
            var source = AsyncMaybe<int>.Some(1);
            var result = await source.Match(some: MatchSome, noneAsync: MatchNone);
            Assert.Equal(2, result);
        }
    }
}
