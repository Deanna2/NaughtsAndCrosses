using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaughtsAndCrosses
{
    class AggressivePlayer : StrategicPlayer
    {
        public AggressivePlayer(string name) : base(name) { }

        public override GameMove MakeMove(GameState gs)
        {
            var location = base.searchForTwoTogether(gs, gs.CurrentSymbol);
            if (location != -1)
            {
                return new GameMove(location, gs.CurrentSymbol);
            }

            return base.MakeMove(gs);
        }
    }
}
