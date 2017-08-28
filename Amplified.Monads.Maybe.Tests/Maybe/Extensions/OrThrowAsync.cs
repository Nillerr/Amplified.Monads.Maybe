using System.Threading.Tasks;
using Amplified.Monads.Maybe.Extensions;
using Amplified.Monads.Maybe.Util;
using Xunit;

namespace Amplified.Monads.Maybe
{
    // ReSharper disable once InconsistentNaming
    public class Maybe__OrThrowAsync
    {
        [Fact]
        public async Task OnSome_WithLambda_ReturnsValue()
        {
            const int expected = 6;
            var source = Maybe<int>.Some(expected);
            var result = await source.OrThrowAsync(async () => new UnexpectedException());
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task OnNone_WithLambda_ThrowsException()
        {
            var source = Maybe<int>.None();
            await Assert.ThrowsAsync<ExpectedException>(() => source.OrThrowAsync(async () => new ExpectedException()));
        }
    }
}
