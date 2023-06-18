using System;

namespace CSharpFunctionalExtensions
{
    public partial struct Maybe<T>
    {
        /// <summary>
        ///     Attempts to execute the supplied function. Returns a Maybe with the function result.
        ///     If the function throws an exception, the error handler is invoked and None is returned.
        /// </summary>
        public static Maybe<T> Try(Func<T> func, Action<Exception> errorHandler = null)
        {
            try
            {
                return From(func());
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
        public static void Try(Action func, Action<Exception> errorHandler = null)
        {
            try
            {
                func();
            }
            catch (Exception exc)
            {
                errorHandler?.Invoke(exc);
            }
        }
    }
}
