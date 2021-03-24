using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheodorGame
{
    class Monster
    {
        public List<string> AllMonsters { get; set; }

        public Monster(params string[] Monstere)
        {
            AllMonsters = new List<string>(Monstere);
        }
    }
}
