using Xunit;

namespace Amplified.Monads
{
    // ReSharper disable once InconsistentNaming
    public class None__ToString
    {
        [Fact]
        public void ReturnsEmptyString()
        {
            var source = new None();
            var str = source.ToString();
            Assert.Equal(string.Empty, str);
        }
    }
}
