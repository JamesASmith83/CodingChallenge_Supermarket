using CodingChallenge.Enumerations;
using CodingChallenge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge
{
    public abstract class PriceCalculate
    {
        public abstract decimal Price(Dictionary<ICosting, int> costings);

        private class StandardPriceCalculate : PriceCalculate
        {
            public override decimal Price(Dictionary<ICosting, int> standardcostings)
            {
                return standardcostings.Sum(item => item.Key.Cost * item.Value);
            }
        }

        private class MultiBuyPriceCalculate : PriceCalculate
        {
            public override decimal Price(Dictionary<ICosting, int> multiBuyCostings)
            {
                decimal multiBuyPrice = 0;
                decimal totalMultiBuyPrice = 0;

                foreach (var item in multiBuyCostings)
                {
                    if (item.Key.Offer != null)
                    {
                        int offerEligable = item.Value / item.Key.Offer.Quantity;

                        if (offerEligable > 0)
                        {
                            multiBuyPrice = offerEligable * item.Key.Offer.OfferCost;
                        }

                        int remainder = item.Value % item.Key.Offer.Quantity;
                        decimal remainderPrice = remainder * item.Key.Cost;

                        totalMultiBuyPrice += multiBuyPrice + remainderPrice;
                    }
                }

                return totalMultiBuyPrice;
            }
        }

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
