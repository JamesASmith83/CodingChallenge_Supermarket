﻿using System.Linq;
using System.Collections.Generic;
using CodingChallenge.Interfaces;

namespace CodingChallenge.PriceCalculations
{
    public class StandardPriceCalculate : PriceCalculate
    {
        public override decimal Price(Dictionary<ICosting, int> standardcostings)
        {
            return standardcostings.Sum(item => item.Key.Cost * item.Value);
        }
    }
}
