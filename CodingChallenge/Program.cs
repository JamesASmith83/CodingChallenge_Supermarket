using System;
using CodingChallenge.Interfaces;
using CodingChallenge.CostingInformation;
using CodingChallenge.PriceCalculations;

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
                IPriceCalculateFactory priceCalculateFactory = new PriceCalculateFactory();
                ICheckout checkout = new Checkout(costingProvider, priceCalculateFactory);

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
