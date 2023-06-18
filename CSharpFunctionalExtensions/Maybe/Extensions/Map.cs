using System;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        /// <summary>
        ///     Creates a new Maybe from the return value of a given function. If the calling Maybe is a failure, None is returned instead.
        /// </summary>
        public static Maybe<K> Map<T, K>(in this Maybe<T> maybe, Func<T, K> selector)
        {
            if (maybe.HasNoValue)
                return Maybe<K>.None;

            return selector(maybe.GetValueOrThrow());
        }
    }
}