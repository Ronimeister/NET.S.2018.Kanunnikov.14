using System;
using System.Collections.Generic;

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
        public static List<long> GenerateSequence(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException($"{nameof(quantity)} should be bigger than 0!");
            }

            if (quantity == 1)
            {
                return new List<long> { 0 };
            }

            if (quantity == 2)
            {
                return new List<long> { 0, 1 };
            }

            return GenerateNewSequence(quantity);
        }
        #endregion

        #region Private methods
        private static List<long> GenerateNewSequence(int quantity)
        {
            long firstNumber = 0, secondNumber = 1, sum = 0;
            List<long> resultSequence = new List<long>(quantity) { firstNumber, secondNumber};

            while(resultSequence.Count < quantity)
            {
                Calculate(ref firstNumber, ref secondNumber, ref sum);
                resultSequence.Add(sum);
            }

            return resultSequence;
        }

        private static void Calculate(ref long first, ref long second, ref long sum)
        {
            sum = first + second;
            first = second;
            second = sum;
        }
        #endregion
    }
}
