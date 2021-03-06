using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheodorGame
{
    abstract class Monster
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public double Damage { get; set; }

        public Monster(string name, int level, int hp)
        {
            Name = name;
            Level = level;
            HP = hp;
            Damage = 1 + (0.1 * Level);
        }
    }
}
