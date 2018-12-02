using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaughtsAndCrosses
{
    public enum GameSymbol { Naught, Cross, Blank };

    class GameState : ICloneable
    {
        public GameSymbol[] GameBoard {get; set;}
        public GameSymbol CurrentSymbol { get; set; }

        public GameState()
        {
            GameBoard = new GameSymbol[] {
                GameSymbol.Blank,
                GameSymbol.Blank,
                GameSymbol.Blank,
                GameSymbol.Blank,
                GameSymbol.Blank,
                GameSymbol.Blank,
                GameSymbol.Blank,
                GameSymbol.Blank,
                GameSymbol.Blank
            };

            CurrentSymbol = GameSymbol.Naught;
        }

        public void SwitchSymbol()
        {
            if (CurrentSymbol == GameSymbol.Naught)
            {
                CurrentSymbol = GameSymbol.Cross;
            }
            else
            {
                CurrentSymbol = GameSymbol.Naught;
            }
        }

        public void ApplyMove(GameMove move)
        {
            GameBoard[move.Location] = move.GameSymbol;
            SwitchSymbol();
        }

        public List<GameMove> GetMoves()
        {
            List<GameMove> moves = new List<GameMove>();
            for (int i = 0; i < GameBoard.Length; i++)
            {
                if (GameBoard[i] == GameSymbol.Blank)
                {
                    moves.Add(new GameMove(i, CurrentSymbol));
                }
            }
            return moves;
        }

        public object Clone()
        {
            var gameState = new GameState();
            gameState.CurrentSymbol = CurrentSymbol;
            gameState.GameBoard = GameBoard.Clone() as GameSymbol[];
            return gameState;
        }
    }
}
