using System;
using System.Collections;
using System.Collections.Generic;
using EnumerableSequences.Interfaces;

namespace EnumerableSequences
{
    /// <summary>
    /// Class EnumerableSequences.
    /// </summary>
    public static class EnumerableSequences
    {
        /// <summary>
        /// Filters array by filter.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The filter.</param>
        /// <typeparam name="TSource">Input parameter.</typeparam>
        /// <returns>Filtered array.</returns>
        public static IEnumerable<TSource> FilterBy<TSource>(this IEnumerable<TSource> source, IPredicate<TSource> predicate)
        {
            IsValidationSource(source);

            if (predicate is null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} cannot be null.");
            }

            foreach (var item in source)
            {
                if (predicate.IsMatch(item))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Transform array by transformer.
        /// </summary>
        /// <typeparam name="TSource">Input parameter.</typeparam>
        /// <typeparam name="TResult">Output parameter.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="transformer">The transformer.</param>
        /// <returns>Transformed array.</returns>
        public static IEnumerable<TResult> Transform<TSource, TResult>(this IEnumerable<TSource> source, ITransformer<TSource, TResult> transformer)
        {
            IsValidationSource(source);
            if (transformer is null)
            {
                throw new ArgumentNullException($"{nameof(transformer)} cannot be null.");
            }

            return Transform(source, transformer.Transform);
        }

        /// <summary>
        /// Sorting array by comparer.
        /// </summary>
        /// <typeparam name="TSource">Input parameter.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>Sorted array.</returns>
        public static IEnumerable<TSource> OrderAccordingTo<TSource>(this IEnumerable<TSource> source, IComparer<TSource> comparer)
        {
            IsValidationSource(source);

            if (comparer is null)
            {
                throw new ArgumentNullException($"{nameof(comparer)} cannot be null.");
            }

            int length = 0;
            foreach (var item in source)
            {
                length++;
            }

            int index = 0;
            var sorceToSort = new TSource[length];
            foreach (var item in source)
            {
                sorceToSort[index] = item;
                index++;
            }

            // while (source.GetEnumerator().MoveNext())
            // {
            //    sorceToSort[index] = source.GetEnumerator().Current;
            // }
            // Array.Copy(source, sorceToSort, sorceToSort.Length);
            Array.Sort(sorceToSort, comparer);
            foreach (var item in sorceToSort)
            {
                yield return item;
            }
        }

        /// <summary>
        ///  TypeOf method.
        /// </summary>
        /// <typeparam name="TResult">Output parameter.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>The array of objects of a certain type.</returns>
        public static IEnumerable<TResult> TypeOf<TResult>(this IEnumerable<object> source)
        {
            IsValidationSource(source);

            foreach (var item in source)
            {
                if (item is TResult)
                {
                    yield return (TResult)item;
                }
            }
        }

        /// <summary>
        /// Reverse method.
        /// </summary>
        /// <typeparam name="TSource">Input parameter.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>Reverse array.</returns>
        public static IEnumerable<TSource> Reverse<TSource>(this TSource[] source)
        {
            IsValidationSource(source);
            var result = new TSource[source.Length];
            int index = source.Length - 1;
            foreach (var item in source)
            {
                result[index--] = item;
            }

            foreach (var item in result)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Filters array by filter.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The filter.</param>
        /// <typeparam name="TSource">Input parameter.</typeparam>
        /// <returns>Filtered array.</returns>
        public static IEnumerable<TSource> FilterBy<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
        {
            IsValidationSource(source);
            return FilterBy(source, new PredicateAdapty<TSource>(predicate));
        }

        /// <summary>
        /// Transform array by transformer.
        /// </summary>
        /// <typeparam name="TSource">Input parameter.</typeparam>
        /// <typeparam name="TResult">Output parameter.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="converter">The converter.</param>
        /// <returns>Transformed array.</returns>
        public static IEnumerable<TResult> Transform<TSource, TResult>(this IEnumerable<TSource> source, Converter<TSource, TResult> converter)
        {
            IsValidationSource(source);

            if (converter is null)
            {
                throw new ArgumentNullException($"{nameof(converter)} cannot be null.");
            }

            foreach (var item in source)
            {
                yield return converter(item);
            }
        }

        /// <summary>
        /// Sorting array by comparer.
        /// </summary>
        /// <typeparam name="TSource">Input parameter.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="comparison">The comparer.</param>
        /// <returns>Sorted array.</returns>
        public static IEnumerable<TSource> OrderAccordingTo<TSource>(this IEnumerable<TSource> source, Comparison<TSource> comparison)
        {
            IsValidationSource(source);
            return OrderAccordingTo(source, new ComparisonAdapty<TSource>(comparison));
        }

        private static void IsValidationSource(IEnumerable source)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} cannot be null.");
            }

            if (!source.GetEnumerator().MoveNext())
            {
                throw new ArgumentException($"{nameof(source)} cannot be empty.");
            }
        }
    }
}
