using System;
using System.Collections.Generic;
using BinarySearchLib;
using NUnit.Framework;

namespace BinarySearchLibTests
{
    [TestFixture]
    public class BinarySearchTests
    {
        [TestCase(new double[] { 1, 2, 3, 4 }, 3, ExpectedResult = 2)]
        [TestCase(new double[] { 1, 2, 3, 4, 5, 6, 7 }, 1, ExpectedResult = 0)]
        [TestCase(new double[] { 1, 2, 3, 4, 5, 6, 7 }, 7, ExpectedResult = 6)]
        [TestCase(new double[] { 1, 2, 3, 4, 5, 6, 7, 7 }, 7, ExpectedResult = 6)]
        [TestCase(new double[] { 1, 2, 3, 4 }, 6, ExpectedResult = -1)]
        public int BinarySearch_IsCorrect(double[] array, double element)
            => BinarySearch<double>.Search(array, element);

        [TestCase(new int[] { 1, 2, 3, 4 }, 3, ExpectedResult = 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 1, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 7, ExpectedResult = 6)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 7 }, 7, ExpectedResult = 6)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 6, ExpectedResult = -1)]
        public int BinarySearch_WithComparer_IsCorrect(int[] array, int element)
        {
            int comparisson(int a, int b)
            {
                if (a > b)
                {
                    return 1;
                }

                if (a < b)
                {
                    return -1;
                }

                return 0;
            }

            Comparer<int> comparer = Comparer<int>.Create(comparisson);

            return BinarySearch<int>.Search(array, element, comparer);
        }

        [Test]
        public void BinarySearch_NullArray_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => BinarySearch<object>.Search(null, 1));

        [Test]
        public void BinarySearch_NullElemnt_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => BinarySearch<object>.Search(new object[] { 1, 2, 3 }, null));

        [Test]
        public void BinarySearch_NullComparer_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => BinarySearch<object>.Search(new object[] { 1, 2, 3}, 1, null));
    }
}
