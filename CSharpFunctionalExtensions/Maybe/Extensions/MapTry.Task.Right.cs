using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Creates a new Maybe from the return value of a given function. If the calling Maybe is a failure, None is returned instead.
        ///     If the function throws an exception, the error handler is invoked and None is returned.
        /// </summary>
        public static async Task<Maybe<K>> MapTry<T, K>(this Maybe<T> maybe, Func<T, Task<K>> selector, Action<Exception> errorHandler = null)
        {
            if (maybe.HasNoValue)
                return Maybe<K>.None;

            return await Maybe<K>.Try(() => selector(maybe.GetValueOrThrow()), errorHandler).DefaultAwait();
        }
    }
}
