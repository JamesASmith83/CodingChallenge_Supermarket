using System.Collections.Generic;
using CodingChallenge.Interfaces;

namespace CodingChallenge.PriceCalculations
{
    public class MultiBuyPriceCalculate : PriceCalculate
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
}
