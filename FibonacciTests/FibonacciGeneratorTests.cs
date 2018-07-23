using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Fibonacci;
using System.Numerics;

namespace FibonacciTests
{
    [TestFixture]
    public class FibonacciGeneratorTests
    {
        [Test]
        public void FibonacciGenerator_IsCorrect()
        {
            int quantity = 6;
            List<List<BigInteger>> expectedSequences = new List<List<BigInteger>> { new List<BigInteger> { 0 },
                new List<BigInteger> { 0, 1 }, new List<BigInteger> { 0, 1, 1 }, new List<BigInteger> { 0, 1, 1, 2},
                new List<BigInteger> { 0, 1, 1, 2, 3} , new List<BigInteger> { 0, 1, 1, 2, 3, 5 } };

            IEnumerable<BigInteger> actual;
            for(int i = 1; i <= quantity; i++)
            {
                actual = FibonacciGenerator.GenerateSequence(i);
                CollectionAssert.AreEqual(expectedSequences[i - 1], actual);
            }
        }

        [TestCase(100, ExpectedResult = 100)]
        [TestCase(500, ExpectedResult = 500)]
        [TestCase(1000, ExpectedResult = 1000)]
        [TestCase(5000, ExpectedResult = 5000)]
        [TestCase(10000, ExpectedResult = 10000)]
        [TestCase(15000, ExpectedResult = 15000)]
        [TestCase(25000, ExpectedResult = 25000)]
        [TestCase(50000, ExpectedResult = 50000)]
        public int FibonacciGenerator_BigQuantity(int quantity)
            => FibonacciGenerator.GenerateSequence(quantity).ToArray().Length;

        [Test]
        public void FibonacciGenerator_IncorrectQuantity_ArgumentException()
            => Assert.Throws<ArgumentException>(() => FibonacciGenerator.GenerateSequence(-25));
    }
}
