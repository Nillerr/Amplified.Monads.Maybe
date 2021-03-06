using Xunit;
using static Amplified.Monads.Maybe;

namespace Amplified.Monads
{
    // ReSharper disable once InconsistentNaming
    public class Maybe__Match__Func_T_TResult__Func_None_TResult
    {
        [Fact]
        public void WithLambdas()
        {
            var source = Some(1);
            var result = source.Match(some => some + 1, none => 0);
            Assert.Equal(2, result);
        }
        
        [Fact]
        public void WithSomeLambda_AndNoneReference()
        {
            int MatchNone(None none) => 0;
            
            var source = Some(1);
            var result = source.Match(some => some + 1, MatchNone);
            Assert.Equal(2, result);
        }
        
        [Fact]
        public void WithSomeReference_AndNoneLambda()
        {
            int MatchSome(int some) => some + 1;
            
            var source = Some(1);
            var result = source.Match(MatchSome, none => 0);
            Assert.Equal(2, result);
        }
        
        [Fact]
        public void WithReferences()
        {
            int MatchSome(int some) => some + 1;
            int MatchNone(None none) => 0;
            
            var source = Some(1);
            var result = source.Match(MatchSome, MatchNone);
            Assert.Equal(2, result);
        }
    }
}
