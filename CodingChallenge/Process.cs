using System.Collections.Generic;

namespace CodingChallenge
{
    public static class Process
    {
        public static Dictionary<char, int> GetCountsForStockItems(string items)
        {
            var codeArray = items.ToUpper().ToCharArray();

            var ItemList = new Dictionary<char, int>();

            foreach (var item in codeArray)
            {
                if (ItemList.ContainsKey(item))
                {
                    ItemList[item] += 1;
                }
                else
                {
                    ItemList.Add(item, 1);
                }
            }

            return ItemList;
        }
    }
}
