using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Creates a new Maybe from the return value of a given function. If the calling Maybe is a failure, None is returned instead.
        /// </summary>
        public static async Task<Maybe<K>> Map<T, K>(this Task<Maybe<T>> maybeTask, Func<T, K> selector)
        {
            var maybe = await maybeTask.DefaultAwait();
            return maybe.Map(selector);
        }
    }
}