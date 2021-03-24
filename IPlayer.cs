using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheodorGame
{
    interface IPlayer
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public int Mana { get; set; }
        public List<string> Inventory { get; set; }
        public void Move();
        public void Grab(string item);
        public void Use(string item);
        public void ShowInventory();
        public void ShowStats();
        public void LevelUp();
    }
}
