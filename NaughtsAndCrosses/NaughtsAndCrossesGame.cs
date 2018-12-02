using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaughtsAndCrosses
{
    public enum MoveResult { Success, Win, Draw, Illegal };

    class NaughtsAndCrossesGame
    {
        private enum GameCompletion { Won, Draw, Incomplete };

        public GameState GameState { get; }

        public NaughtsAndCrossesGame()
        {
            GameState = new GameState();
        }

        public static Tuple<int, int, int>[] ThreeInARow = new Tuple<int, int, int>[8] {
                new Tuple<int, int, int>(0, 1, 2),
                new Tuple<int, int, int>(3, 4, 5),
                new Tuple<int, int, int>(6, 7, 8),
                new Tuple<int, int, int>(0, 3, 6),
                new Tuple<int, int, int>(1, 4, 7),
                new Tuple<int, int, int>(2, 5, 8),
                new Tuple<int, int, int>(0, 4, 8),
                new Tuple<int, int, int>(2, 4, 6)
            };

        private GameCompletion GetGameCompletion()
        {
            foreach (var Row in NaughtsAndCrossesGame.ThreeInARow)
            {
                if (GameState.GameBoard[Row.Item1] != GameSymbol.Blank
                    && GameState.GameBoard[Row.Item1] == GameState.GameBoard[Row.Item2]
                    && GameState.GameBoard[Row.Item2] == GameState.GameBoard[Row.Item3])
                {
                    return GameCompletion.Won;
                }
            }

            Boolean complete = true;
            foreach (GameSymbol gs in GameState.GameBoard)
            {
                if (gs == GameSymbol.Blank)
                {
                    complete = false;
                }
            }
            if (complete)
            {
                return GameCompletion.Draw;
            }
            return GameCompletion.Incomplete;
        }

        public MoveResult ApplyMove(GameMove move)
        {
            if (move.Location >= GameState.GameBoard.Length || GameState.GameBoard[move.Location] != GameSymbol.Blank)
            {
                return MoveResult.Illegal;
            }

            GameState.GameBoard[move.Location] = move.GameSymbol;
            GameState.SwitchSymbol();

            GameCompletion gameCompletion = GetGameCompletion();
            if (gameCompletion == GameCompletion.Won)
            {
                return MoveResult.Win;
            }
            if (gameCompletion == GameCompletion.Draw)
            {
                return MoveResult.Draw;
            }
            return MoveResult.Success;

        }
    }
}
