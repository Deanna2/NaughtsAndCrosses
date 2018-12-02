using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaughtsAndCrosses
{
    class CombinedStrategiesPlayer : StrategicPlayer
    {
        public CombinedStrategiesPlayer(string name) : base(name) { }

        public override GameMove MakeMove(GameState gs)
        {
            if (gs.GameBoard[4] == GameSymbol.Blank)
            {
                return new GameMove(4, gs.CurrentSymbol);
            }

            var attackLocation = base.searchForTwoTogether(gs, gs.CurrentSymbol);
            if (attackLocation != -1)
            {
                return new GameMove(attackLocation, gs.CurrentSymbol);
            }

            var opponent = gs.CurrentSymbol == GameSymbol.Cross ? GameSymbol.Naught : GameSymbol.Cross;
            var defendLocation = base.searchForTwoTogether(gs, opponent);
            if (defendLocation != -1)
            {
                return new GameMove(defendLocation, gs.CurrentSymbol);
            }

            return base.MakeMove(gs);
        }
    }
}
