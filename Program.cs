using System;
using System.Collections.Generic;

namespace TheodorGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var Player = new Player("xx123xx");
            var Monsters = new Monster("Wolf", "Drake", "Fish");
            var Items = new Item("Knife", "Spade", "Shield");
            var _Game = new Game(Player, Monsters, Items);
            
            _Game.Player.ShowStats();
            Console.WriteLine($"Welcome to the game {Player.Name}");
            while (!_Game.GameFinished)
            {
                Console.WriteLine(_Game.HelpCommands);
                var command = Console.ReadLine();
                _Game.GameCommands(command);

            }
            
        }
    }
}
