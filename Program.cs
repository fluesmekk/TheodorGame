using System;
using System.Collections.Generic;

namespace TheodorGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var Player = new Player();
            var Monsters = new Monsters(new Wolf(), new Drake(), new Fish());
            var Items = new Items(new Item("Healthpotion", 50, "Potion"),new Item("SuperPotion", 50, "SuperPotion") );
            var _Game = new Game(Player, Monsters, Items);

            Console.WriteLine("Enter your name...");
            var Name = Console.ReadLine();
            _Game.Player.SetName(Name);
            Console.Clear();

            _Game.Player.ShowStats();
            Console.WriteLine($"Welcome to the game {Player.Name}");

            while (!_Game.GameFinished)
            {
                Console.WriteLine();
                Console.WriteLine(_Game.HelpCommands);
                var command = Console.ReadLine();
                _Game.GameCommands(command);

            }
            
        }
    }
}
