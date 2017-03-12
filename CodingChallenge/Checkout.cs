using System;
using System.Collections.Generic;
using System.Linq;
using CodingChallenge.Enumerations;
using CodingChallenge.Interfaces;
using CodingChallenge.CostingInformation;

namespace CodingChallenge
{
    public class Checkout : ICheckout
    {
        private List<Costing> costings;
        private readonly ICostingProvider costingProvider;
        private readonly IPriceCalculateFactory priceCalculateFactory;
        
        public Checkout(ICostingProvider costingProvider, IPriceCalculateFactory priceCalculateFactory)
        {
            this.costingProvider = costingProvider;
            this.priceCalculateFactory = priceCalculateFactory;
        }

        public decimal GetPriceOfItems(string items)
        {
            costings = GetCostingInfo();
            var sortedItems = SortItems(items);
            ValidateInput(costings, sortedItems);
            return Calculate(sortedItems);
        }

        private Dictionary<char, int> SortItems(string unsortedItems)
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

            var standardPriceCalculate = priceCalculateFactory.GetPriceCalculation(CostingStrategy.Standard);
            var multiBuyPriceCalculate = priceCalculateFactory.GetPriceCalculation(CostingStrategy.MultiBuy);

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
