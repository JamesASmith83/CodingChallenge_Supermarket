using CodingChallenge.CostingInformation;
using System.Collections.Generic;

namespace CodingChallenge.Interfaces
{
    public interface ICostingProvider
    {
        List<Costing> GetCostingInfo();
    }
}
