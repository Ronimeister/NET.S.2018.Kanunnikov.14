using System;
using System.Collections.Generic;

namespace BinarySearchLib
{
    /// <summary>
    /// Class that provides functionality for binary search
    /// </summary>
    /// <typeparam name="T">Expected type</typeparam>
    public static class BinarySearch<T>
    {
        #region Public API
        /// <summary>
        /// Method that returns position of <paramref name="element"/> in <paramref name="array"/> if such is exist
        /// </summary>
        /// <param name="array">Needed array</param>
        /// <param name="element">Needed element to find</param>
        /// <exception cref="ArgumentNullException">Throws when:
        /// 1) <paramref name="array"/> is equal to null
        /// 2) <paramref name="element"/> is equal to null
        /// </exception>
        /// <returns>position of <paramref name="element"/> in <paramref name="array"/> if such is exist</returns>
        public static int? Search(T[] array, T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException($"{nameof(element)} can't be equal to null!");
            }

            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be equal to null!");
            }

            if (array.Length == 0)
            {
                return null;
            }
            
            return Find(array, element, null);
        }

        /// <summary>
        /// Method that returns position of <paramref name="element"/> in <paramref name="array"/> if such is exist based on <paramref name="comparer"/>
        /// </summary>
        /// <param name="array">Needed array</param>
        /// <param name="element">Needed element to find</param>
        /// <param name="comparer"><see cref="IComparer{T}"/> comparer</param>
        /// <exception cref="ArgumentNullException">Throws when:
        /// 1) <paramref name="array"/> is equal to null
        /// 2) <paramref name="element"/> is equal to null
        /// 3) <paramref name="comparer"/> is equal to null
        /// </exception>
        /// <returns>position of <paramref name="element"/> in <paramref name="array"/> if such is exist based on <paramref name="comparer"/></returns>
        public static int? Search(T[] array, T element, IComparer<T> comparer)
        {
            if (element == null)
            {
                throw new ArgumentNullException($"{nameof(element)} can't be equal to null!");
            }

            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be equal to null!");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException($"{nameof(comparer)} can't be equal to null!");
            }

            if (array.Length == 0)
            {
                return null;
            }

            if (typeof(T).IsAssignableFrom(typeof(IComparable<T>)))
            {
                throw new ArgumentException($"{nameof(T)} should be inherited from IComparable<T>!");
            }

            return Find(array, element, comparer);
        }

        /// <summary>
        /// Method that returns position of <paramref name="element"/> in <paramref name="array"/> if such is exist based on <paramref name="comparison"/>
        /// </summary>
        /// <param name="array">Needed array</param>
        /// <param name="element">Needed element to find</param>
        /// <param name="comparison">Delegate that provides comparation</param>
        /// <exception cref="ArgumentNullException">Throws when:
        /// 1) <paramref name="array"/> is equal to null
        /// 2) <paramref name="element"/> is equal to null
        /// 3) <paramref name="comparison"/> is equal to null
        /// </exception>
        /// <returns>position of <paramref name="element"/> in <paramref name="array"/> if such is exist based on <paramref name="comparison"/></returns>
        public static int? Search(T[] array, T element, Comparison<T> comparison)
        {
            if (element == null)
            {
                throw new ArgumentNullException($"{nameof(element)} can't be equal to null!");
            }

            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be equal to null!");
            }

            if (comparison == null)
            {
                throw new ArgumentNullException($"{nameof(comparison)} can't be equal to null!");
            }

            if (array.Length == 0)
            {
                return null;
            }

            if (typeof(T).IsAssignableFrom(typeof(IComparable<T>)))
            {
                throw new ArgumentException($"{nameof(T)} should be inherited from IComparable<T>!");
            }

            return Find(array, element, Comparer<T>.Create(comparison));
        }
        #endregion

        #region Private methods
        private static int? Find(T[] array, T element, IComparer<T> comparer)
        {
            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }

            int lowerBound = array.GetLowerBound(0);
            int higherBound = lowerBound + array.Length - 1;

            while (lowerBound <= higherBound)
            {
                int i = lowerBound + ((higherBound - lowerBound) >> 1);
                int order = comparer.Compare(array[i], element);

                if (order == 0)
                {
                    return i;
                }

                if (order < 0)
                {
                    lowerBound = i + 1;
                }
                else
                {
                    higherBound = i - 1;
                }
            }

            return null;
        }
        #endregion
    }
}