using System.Threading.Tasks;
using Amplified.Monads.Extensions;
using Xunit;
using static Amplified.Monads.Maybe;

namespace Amplified.Monads
{
    // ReSharper disable once InconsistentNaming
    public class AsyncMaybe_OrDefault
    {
        [Fact]
        public async Task Sync_OnSome_ReturnsResultOfSome()
        {
            const int expected = 123;
            var result = await Some(expected).ToAsync().OrDefault();
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public async Task Sync_OnNone_ReturnsDefaultValue()
        {
            var result = await Maybe<int>.None().ToAsync().OrDefault();
            Assert.Equal(default(int), result);
        }
    }
}
