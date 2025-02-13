using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Executes the given <paramref name="action" /> if the <paramref name="maybe" /> has a value.
        ///     If the action throws an exception, it is caught and the error handler is invoked. 
        /// </summary>
        public static async Task ExecuteTry<T>(this Maybe<T> maybe, Func<T, Task> asyncAction, Action<Exception> errorHandler = null)
        {
            if (maybe.HasNoValue)
                return;
            
            await Maybe<T>.Try(() => asyncAction(maybe.GetValueOrThrow()), errorHandler);
        }
    }
}
