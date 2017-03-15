using CodingChallenge.Interfaces;
using Microsoft.Practices.Unity;

namespace CodingChallenge.PriceCalculations
{
    public static class PriceCalculateFactory
    {
        private static IUnityContainer priceCalculations = null;

        public static IPriceCalculate GetPriceCalculation(string costingStrategy)
        {
            if (priceCalculations == null)
            {
                priceCalculations = new UnityContainer();
                priceCalculations.RegisterType<IPriceCalculate, StandardPriceCalculate>("Standard");
                priceCalculations.RegisterType<IPriceCalculate, MultiBuyPriceCalculate>("MultiBuy");
            }

            return priceCalculations.Resolve<IPriceCalculate>(costingStrategy);
        }
    }
}
