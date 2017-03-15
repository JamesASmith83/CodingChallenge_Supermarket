using System;
using CodingChallenge.Interfaces;
using CodingChallenge.CostingInformation;

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

                ICostingProvider costingProvider = new CostingProvider();
                ICheckout checkout = new Checkout(costingProvider);

                try
                {
                    var totalCost = checkout.GetPriceOfItems(items);
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
