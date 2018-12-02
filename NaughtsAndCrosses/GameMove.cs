using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaughtsAndCrosses
{
    class GameMove
    {
        public int Location { get; }
        public GameSymbol GameSymbol { get; }
        
        public GameMove(int location, GameSymbol gameSymbol)
        {
            Location = location;
            GameSymbol = gameSymbol;
        }
    }
}
