using System.Threading.Tasks;
using Amplified.Monads.Maybe.Extensions;
using Xunit;

namespace Amplified.Monads.Maybe
{
    // ReSharper disable once InconsistentNaming
    public class Maybe__FilterAsync
    {
        [Fact]
        public async Task OnSome_WithTruePredicate_ReturnsSome()
        {
            var expected = new {Flag = true};
            var source = await Maybe.Some(expected).FilterAsync(it => Task.FromResult(it.Flag));
            source.MustBeSome();
        }

        [Fact]
        public async Task OnSome_WithFalsePredicate_ReturnsNone()
        {
            var expected = new {Flag = false};
            var source = await Maybe.Some(expected).FilterAsync(it => Task.FromResult(it.Flag));
            source.MustBeNone();
        }
        
        [Fact]
        public async Task OnNone_WithTruePredicate_ReturnsNone()
        {
            var invocations = 0;
            var source = await Maybe<object>.None().FilterAsync(it => { invocations++; return Task.FromResult(true); });
            source.MustBeNone();
            Assert.Equal(0, invocations);
        }

        [Fact]
        public async Task OnNone_WithFalsePredicate_ReturnsNone()
        {
            var invocations = 0;
            var source = await Maybe<object>.None().FilterAsync(it => { invocations++; return Task.FromResult(true); });
            source.MustBeNone();
            Assert.Equal(0, invocations);
        }
    }
}
