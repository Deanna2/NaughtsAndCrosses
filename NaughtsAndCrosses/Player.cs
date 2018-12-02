using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaughtsAndCrosses
{
    abstract class Player
    {
        public abstract GameMove MakeMove(GameState gameState);
        public string Name { get; set; }

        public Player(string name)
        {
            Name = name;
        }
    }
}
