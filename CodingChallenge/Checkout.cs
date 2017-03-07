using CodingChallenge.Enumerations;
using CodingChallenge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge
{
    public class Checkout : ICheckout
    {
        private List<Costing> costings;
        private readonly IProcess process;
        private readonly ICostingProvider costingProvider;

        public Checkout(IProcess process, ICostingProvider costingProvider)
        {
            this.process = process;
            this.costingProvider = costingProvider;
        }

        public decimal Price_Of(string items)
        {
            costings = GetCostingInfo();
            var sortedItems = SortItems(items);
            ValidateInput(costings, sortedItems);
            return Calculate(sortedItems);
        }

        private Dictionary<char, int> SortItems(string unsortedItems)
        {
            return process.Sort(unsortedItems);
        }

        private List<Costing> GetCostingInfo()
        {
            return costingProvider.GetCostingInfo();
        }

        private decimal Calculate(Dictionary<char, int> sortedItems)
        {
            var multiBuyItems = new Dictionary<ICosting, int>();
            var standardItems = new Dictionary<ICosting, int>();

            var standardPriceCalculate = PriceCalculate.GetPriceCalculation(CostingStrategy.Standard);
            var multiBuyPriceCalculate = PriceCalculate.GetPriceCalculation(CostingStrategy.MultiBuy);

            foreach (var item in sortedItems)
            {
                var itemInfo = costings.FirstOrDefault(x => x.Product == item.Key);

                if (itemInfo != null && itemInfo.Offer != null)
                {
                    multiBuyItems.Add(itemInfo, item.Value);
                }
                else
                {
                    standardItems.Add(itemInfo, item.Value);
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
