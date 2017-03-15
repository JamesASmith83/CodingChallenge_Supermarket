using System.Collections.Generic;

namespace CodingChallenge.Interfaces
{
    public interface IPriceCalculate
    {
       decimal Price(Dictionary<ICosting, int> costings);
    }
}
