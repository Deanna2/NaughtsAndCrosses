using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaughtsAndCrosses
{
    class DefensivePlayer : StrategicPlayer
    {
        public DefensivePlayer(string name) : base(name) { }

        public override GameMove MakeMove(GameState gs)
        {
            var opponent = gs.CurrentSymbol == GameSymbol.Cross ? GameSymbol.Naught : GameSymbol.Cross;
            var location = base.searchForTwoTogether(gs, opponent);
            if (location != -1)
            {
                return new GameMove(location, gs.CurrentSymbol);
            }

            return base.MakeMove(gs);
        }
    }
}
