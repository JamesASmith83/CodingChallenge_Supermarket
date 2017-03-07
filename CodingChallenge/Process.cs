using CodingChallenge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge
{
    public class Process : IProcess
    {
        protected Dictionary<char, int> ItemList;

        public Dictionary<char, int> Sort(string items)
        {
            var codeArray = items.ToUpper().ToCharArray();

            ItemList = new Dictionary<char, int>();

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
