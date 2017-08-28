using Amplified.Monads.Maybe.Extensions;
using Xunit;

namespace Amplified.Monads.Maybe
{
    // ReSharper disable once InconsistentNaming
    public class None__ToEnumerable
    {
        [Fact]
        public void ReturnsEmptyEnumerable()
        {
            var source = default(None);
            var result = source.ToEnumerable<int>();
            Assert.Empty(result);
        }
    }
}