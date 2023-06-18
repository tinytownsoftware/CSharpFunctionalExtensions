#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Creates a new Maybe from the return value of a given function. If the calling Maybe is a failure, None is returned instead.
        /// </summary>
        public static async ValueTask<Maybe<K>> Map<T, K>(this ValueTask<Maybe<T>> valueTask, Func<T, K> selector)
        {
            Maybe<T> maybe = await valueTask;
            return maybe.Map(selector);
        }
    }
}
#endif