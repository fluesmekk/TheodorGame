using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheodorGame
{
    interface IGame
    {
        Player Player { get; set; }
        Monster Monsters { get; set; }
        Item Items { get; set; }

        public bool GameFinished { get; set; }
    
        public void LookForItem();
        public void LookForMonster();

        public void EndGame();


    }
}
