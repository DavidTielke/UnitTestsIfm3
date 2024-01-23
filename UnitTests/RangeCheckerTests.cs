using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleClient;

namespace UnitTests
{
    public class RangeCheckerTests
    {
        [Test]
        public void IsInRange_MinGreaterMax_Exception()
        {
            var min = 2;
            var max = 1;

            Assert.Throws<ArgumentOutOfRangeException>(() => new RangeChecker()
                .IsInRange(min, max, 5));
        }

        [TestCase(4,8,6)]
        [TestCase(4,8,5)]
        [TestCase(4,8,7)]
        public void IsInRange_NormalInRange(int min, int max, int x)
        {
            var checker = new RangeChecker();

            var actual = checker.IsInRange(min, max, x);

            Assert.That(actual, Is.True);
        }

        [TestCase(1, 1, 1, true)]
        [TestCase(1, 1, 0, false)]
        [TestCase(1, 1, 2, false)]
        public void IsInRange_MinEqualsMax(int min, int max, int x, bool expected)
        {
            var checker = new RangeChecker();

            var actual = checker.IsInRange(min, max, x);

            Assert.AreEqual(actual, expected);
        }

        [TestCase(int.MinValue, int.MinValue, int.MinValue)]
        [TestCase(int.MaxValue, int.MaxValue, int.MaxValue)]
        public void IsInRange_ExtremeValues(int min, int max, int x)
        {
            var checker = new RangeChecker();

            var actual = checker.IsInRange(min, max, x);

            Assert.IsTrue(actual);
        }

        [TestCase(4, 8, 7, true)]
        [TestCase(4, 8, 8, true)]
        [TestCase(4, 8, 9, false)]
        public void IsInRange_UpperLimit(int min, int max, int x, bool expected)
        {
            var checker = new RangeChecker();

            var actual = checker.IsInRange(min, max, x);

            Assert.AreEqual(actual, expected);
        }

        [TestCase(4, 8, 5, true)]
        [TestCase(4, 8, 4, true)]
        [TestCase(4, 8, 3, false)]
        public void IsInRange_LowerLimit(int min, int max, int x, bool expected)
        {
            var checker = new RangeChecker();

            var actual = checker.IsInRange(min, max, x);

            Assert.AreEqual(actual, expected);
        }
    }
}
