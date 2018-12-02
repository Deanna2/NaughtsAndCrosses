using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaughtsAndCrosses
{
    abstract class StrategicPlayer : RandomPlayer
    {
        public StrategicPlayer(string name) : base(name) { }

        private int twoOutOfThreeSame(GameState gs, GameSymbol symbol, int first, int second, int third)
        {
            if (gs.GameBoard[first] == gs.GameBoard[second] && gs.GameBoard[first] == symbol && gs.GameBoard[third] == GameSymbol.Blank)
            {
                return third;
            }
            if (gs.GameBoard[first] == gs.GameBoard[third] && gs.GameBoard[first] == symbol && gs.GameBoard[second] == GameSymbol.Blank)
            {
                return second;
            }
            if (gs.GameBoard[second] == gs.GameBoard[third] && gs.GameBoard[second] == symbol && gs.GameBoard[first] == GameSymbol.Blank)
            {
                return first;
            }

            return -1;
        }

        protected int searchForTwoTogether(GameState gs, GameSymbol symbol)
        {
            foreach (var row in NaughtsAndCrossesGame.ThreeInARow)
            {
                var result = twoOutOfThreeSame(gs, symbol, row.Item1, row.Item2, row.Item3);
                if (result != -1)
                {
                    return result;
                }
            }
            return -1;
        }
    }
}
