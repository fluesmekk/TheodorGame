using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheodorGame
{
    class Player : IPlayer
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public int Mana { get; set; }
        public List<string> Inventory { get; set; }

        public Player(string name)
        {
            Name = name;
            Level = 1;
            HP = 100;
            Mana = 100;
            Inventory = new List<string>();
        }
        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Grab(string item)
        {
            Inventory.Add(item);
        }

        public void Use(string item)
        {
            Inventory.Remove(item);
        }

        public void ShowInventory()
        {
            Console.WriteLine("Inventory: ");
            foreach (var item in Inventory)
            {
                Console.WriteLine(item);
            }
        }

        public void ShowStats()
        {
            var text = $"Name: {Name}\nLevel: {Level}\nHP: {HP}\nMana: {Mana}";
            Console.WriteLine(text);
        }

        public void LevelUp()
        {
            Level++;
            HP = (int)((double)HP * 1.1);
            Mana = (int)((double)Mana * 1.1);
        }
    }
}
