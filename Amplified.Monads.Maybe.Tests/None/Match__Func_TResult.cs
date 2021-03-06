using Xunit;

namespace Amplified.Monads
{
    // ReSharper disable once InconsistentNaming
    public class None__Match__Func_TResult
    {
        [Fact]
        public void WithLambda()
        {
            var source = new None();
            var result = source.Match(() => 1);
            Assert.Equal(1, result);
        }
        
        [Fact]
        public void WithMethodReference()
        {
            int Match() => 1;
            
            var source = new None();
            var result = source.Match(Match);
            Assert.Equal(1, result);
        }
    }
}
