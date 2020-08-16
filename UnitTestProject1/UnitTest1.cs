using System;
using frame1;
using frame1.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class TestStockAnalyzer
    {
        [TestMethod]
        public void TestContosoStockPrice()
        {
            //Arrange:
            //Create the fake stockFeed:
            IStockFeed stockFeed = new frame1.Fakes.StubIStockFeed()
            {
                GetSharePriceString = (company) => { return 1234; }
            };

            var componentUnderTest = new StockAnalyzer(stockFeed);

            int actualValue = componentUnderTest.GetContosoPrice();

            Assert.AreEqual(1234, actualValue);
        }
    }

    [TestClass]
    public class TestMyComponent
    {

        [TestMethod]
        public void TestVariableContosoPrice()
        {
            //Arrange:
            int priceToReturn = 345;
            string companyCodeUsed = string.Empty;
            var componentUnderTest = new StockAnalyzer(new frame1.Fakes.StubIStockFeed()
            {
                GetSharePriceString = (company) =>
                {
                    companyCodeUsed = company;
                    return priceToReturn;
                }
            });



            int actualResult = componentUnderTest.GetContosoPrice();

            Assert.AreEqual(priceToReturn, actualResult);

            Assert.AreEqual("C000", companyCodeUsed);
        }

        [TestMethod]
        public void TestOtherProperties()
        {
            int i = 5;
            var stub = new StubIMyInterface();
            stub.MyMethodString = (value) => 1;
            stub.ValueGet = () => i;
            stub.ValueSetInt32 = (value) => i = value;

            var stubevent = new StubIWithEvents();
            stubevent.ChangedEvent += fsgsd;

            Assert.AreEqual(1, 1);
        }

        public void fsgsd(object sender, EventArgs e)
        {

        }

        // unit test code
        [TestMethod]
        public void TestGetValue()
        {
            var stub = new StubIGenericMethod();
            stub.GetValueOf1<int>(() => 5);
            IGenericMethod target = stub as IGenericMethod;
            Assert.AreEqual(5, target.GetValue<int>());
        }
    }

    [TestClass]
    public class TestMyShim{
        
        [TestMethod]
        public void Y2kCheckerTest()
        {
            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2000, 1, 1);
                

                Assert.ThrowsException<ApplicationException>(() => { Y2KChecker.Check(); });
            }
        }

        [TestMethod]
        public void TestCurrentYear()
        {
            int fixedYear = 2000;
            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(fixedYear, 1, 1);

                var componentUnderTest = new MyComponent();

                int year = componentUnderTest.GetTheCurrentYear();

                Assert.AreEqual(fixedYear, year);
            }
        }

        [TestMethod]
        public void TestStatic()
        {
            ShimMyClass.MyMethod = () => 5;
        }

        [TestMethod]
        public void TestIns()
        {
            //ShimMyClassOne.AllInstances.MyMethod = () => 7;

            var myclass1 = new ShimMyClassOne()
            {
                MyMethod = () => 5
            };

            var myclass2 = new ShimMyClassOne()
            {
                MyMethod = () => 10
            };

            var shim = new ShimMyClassOne();
            var instance = shim.Instance;

            var shim1 = new ShimMyClassOne();
            MyClassOne instan = shim1;
        }
    }
}
