using System.Linq;
using System.Collections.Generic;
using CodingChallenge.Interfaces;

namespace CodingChallenge.PriceCalculations
{
    internal class StandardPriceCalculate : IPriceCalculate
    {
        public decimal Price(Dictionary<ICosting, int> standardcostings)
        {
            return standardcostings.Sum(item => item.Key.Cost * item.Value);
        }
    }
}
