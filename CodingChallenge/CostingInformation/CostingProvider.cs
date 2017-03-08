using System.Collections.Generic;
using System.IO;
using CodingChallenge.Interfaces;
using Newtonsoft.Json;

namespace CodingChallenge.CostingInformation
{
    public class CostingProvider : ICostingProvider
    {
        public List<Costing> GetCostingInfo()
        {
            // Simulates getting current costings from external source (API/DB etc...)                
            return JsonConvert.DeserializeObject<List<Costing>>(File.ReadAllText("../../Costings.json"));
        }
    }
}
