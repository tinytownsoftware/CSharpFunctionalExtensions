using System;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Executes the given <paramref name="action" /> if the <paramref name="maybe" /> has a value.
        ///     If the action throws an exception, it is caught and the error handler is invoked. 
        /// </summary>
        /// <param name="maybe"></param>
        /// <param name="action"></param>
        /// <param name="errorHandler"></param>
        /// <typeparam name="T"></typeparam>
        public static void ExecuteTry<T>(this Maybe<T> maybe, Action<T> action, Action<Exception> errorHandler = null)
        {
            if (maybe.HasNoValue)
                return;
            
            Maybe<T>.Try(() => action(maybe.GetValueOrThrow()), errorHandler);
        }
    }
}
