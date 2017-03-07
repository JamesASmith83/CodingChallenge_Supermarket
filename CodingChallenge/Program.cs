using CodingChallenge.Interfaces;
using System;

namespace CodingChallenge
{
    public class Program
    {
        public Program(ICheckout checkout)
        {
        }


        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter some SKUs");
            var readLine = Console.ReadLine();
            if (readLine != null)
            {
                var items = readLine.ToUpper().Trim();

                IProcess process = new Process();
                ICostingProvider costingProvider = new CostingProvider();
                ICheckout checkout = new Checkout(process, costingProvider);

                try
                {
                    var totalCost = checkout.Price_Of(items);
                    Console.WriteLine("Total Cost: " + totalCost);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
