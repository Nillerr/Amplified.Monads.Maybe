using System.Threading.Tasks;

namespace Amplified.Monads.Maybe
{
    internal static class TaskCache
    {
        internal static readonly Task CompletedTask = Task.FromResult<object>(null);
    }
}