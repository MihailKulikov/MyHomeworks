using System;
using System.Collections.Generic;

namespace Extensions
{
    /// <summary>
    /// Provides a set of static methods for querying objects that implement IEnumerable&lt;T&gt;
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Projects each element of a sequence into a new form.
        /// </summary>
        /// <param name="source">A sequence of values to invoke a transform function on.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TResult">The type of the value returned by selector.</typeparam>
        /// <returns>An IEnumerable&lt;T&gt; whose elements are the result of invoking the transform function on each element of source.</returns>
        public static IEnumerable<TResult> Map<TSource,TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <param name="source">An IEnumerable&lt;T&gt; to filter.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <returns>An IEnumerable&lt;T&gt; that contains elements from the input sequence that satisfy the condition.</returns>
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                    yield return item;
            }
        }

        /// <summary>
        /// Applies an accumulator function over a sequence. The specified seed value is used as the initial accumulator value.
        /// </summary>
        /// <param name="source">An IEnumerable&lt;T&gt; to aggregate over.</param>
        /// <param name="seed">The initial accumulator value.</param>
        /// <param name="func">An accumulator function to be invoked on each element.</param>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
        /// <returns>The final accumulator value.</returns>
        public static TAccumulate Fold<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func)
        {
            foreach (var item in source)
            {
                seed = func(seed, item);
            }

            return seed;
        }
    }
}