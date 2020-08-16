using System;

namespace MyMath
{
    public class Class1
    {
    }

    public class Rooter
    {
        public double SquareRoot(double input)
        {
            if (input <= 0.0)
                throw new ArgumentOutOfRangeException();

            double result = input;
            double previousResult = -input;
            while (Math.Abs(previousResult - result) > result / 1000)
            {
                previousResult = result;
                result = (result + input / result) / 2;
                //result = result - (result * result - input) / (2 * result);
            }
            return result;
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
}
