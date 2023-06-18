using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Executes the given <paramref name="action" /> if the <paramref name="maybe" /> has no value.
        ///     If the action throws an exception, it is caught and the error handler is invoked. 
        /// </summary>
        public static async Task ExecuteNoValueTry<T>(this Task<Maybe<T>> maybeTask, Func<T, Task> asyncAction, Action<Exception> errorHandler = null)
        {
            var maybe = await maybeTask.DefaultAwait();
            
            if (maybe.HasValue)
                return;
            
            await Maybe<T>.Try(() => asyncAction(maybe.GetValueOrThrow()), errorHandler);
        }
    }
}
