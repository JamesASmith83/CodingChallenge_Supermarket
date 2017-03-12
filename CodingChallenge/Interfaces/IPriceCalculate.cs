using System.Collections.Generic;
using CodingChallenge.Interfaces;

namespace CodingChallenge.Interfaces
{
    public interface IPriceCalculate
    {
       decimal Price(Dictionary<ICosting, int> costings);
    }
}
