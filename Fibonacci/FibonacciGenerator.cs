using System;
using System.Collections.Generic;
using System.Numerics;

namespace Fibonacci
{
    public static class FibonacciGenerator
    {
        #region Public API
        /// <summary>
        /// Method that return Fibonacci sequence with user <paramref name="quantity"/>
        /// </summary>
        /// <param name="quantity">Needed quantity of sequence</param>
        /// <returns>Fibonacci sequence with user <paramref name="quantity"/></returns>
        /// <exception cref="ArgumentException">Throws when <paramref name="quantity"/> is less 1</exception>
        public static IEnumerable<BigInteger> GenerateSequence(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException($"{nameof(quantity)} should be bigger than 0!");
            }

            return GenerateNewSequence(quantity);
        }
        #endregion

        #region Private methods
        private static IEnumerable<BigInteger> GenerateNewSequence(int quantity)
        {
            BigInteger firstNumber = 0, secondNumber = 1, sum = 0;
            while(quantity-- != 0)
            {
                yield return firstNumber;
                Calculate(ref firstNumber, ref secondNumber, ref sum);
            }
        }

        private static void Calculate(ref BigInteger first, ref BigInteger second, ref BigInteger sum)
        {
            sum = first + second;
            first = second;
            second = sum;
        }
        #endregion
    }
}
