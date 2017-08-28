using Amplified.Monads.Extensions;
using Xunit;

namespace Amplified.Monads
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