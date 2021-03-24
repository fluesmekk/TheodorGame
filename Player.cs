using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheodorGame
{
    class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public int maxHP { get; set; }
        public int Mana { get; set; }
        public int RevivesLeft { get; set; }
        public List<string> Inventory { get; set; }

        public Player(string name)
        {
            Name = name;
            Level = 1;
            HP = 100;
            maxHP = 100;
            Mana = 100;
            Inventory = new List<string>();
            RevivesLeft = 10;
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
            maxHP = (int)((double)HP * 1.1);
            Mana = (int)((double)Mana * 1.1);
        }

        public void Fight(bool game, Random r, Monster monster)
        {
            var monsterHP = monster.HP;

            while (HP > 0 || monsterHP > 0)
            {
                if (CalculateFight(game, r, monster, ref monsterHP)) break;
            }
        }

        private bool CalculateFight(bool game, Random r, Monster monster, ref int monsterHP)
        {
            var dmg1 = r.Next(0, 20);
            var dmg2 = r.Next(0, 20);
            monsterHP -= dmg2;
            if (monsterHP <= 0)
            {
                Console.WriteLine($"{Name} won! Well done!");
                LevelUp();
                HP = maxHP;
                return true;
            }
            HP -= dmg1;
            if (HP <= 0)
            {
                Console.WriteLine($"{monster.Name} won! better luck next time.");
                return true;
            }
            return false;
        }

        private void Revive(bool game)
        {
            if (RevivesLeft == 0)
            {
                Console.WriteLine("You lost the game!");
                game = false;
            }

        }
    }
}
