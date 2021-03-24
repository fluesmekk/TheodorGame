using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheodorGame
{
    class CommandHandler
    {
        private Game _game { get; set; }

        public CommandHandler(Game game)
        {
            _game = game;
        }
        public void HandleCommand(string command)
        {
            if (command == "Look for item") _game.LookForItem();
            if (command == "Look for monster") _game.LookForMonster();
        }
    }
}
