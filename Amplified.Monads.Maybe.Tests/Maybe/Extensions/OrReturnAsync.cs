using System.Threading.Tasks;
using Amplified.Monads.Maybe.Extensions;
using Xunit;

namespace Amplified.Monads.Maybe
{
    // ReSharper disable once InconsistentNaming
    public class Maybe__OrReturnAsync
    {
        [Fact]
        public async Task OnSome_ReturnsValue()
        {
            const int expected = 7;
            var source = Maybe<int>.Some(expected);
            var result = await source.OrReturnAsync(Task.FromResult(0));
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task OnNone_ReturnsInput()
        {
            const int expected = 10045;
            var source = Maybe<int>.None();
            var result = await source.OrReturnAsync(Task.FromResult(expected));
            Assert.Equal(expected, result);
        }
    }
}