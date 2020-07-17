using NUnit.Framework;
using UnitTest;
using System;

namespace Tests
{
    [TestFixture]
    public class TestLargest
    {
        [Test]
        public void LargestOf3()
        {
            Assert.AreEqual(9, Cmp.Largest(new int[] { 8, 9, 7 }));
            Assert.AreEqual(9, Cmp.Largest(new int[] { 7, 9, 8 }));
            Assert.AreEqual(9, Cmp.Largest(new int[] { 7, 8, 9 }));
        }

        [Test]
        public void TestDrugs()
        {
            Assert.AreEqual(9, Cmp.Largest(new int[] { 9, 7, 9, 8 }));
        }

        [Test]
        public void TestOne()
        {
            Assert.AreEqual(1, Cmp.Largest(new int[] { 1 }));
        }

        [Test]
        public void TestNegative()
        {
            int[] negList = new int[] { -9, -8, -7 };
            Assert.AreEqual(-7, Cmp.Largest(negList));
        }

        [Test]
        public void TestEmpty()
        {
            Assert.That(() => Cmp.Largest(new int[] { }),
                Throws.TypeOf<ArgumentException>());
        }
    }
}