using System.Collections.Generic;

namespace CodingChallenge.Interfaces
{
    public interface IProcess
    {
        Dictionary<char, int> GetCountsForStockItems(string items);
    }
}
