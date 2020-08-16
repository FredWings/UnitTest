using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frame1
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public interface IStockFeed
    {
        int GetSharePrice(string company);
    }

    public class StockAnalyzer
    {
        private IStockFeed stockFeed;
        public StockAnalyzer(IStockFeed feed)
        {
            stockFeed = feed;
        }
        public int GetContosoPrice()
        {
            return stockFeed.GetSharePrice("C000");
        }
    }

    public interface IMyInterface
    {
        int MyMethod(string value);
        int Value { get; set; }
    }

    // code under test
    public interface IWithEvents
    {
        event EventHandler Changed;
    }

    public interface IGenericMethod
    {
        T GetValue<T>();
    }

    public static class Y2KChecker
    {
        public static void Check()
        {
            if (DateTime.Now == new DateTime(2000, 1, 1))
                throw new ApplicationException("yzkbug");
        }
    }

    public class MyComponent
    {
        public MyComponent()
        {
        }

        public int GetTheCurrentYear()
        {
            return DateTime.Now.Year;
        }
    }

    public static class MyClass
    {
        public static int MyMethod()
        {
            return 3;
        }
    }

    public class MyClassOne
    {
        public int MyMethod() { return 1; }
    }
}
