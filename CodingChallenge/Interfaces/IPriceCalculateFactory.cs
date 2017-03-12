using CodingChallenge.Enumerations;

namespace CodingChallenge.Interfaces
{
    public interface IPriceCalculateFactory
    {
        IPriceCalculate GetPriceCalculation(CostingStrategy costingStrategy);
    }
}
