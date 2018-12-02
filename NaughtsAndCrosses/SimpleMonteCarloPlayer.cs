using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaughtsAndCrosses
{
    class SimpleMonteCarloPlayer : Player
    {
        private Player RandomMe { get; }
        private Player SmarterOpponent { get; }
        public GameSymbol PlayerSymbol { get; set; }

        public SimpleMonteCarloPlayer(string name) : base(name) {
            RandomMe = new RandomPlayer("Random");
            SmarterOpponent = new RandomPlayer("Smart");
        }


        public double GetWins(GameState gameState, int repeats)
        {
            var result = PlayerUtilities.GetTerminalState(gameState, PlayerSymbol);
            switch (result) {
                case PlayerUtilities.TerminalState.Win:
                    return repeats;
                case PlayerUtilities.TerminalState.Draw:
                    return 50;
                case PlayerUtilities.TerminalState.Lose:
                    return 0;
            }

            double wins = 0;
            int countWins = 0;
            int countLoss = 0;
            for (int gamesPlayed = 0; gamesPlayed < repeats; gamesPlayed++)
            {
                var gs = gameState.Clone() as GameState;
                var player = SmarterOpponent;
                gs.ApplyMove(player.MakeMove(gs));
                result = PlayerUtilities.GetTerminalState(gs, PlayerSymbol);
                while (result == PlayerUtilities.TerminalState.Incomplete)
                {
                    var gameMove = player.MakeMove(gs);
                    gs.ApplyMove(gameMove);
                    result = PlayerUtilities.GetTerminalState(gs, PlayerSymbol);
                    player = player == SmarterOpponent ? RandomMe : SmarterOpponent;
                }
                if (result == PlayerUtilities.TerminalState.Win)
                {
                    wins += 1;
                    countWins++;
                } else if (result == PlayerUtilities.TerminalState.Draw)
                {
                    wins += 0.5;
                    countLoss++;
                }
                result = PlayerUtilities.TerminalState.Incomplete;
            }

            return wins;
        }

        public override GameMove MakeMove(GameState gameState)
        {
            PlayerSymbol = gameState.CurrentSymbol;
            var moves = gameState.GetMoves();
            var mostWins = 0.0;
            var bestMove = moves.First();
            foreach (var move in moves)
            {
                var gs = gameState.Clone() as GameState;
                gs.ApplyMove(move);
                var wins = GetWins(gs, 3000);
                if (wins > mostWins)
                {
                    mostWins = wins;
                    bestMove = move;
                }
            }
            return bestMove;
        }
    }
}
