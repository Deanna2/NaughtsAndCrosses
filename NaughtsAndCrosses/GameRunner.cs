using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaughtsAndCrosses
{
    class GameRunner
    {
        Player Player1 { get; }
        Player Player2 { get; }
        bool AlternateFirstMove { get; }
        public GameRunner(Player player1, Player player2, bool alternateFirstMove = true )
        {
            Player1 = player1;
            Player2 = player2;
            AlternateFirstMove = alternateFirstMove;
        }

        public GameResults PlayGame(int games)
        {
            GameResults results = new GameResults(Player1.Name, Player2.Name);
            Player playerToMoveFirst = Player1;
            for (int index = 0; index < games; index++)
            {
                NaughtsAndCrossesGame game = new NaughtsAndCrossesGame();
                Player currentPlayer = playerToMoveFirst;
                GameMove nextMove = currentPlayer.MakeMove(game.GameState);
                MoveResult moveResult = game.ApplyMove(nextMove);
                while (moveResult == MoveResult.Success)
                {
                    // Switch player
                    currentPlayer = currentPlayer == Player1 ? Player2 : Player1;
                    nextMove = currentPlayer.MakeMove(game.GameState);
                    moveResult = game.ApplyMove(nextMove);
                }
                if (moveResult == MoveResult.Win)
                {
                    if (currentPlayer == Player1)
                    {
                        results.PlayerScore1++;
                    } else
                    {
                        results.PlayerScore2++;
                    }
                }

                if (moveResult == MoveResult.Draw)
                {
                    results.Draw++;
                }
                if (moveResult == MoveResult.Illegal)
                {
                    throw new Exception($"An illegal move was made by {currentPlayer.Name}");
                }

                if (AlternateFirstMove)
                {
                    playerToMoveFirst = playerToMoveFirst == Player1 ? Player2 : Player1;
                }
            }
            return results;
        }
    }
}
