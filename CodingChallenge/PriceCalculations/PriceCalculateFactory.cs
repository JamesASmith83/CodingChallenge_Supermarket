using System;
using CodingChallenge.Enumerations;

namespace CodingChallenge.PriceCalculations
{
    public class PriceCalculateFactory
    {
        public static PriceCalculate GetPriceCalculation(CostingStrategy costingStrategy)
        {
            switch (costingStrategy)
            {
                case CostingStrategy.Standard: return new StandardPriceCalculate();
                case CostingStrategy.MultiBuy: return new MultiBuyPriceCalculate();
            }

            throw new Exception("Error instantiating costing strategy");
        }
    }
}
