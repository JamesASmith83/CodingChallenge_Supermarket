using CodingChallenge.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CodingChallenge
{
    public class CostingProvider : ICostingProvider
    {
        public List<Costing> GetCostingInfo()
        {
            try
            {
                // Simulates getting current costings from external source (API/DB etc...)                
                return JsonConvert.DeserializeObject<List<Costing>>(File.ReadAllText("../../Costings.json"));
            }

            catch (Exception)
            {
                Console.WriteLine("Error retrieving costing information");
                throw;
            }
        }
    }
}
