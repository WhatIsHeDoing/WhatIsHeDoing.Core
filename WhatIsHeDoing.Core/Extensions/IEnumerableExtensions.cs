using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace WhatIsHeDoing.Core.Extensions
{
    /// <summary>
    /// Provides extension methods for the IEnumerable interface
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Flattens a collection of collections of unequal lengths
        /// by calling <see cref="ZipJagged">ZipJagged</see> and flattens them.
        /// </summary>
        /// <typeparam name="T">Enumerated type</typeparam>
        /// <param name="me">The collection with which to zip</param>
        /// <param name="us">The collections to also enumerate with</param>
        /// <returns>A single collection</returns>
        public static IEnumerable<T> IterateJagged<T>
            (this IEnumerable<T> me, params IEnumerable<T>[] us)
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
        /// Enables a collection of unequal collection lengths
        /// to be iterated together, effectively as columns.
        /// </summary>
        /// <typeparam name="T">Enumerated type</typeparam>
        /// <param name="me">The collection with which to zip</param>
        /// <param name="us">The collections to also enumerate with</param>
        /// <returns>A collection of collections</returns>
        [SuppressMessage("Microsoft.Design",
            "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static IEnumerable<IEnumerable<T>> ZipJagged<T>
            (this IEnumerable<T> me, params IEnumerable<T>[] us)
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
