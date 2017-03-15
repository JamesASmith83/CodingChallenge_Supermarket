using System;
using System.Collections.Generic;
using System.Linq;
using CodingChallenge.Interfaces;
using CodingChallenge.CostingInformation;
using CodingChallenge.Helpers;
using CodingChallenge.PriceCalculations;

namespace CodingChallenge
{
    public class Checkout : ICheckout
    {
        private List<Costing> costings;
        private readonly ICostingProvider costingProvider;
        
        public Checkout(ICostingProvider costingProvider)
        {
            this.costingProvider = costingProvider;
        }

        public decimal GetPriceOfItems(string items)
        {
            costings = GetCostingInfo();
            var sortedItems = GetCountsForStockItems(items);
            ValidateInput(costings, sortedItems);
            return Calculate(sortedItems);
        }

        private Dictionary<char, int> GetCountsForStockItems(string unsortedItems)
        {
            return Process.GetCountsForStockItems(unsortedItems);
        }

        private List<Costing> GetCostingInfo()
        {
            return costingProvider.GetCostingInfo();
        }

        private decimal Calculate(Dictionary<char, int> sortedItems)
        {
            var multiBuyItems = new Dictionary<ICosting, int>();
            var standardItems = new Dictionary<ICosting, int>();

            var standardPriceCalculate = PriceCalculateFactory.GetPriceCalculation("Standard");
            var multiBuyPriceCalculate = PriceCalculateFactory.GetPriceCalculation("MultiBuy");

            foreach (var item in sortedItems)
            {
                var itemInfo = costings.FirstOrDefault(x => x.Product == item.Key);

                if (itemInfo != null && itemInfo.Offer != null)
                {
                    multiBuyItems.Add(itemInfo, item.Value);
                }
                else
                {
                    if (itemInfo != null)
                    {
                        standardItems.Add(itemInfo, item.Value);
                    }
                    else
                    {
                        throw new ArgumentException("Error calculating items");
                    }
                }
            }

            return multiBuyPriceCalculate.Price(multiBuyItems) + standardPriceCalculate.Price(standardItems);
        }

        private void ValidateInput(IEnumerable<Costing> costingInfo, Dictionary<char, int> items)
        {
            var validProducts = costingInfo.Where(s => items.Keys.Any(k => k == s.Product)).ToList();

            if (validProducts.Count != items.Count)
            {
                throw new ArgumentException("There is missing pricing information for one or more items");
            }
        }
    }
}
