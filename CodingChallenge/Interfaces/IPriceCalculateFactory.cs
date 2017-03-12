using CodingChallenge.Enumerations;
using CodingChallenge.PriceCalculations;

namespace CodingChallenge.Interfaces
{
    public interface IPriceCalculateFactory
    {
        IPriceCalculate GetPriceCalculation(CostingStrategy costingStrategy);
    }
}
