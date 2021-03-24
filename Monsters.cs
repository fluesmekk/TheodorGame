using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheodorGame
{
    class Monsters
    {
        public List<Monster> AllMonsters { get; set; }

        public Monsters(params Monster[] Monstere)
        {
            AllMonsters = new List<Monster>(Monstere);
        }
    }
}
