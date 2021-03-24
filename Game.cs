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
        public Items Items { get; set; }

        public Random r = new Random();

        private Item Item { get; set; }

        private Monster Monster { get; set; }

        public string HelpCommands = "What do you want to do?:\nLook for item (Items)\nLook for monster (Monster)";

        private string YorN = "\n//Yes or No//";
        public bool GameFinished { get; set; }
    

        public Game(Player player, Monsters monsters, Items items)
        {
            Player = player;
            Monsters = monsters;
            Items = items;
            GameFinished = false;
        }

        public void GameCommands(string command)
        {
            if (command=="Stats") Player.ShowStats();
            if (command=="Items") LookForItem();
            if (command=="Monster") LookForMonster();
            if (command=="X") EndGame();
            if (command=="Open inventory") Player.ShowInventory();
            if (command.Contains("Use")) FindItemToUse(command);
        }

        private void FindItemToUse(string command)
        {
            var split = command.Split(" ");
            var item = split[1];
            Console.WriteLine(item);
            for(var i = 0; i < Player.Inventory.Count; i++)
            {
                var item1 = Player.Inventory[i];
                if (item1.Name == item)
                {
                    Player.Use(item1);
                    return;
                }
            }
            Console.WriteLine($"\nCouldn't find item with name{item}");
        }

        public void LookForItem()
        {
            var random = r.Next(0, Items.AllItems.Count);
            Item = Items.AllItems[random];
            ReturnFoundItem(Item);
            ShowItemOptions(Item);
        }

        private void ShowItemOptions(Item item)
        {
            Console.WriteLine($"\nDo you want to pick the {item.Name} up? {YorN}");
            var command = Console.ReadLine();
            if (command == "Yes") PickUp(item);
            else LeaveItem(item);
        }

        private void LeaveItem(Item item)
        {
            Console.WriteLine($"\nYou've left the {item.Name}");
        }

        private void PickUp(Item item)
        {
            Player.Grab(item);
            Console.WriteLine($"\nYou picked up the {item.Name}");
            //Items.AllItems.Remove(item);
        }

        private void ReturnFoundItem(Item Item)
        {
            Console.WriteLine($"\nFound item {Item.Name}");
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
            Console.WriteLine($"\nDo you want to fight the {monster.Name}? {YorN}");
            var command = Console.ReadLine();
            if (command == "Yes") Player.Fight(GameFinished, r, monster);
            else EscapeMonster(monster);
        }

        private void EscapeMonster(Monster monster)
        {
            Console.WriteLine($"\nYou escaped the {monster.Name}.");
        }

        private void ReturnFoundMonster(Monster Monster)
        {
            Console.WriteLine($"\nFound monster {Monster.Name}");
        }

        public void EndGame()
        {
            GameFinished = true;
            Console.WriteLine("\nGame is finished");
            Player.ShowStats();
            Console.ReadLine();
        }

    }
}
