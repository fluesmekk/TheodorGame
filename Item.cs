using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheodorGame
{
    class Item
    {
        public List<string> AllItems { get; set; }

        public Item(params string[] items)
        {
            AllItems = new List<string>(items);
        }
    }
}
