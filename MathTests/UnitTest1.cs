using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMath;

namespace MathTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod, TestCategory("Data")]
        public void BasicRooterTest()
        {
            //Create an instance to test;
            Rooter rooter = new Rooter();
            //Define a test input and output value;
            double expectedResult = 2.0;
            double input = expectedResult * expectedResult;
            //Run the method under test;
            double actualResult = rooter.SquareRoot(input);
            //Verify the result:
            Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 100);
        }

        [TestMethod]
        [TestCategory("Student")]
        public void RooterValueRange()
        {
            Rooter rooter = new Rooter();
            for (double expected = 1e-8; expected < 1e+8; expected *= 3.2)
            {
                RooterOneValue(rooter, expected);
            }
        }

        private void RooterOneValue(Rooter rooter, double expectedResult)
        {
            double input = expectedResult * expectedResult;
            double actualResult = rooter.SquareRoot(input);
            Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 2);
        }

        [TestMethod]
        [TestCategory("ery")]
        public void RooterTestNegativeInputx()
        {
            Rooter rooter = new Rooter();
            try
            {
                rooter.SquareRoot(-10);
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail();
        }

    }

    [TestClass]
    class TestStockAnalyzer
    {
        [TestMethod]
        public void TestContosoStockPrice()
        {
            //IStockFeed stock = new StockAnalyzer.Fakes.StubIStockFeed();
        }
    }
}
