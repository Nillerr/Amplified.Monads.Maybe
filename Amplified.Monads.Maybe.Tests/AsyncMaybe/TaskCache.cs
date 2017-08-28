using System.Threading.Tasks;

namespace Amplified.Monads
{
    internal static class TaskCache
    {
        internal static readonly Task CompletedTask = Task.FromResult<object>(null);
    }
}