using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheodorGame
{
    class Game
    {
        public Player Player { get; set; }
        public Monsters Monsters { get; set; }
        public Item Items { get; set; }

        public Random r = new Random();

        private string Item { get; set; }

        private Monster Monster { get; set; }

        public string HelpCommands = "What do you want to do?:\n Look for item\nLook for monster";

        private string YorN = "\n//Yes or No//";
        public bool GameFinished { get; set; }
    

        public Game(Player player, Monsters monsters, Item items)
        {
            Player = player;
            Monsters = monsters;
            Items = items;
            GameFinished = false;
        }

        public void GameCommands(string command)
        {
            if (command=="Stats") Player.ShowStats();
            if (command.Contains("Look for items")) LookForItem();
            if (command=="Look for monster") LookForMonster();
            if (command=="X") EndGame();
        }

        public void LookForItem()
        {
            var random = r.Next(0, Items.AllItems.Count);
            Item = Items.AllItems[random];
            ReturnFoundItem(Item);
            ShowItemOptions(Item);

        }

        private void ShowItemOptions(string item)
        {
            Console.WriteLine($"Do you want to pick the {item} up? {YorN}");
            var command = Console.ReadLine();
            if (command == "Yes") PickUp(item);
            else LeaveItem(item);
        }

        private void LeaveItem(string item)
        {
            Console.WriteLine($"You've left the {item}");
        }

        private void PickUp(string item)
        {
            Player.Grab(item);
            Console.WriteLine($"You picked up the {item}");
            Items.AllItems.Remove(item);
        }

        private void ReturnFoundItem(string Item)
        {
            Console.WriteLine($"Found item {Item}");
        }

        public void LookForMonster()
        {
            var random = r.Next(0, Monsters.AllMonsters.Count);
            Monster = Monsters.AllMonsters[random];
            ReturnFoundMonster(Monster);
            ShowMonsterOptions(Monster);
        }

        private void ShowMonsterOptions(Monster monster)
        {
            Console.WriteLine($"Do you want to fight the {monster}? {YorN}");
            var command = Console.ReadLine();
            if (command == "Yes") Player.Fight(GameFinished, r, monster);
            else EscapeMonster(monster);
        }

        private void EscapeMonster(Monster monster)
        {
            Console.WriteLine($"You escaped the {monster.Name}.");
        }

        private void ReturnFoundMonster(Monster Monster)
        {
            Console.WriteLine($"Found monster {Monster.Name}");
        }

        public void EndGame()
        {
            GameFinished = true;
            Console.WriteLine("Game is finished");
            Player.ShowStats();
            Console.ReadLine();
        }

    }
}
