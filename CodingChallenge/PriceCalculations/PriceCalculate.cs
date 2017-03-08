using System.Collections.Generic;
using CodingChallenge.Interfaces;

namespace CodingChallenge.PriceCalculations
{
    public abstract class PriceCalculate
    {
        public abstract decimal Price(Dictionary<ICosting, int> costings);
    }
}
