using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public partial struct Maybe<T>
    {
        /// <summary>
        ///     Attempts to execute the supplied function. Returns a Maybe with the function result.
        ///     If the function throws an exception, the error handler is invoked and None is returned.
        /// </summary>
        public static async Task<Maybe<T>> Try(Func<Task<T>> func, Action<Exception> errorHandler = null)
        {
            try
            {
                return From(await func().DefaultAwait());
            }
            catch (Exception exc)
            {
                errorHandler?.Invoke(exc);
                return None;
            }
        }
        
        /// <summary>
        ///     Attempts to execute the supplied function.
        ///     If the function throws an exception, the error handler is invoked.
        /// </summary>
        public static async Task Try(Func<Task> func, Action<Exception> errorHandler = null)
        {
            try
            {
                await func();
            }
            catch (Exception exc)
            {
                errorHandler?.Invoke(exc);
            }
        }
    }
}
