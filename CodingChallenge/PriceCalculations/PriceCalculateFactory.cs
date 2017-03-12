using System;
using CodingChallenge.Enumerations;
using CodingChallenge.Interfaces;

namespace CodingChallenge.PriceCalculations
{
    public class PriceCalculateFactory : IPriceCalculateFactory
    {
        public IPriceCalculate GetPriceCalculation(CostingStrategy costingStrategy)
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
