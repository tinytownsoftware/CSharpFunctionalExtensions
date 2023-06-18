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
        public static async Task ExecuteNoValueTry<T>(this Maybe<T> maybe, Func<T, Task> asyncAction, Action<Exception> errorHandler = null)
        {
            if (maybe.HasValue)
                return;
            
            await Maybe<T>.Try(() => asyncAction(maybe.GetValueOrThrow()), errorHandler);
        }
    }
}
