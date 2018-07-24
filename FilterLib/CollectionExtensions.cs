using System;
using System.Collections.Generic;

namespace FilterLib
{
    /// <summary>
    /// Extension class for <see cref="IEnumerable{T}"/>
    /// </summary>
    public static class CollectionExtensions
    {
        #region Public API
        /// <summary>
        /// <see cref="IEnumerable{T}"/> extension method that provides functionality for filtering by some predicate
        /// </summary>
        /// <typeparam name="T">Needed param type</typeparam>
        /// <param name="source">Filtering <see cref="IEnumerable{T}"/></param>
        /// <param name="predicate">Rule for filtering</param>
        /// <returns>Filtered <paramref name="source"/></returns>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="predicate"/> or <paramref name="source"/> is equal to null</exception>
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T,bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{nameof(source)} can't be equal to null!");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} can't be equal to null!");
            }

            return source.FilterInner(predicate);
        }

        /// <summary>
        /// <see cref="IEnumerable{T}"/> extension method that provides transformation functionality
        /// </summary>
        /// <typeparam name="TSource"><paramref name="source"/> type</typeparam>
        /// <typeparam name="TResult">returned value type</typeparam>
        /// <param name="source">Filtering <see cref="IEnumerable{T}"/></param>
        /// <param name="convertor">Function that provides convertion functionality</param>
        /// <returns>Transformed <paramref name="source"/></returns>
        /// <exception cref="ArgumentNullException">Throws when <paramref name="convertor"/> or <paramref name="source"/> is equal to null</exception>
        public static IEnumerable<TResult> Transformer<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> convertor)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{nameof(source)} can't be equal to null!");
            }

            if (convertor == null)
            {
                throw new ArgumentNullException($"{nameof(convertor)} can't be equal to null!");
            }

            return source.TransformerInner(convertor);
        }
        #endregion

        #region Private methods
        private static IEnumerable<T> FilterInner<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        private static IEnumerable<TResult> TransformerInner<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> convertor)
        {
            foreach (TSource item in source)
            {
                yield return convertor(item);
            }
        }
        #endregion
    }

}