using Xunit;

namespace Amplified.Monads
{
    // ReSharper disable once InconsistentNaming
    public class None__op_Equality
    {
        [Fact]
        public void EqualsOtherNone()
        {
            var source = new None();
            var other = new None();
            var result = source == other;
            Assert.True(result);
        }
    }
}
