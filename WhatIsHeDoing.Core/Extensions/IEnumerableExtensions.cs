namespace WhatIsHeDoing.Core.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;

    /// <summary>
    /// Provides extension methods for the IEnumerable interface
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Aggregate with the index of the current element.
        /// </summary>
        /// <remarks>Leaves the underlying implementation to throw!</remarks>
        /// <typeparam name="TSource">Source type</typeparam>
        /// <typeparam name="TAccumulate">Aggregate type</typeparam>
        /// <param name="source">To iterate over</param>
        /// <param name="seed">Initial aggregate</param>
        /// <param name="func">To apply</param>
        /// <returns>Aggregate</returns>
        public static TAccumulate Aggregate<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, int, TAccumulate> func)
        {
            var result = seed;
            var index = 0;

            return source.Aggregate(
                result, (current, element) => func(current, element, index++));
        }

        /// <summary>
        /// Flattens a collection of collections of unequal lengths
        /// after calling <see cref="ZipJagged">ZipJagged</see>.
        /// </summary>
        /// <typeparam name="T">Enumerated type</typeparam>
        /// <param name="me">The collection with which to zip</param>
        /// <param name="us">The collections to also enumerate with</param>
        /// <returns>A single collection</returns>
        public static IEnumerable<T> IterateJagged<T>(
            this IEnumerable<T> me, params IEnumerable<T>[] us)
        {
            foreach (var iterator in me.ZipJagged(us))
            {
                foreach (var value in iterator)
                {
                    yield return value;
                }
            }
        }

        /// <summary>
        /// Returns a randomised order of the collection.
        /// </summary>
        /// <typeparam name="T">Source type</typeparam>
        /// <param name="source">This collection</param>
        /// <returns>Collection or null if it is null</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the source is null
        /// </exception>
        public static IEnumerable<T> Randomise<T>(this IEnumerable<T> source) =>
            source != null
            ? source.OrderBy(e => RandomNumberGenerator.Create().GetHashCode())
            : throw new ArgumentNullException(nameof(source));

        /// <summary>
        /// Filters all null elements from a collection.
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="source">To iterate over</param>
        /// <returns>Collection</returns>
        public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> source) =>
            source != null
            ? source.Where(e => e != null)
            : throw new ArgumentNullException(nameof(source));

        /// <summary>
        /// Enables a collection of unequal collection lengths
        /// to be iterated together, effectively as columns.
        /// </summary>
        /// <typeparam name="T">Enumerated type</typeparam>
        /// <param name="me">The collection with which to zip</param>
        /// <param name="us">The collections to also enumerate with</param>
        /// <returns>A collection of collections</returns>
        public static IEnumerable<IEnumerable<T>> ZipJagged<T>(
            this IEnumerable<T> me, params IEnumerable<T>[] us)
        {
            // Join the collections, ignore the null ones
            // and grab their enumerators.
            var iterators =
                new List<IEnumerator<T>> { me.GetEnumerator() }
                .Concat(us
                    .Where(u => u != null)
                    .Select(u => u.GetEnumerator()))
                .ToList();

            while (true)
            {
                // Filter all the iterators to those that have items left.
                var availableIterators = iterators
                    .Where(i => i.MoveNext())
                    .ToList();

                // Break out if none are available.
                if (availableIterators.Count < 1)
                {
                    break;
                }

                // Return these available values (column).
                yield return availableIterators
                    .Select(i => i.Current)
                    .ToList();
            }
        }
    }
}
