using CodingChallenge.Interfaces;

namespace CodingChallenge
{
    public class Program
    {
        public Program(ICheckout checkout)
        {
        }

        public static void Main(string[] args)
        {
            var items = "CDBAAA";

            IProcess process = new Process();
            ICostingProvider costingProvider = new CostingProvider();    
                    
            ICheckout checkout = new Checkout(process, costingProvider);

            var totalCost = checkout.Price_Of(items);
        }
    }
}
