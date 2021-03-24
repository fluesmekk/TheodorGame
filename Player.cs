using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public double Damage { get; set; }
        public int RevivesLeft { get; set; }
        public List<Item> Inventory { get; set; }

        public Player()
        { 
            Level = 1;
            HP = 100;
            maxHP = 100;
            Mana = 100;
            Damage = 1.0;
            Inventory = new List<Item>();
            RevivesLeft = 10;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void Grab(Item item)
        {
            Inventory.Add(item);
        }

        public void Use(Item item)
        {
            CheckItemType(item);
            Inventory.Remove(item);
        }

        public void CheckItemType(Item item)
        {
            var type = item.Type;
            if (type == "Potion") Potion(item);
            if (type == "SuperPotion") SuperPotion(item);
        }

        private void SuperPotion(Item item)
        {
            var maxHPBefore = maxHP;
            maxHP += item.Val;
            Console.WriteLine($"Increased Max HP by {maxHP-maxHPBefore}");
        }

        private void Potion(Item item)
        {
            var HPBefore = HP;
            HP += item.Val;
            Console.WriteLine($"{Name} got {HP - HPBefore} HP using {item.Name}");
        }

        public void ShowInventory()
        {
            Console.WriteLine("Inventory: ");
            foreach (var item in Inventory)
            {
                Console.WriteLine($"{item.Name} Type: {item.Type}");

            }
        }

        public void ShowStats()
        {
            var text = $"Name: {Name}\nLevel: {Level}\nHP: {HP}\nDamage Multiplier: {Damage}\nMana: {Mana}\nRevives: {RevivesLeft}";
            Console.WriteLine(text);
        }

        public void LevelUp()
        {
            Level++;
            maxHP = (int)((double)maxHP * 1.1);
            Mana = (int)((double)Mana * 1.1);
            Damage += 0.1;
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
            var dmg1 = r.Next(0, 30) * monster.Damage;
            var dmg2 = r.Next(0, 30) * Damage;
            monsterHP -= (int)dmg2;
            DisplayAttack("Monster", "Player", monsterHP);
            if (monsterHP <= 0)
            {
                Console.WriteLine($"{Name} won! Well done!");
                LevelUp();
                HP = maxHP;
                ShowStats();
                return true;
            }
            HP -= (int)dmg1;
            DisplayAttack("Player", "Monster", HP);
            if (HP <= 0)
            {
                Console.WriteLine($"{monster.Name} won! better luck next time.");
                Revive(game);
                return true;
            }
            return false;
        }

        private void DisplayAttack(string defending, string attacking, int remainingHealth)
        {
            var health = remainingHealth;
            if (remainingHealth < 0) health = 0;
            Console.WriteLine($"{defending} gets hit by {attacking} and has {health} left");
        }

        private void Revive(bool game)
        {
            if (RevivesLeft == 0)
            {
                Console.WriteLine("You lost the game!"); game = false;
            }
            else CheckRevive();
        }

        private void CheckRevive()
        {
            Console.WriteLine("Do you want to continue?\n//Yes or No//");
            var command = Console.ReadLine();
            if (command == "Yes")
            {
                RevivesLeft--;
                Console.WriteLine("You have been revived");
                HP = maxHP;
            }
        }
    }
}
