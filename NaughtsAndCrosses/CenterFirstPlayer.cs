using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaughtsAndCrosses
{
    class CenterFirstPlayer : RandomPlayer
    {
        public CenterFirstPlayer(string name) : base(name) {}

        public override GameMove MakeMove(GameState gs)
        {
            if (gs.GameBoard[4] == GameSymbol.Blank)
            {
                return new GameMove(4, gs.CurrentSymbol);
            }
            return base.MakeMove(gs);
        }
    }
}
