using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheodorGame
{
    class Item
    {
        public string Name;
        public int Val;
        public string Type;

        public Item(string name, int val, string type)
        {
            Name = name;
            Val = val;
            Type = type;
        }
    }
}
