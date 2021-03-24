using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheodorGame
{
    class Items
    {
        public List<Item> AllItems { get; set; }

        public Items(params Item[] items)
        {
            AllItems = new List<Item>(items);
        }
    }
}
