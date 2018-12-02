using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaughtsAndCrosses
{
    class PlayerUtilities
    {
        public enum TerminalState { Win, Lose, Draw, Incomplete };

        public static TerminalState GetTerminalState(GameState gs, GameSymbol gameSymbol)
        {
            foreach (var Row in NaughtsAndCrossesGame.ThreeInARow)
            {
                if (gs.GameBoard[Row.Item1] != GameSymbol.Blank
                    && gs.GameBoard[Row.Item1] == gs.GameBoard[Row.Item2]
                    && gs.GameBoard[Row.Item2] == gs.GameBoard[Row.Item3])
                {
                    if (gs.GameBoard[Row.Item1] == gameSymbol)
                    {
                        return TerminalState.Win;
                    }
                    else
                    {
                        return TerminalState.Lose;
                    }
                }
            }

            Boolean complete = true;
            foreach (GameSymbol s in gs.GameBoard)
            {
                if (s == GameSymbol.Blank)
                {
                    complete = false;
                }
            }
            if (complete)
            {
                return TerminalState.Draw;
            }
            return TerminalState.Incomplete;
        }
    }
}
