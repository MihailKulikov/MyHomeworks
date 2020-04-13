using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TResult> Map<TSource,TResult>(this IEnumerable<TSource> inputEnumerable, Func<TSource, TResult> changer)
        {
            foreach (var item in inputEnumerable)
            {
                yield return changer(item);
            }
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> inputEnumerable, Func<T, bool> filter)
        {
            foreach (var item in inputEnumerable)
            {
                if (filter(item))
                    yield return item;
            }
        }

        public static TResult Fold<TSource, TResult>(this IEnumerable<TSource> inputEnumerable, TResult seed,
            Func<TResult, TSource, TResult> func)
        {
            foreach (var item in inputEnumerable)
            {
                seed = func(seed, item);
            }

            return seed;
        }
    }
}