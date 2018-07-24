using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilterLib;
using NUnit.Framework;

namespace FilterLibTests
{
    [TestFixture]
    public class CollectionExtensionsTests
    {
        [TestCase(new int[] { 12, 672, 777, 7, -71, 11, 0, 2}, 7, ExpectedResult = new int[] { 672, 777, 7, -71})]
        [TestCase(new int[] { 12, 672, 777, 7, -71, 11, 0, 2 }, 2, ExpectedResult = new int[] { 12, 672, 2 })]
        [TestCase(new int[] { 12, 672, 777, 7, -71, 11, 0, 2, int.MaxValue, int.MinValue }, 2, ExpectedResult = new int[] { 12, 672, 2, int.MaxValue, int.MinValue })]
        public IEnumerable<int> Filter_IsCorrect_IntValue(IEnumerable<int> numbers, int filter)
        {
            IntPredicate predicate = new IntPredicate(filter);
            return numbers.Filter(x => predicate.IsMatch(x));
        }

        [TestCase(new string[] { "one", "two", "three" }, " pac!", ExpectedResult = new string[] { "one pac!", "two pac!", "three pac!" })]
        public IEnumerable<string> Transformer_IsCorrect_StringValue(IEnumerable<string> elements, string added)
            => elements.Transformer(x => x + added);

        [Test]
        public void Filter_NullArray_ArgumentNullException()
        {
            IEnumerable<int> numbers = null;
            IntPredicate predicate = new IntPredicate(7);
            Assert.Throws<ArgumentNullException>(() => numbers.Filter(x => predicate.IsMatch(x)));
        }

        [Test]
        public void Transformer_NullArray_ArgumentNullException()
        {
            IEnumerable<string> strings = null;
            Assert.Throws<ArgumentNullException>(() => strings.Transformer(x => x + " test"));
        }

    }
}
