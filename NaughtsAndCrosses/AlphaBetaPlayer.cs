using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaughtsAndCrosses
{
    class AlphaBetaPlayer : Player
    {
        public AlphaBetaPlayer(string name) : base(name) { }



        private GameSymbol PlayerSymbol { get; set; }
        


        private int GetUtilityOfTerminalState(PlayerUtilities.TerminalState state)
        {
            switch(state)
            {
                case PlayerUtilities.TerminalState.Win:
                    return 1;
                case PlayerUtilities.TerminalState.Draw:
                    return 0;
                case PlayerUtilities.TerminalState.Lose:
                    return -1;
                default:
                    return 0;
            }
        }

        private UtilityGameMove GetMaxUtilityMove(UtilityGameMove originalMove, UtilityGameMove nextMove)
        {
            if (originalMove.Utility >= nextMove.Utility)
            {
                return originalMove;
            }
            return nextMove;
        }

        private UtilityGameMove GetMinUtilityMove(UtilityGameMove originalMove, UtilityGameMove nextMove)
        {
            if (originalMove.Utility <= nextMove.Utility)
            {
                return originalMove;
            }
            return nextMove;
        }

        private class UtilityGameMove
        {
            public int Utility { get; }
            public GameMove GameMove { get; set; }
            public UtilityGameMove(int location, GameSymbol gameSymbol, int utility) {
                Utility = utility;
                GameMove = new GameMove(location, gameSymbol);
            }
        }

        private UtilityGameMove MaxValue(GameState gs, int alpha, int beta, GameMove lastMove = null, int depth = 0)
        {
            //var lastMoveValue = lastMove != null ? $"{lastMove.Location}, ${((lastMove.GameSymbol == GameSymbol.Cross) ? "Cross" : "Naught")}" : "null";
            //Console.WriteLine($"Max value is called. Alpha: {alpha}, Beta: {beta}, lastMove: {lastMoveValue}");
            var terminalState = PlayerUtilities.GetTerminalState(gs, PlayerSymbol);
            if (terminalState != PlayerUtilities.TerminalState.Incomplete)
            {
                if (lastMove == null)
                {
                    throw new Exception("Cannot find best move, in terminal state but with no last move");
                }
                var utilityValue = GetUtilityOfTerminalState(terminalState);
                return new UtilityGameMove(lastMove.Location, lastMove.GameSymbol, utilityValue);
            }

            var moves = gs.GetMoves();
            var v = new UtilityGameMove(moves.First().Location, moves.First().GameSymbol, Int32.MinValue);
            foreach (var move in moves)
            {
                var copiedGameState = gs.Clone() as GameState;
                copiedGameState.ApplyMove(move);
                var u = MinValue(copiedGameState, alpha, beta, move, ++depth);
                v = GetMaxUtilityMove(v, u);
                alpha = Math.Max(alpha, v.Utility);
                if (alpha >= beta)
                {
                    if (lastMove != null)
                    {
                        return new UtilityGameMove(lastMove.Location, lastMove.GameSymbol, v.Utility);
                    }
                    return v;
                }
            }
            if (lastMove != null)
            {
                return new UtilityGameMove(lastMove.Location, lastMove.GameSymbol, v.Utility);
            }
            return v;
        }

        private UtilityGameMove MinValue(GameState gs, int alpha, int beta, GameMove lastMove = null, int depth = 0)
        {
            //var lastMoveValue = lastMove != null ? $"{lastMove.Location}, ${((lastMove.GameSymbol == GameSymbol.Cross) ? "Cross" : "Naught")}" : "null";
            //Console.WriteLine($"Min value is called. Alpha: {alpha}, Beta: {beta}, lastMove: {lastMoveValue}");
            
            var terminalState = PlayerUtilities.GetTerminalState(gs, PlayerSymbol);
            if (terminalState != PlayerUtilities.TerminalState.Incomplete)
            {
                if (lastMove == null)
                {
                    throw new Exception("Cannot find best move, in terminal state but with no last move");
                }
                var utilityValue = GetUtilityOfTerminalState(terminalState);
                return new UtilityGameMove(lastMove.Location, lastMove.GameSymbol, utilityValue);
            }

            var moves = gs.GetMoves();
            var v = new UtilityGameMove(moves.First().Location, moves.First().GameSymbol, Int32.MaxValue);
            foreach (var move in moves)
            {
                var copiedGameState = gs.Clone() as GameState;
                copiedGameState.ApplyMove(move);
                var u = MaxValue(copiedGameState, alpha, beta, move, ++depth);
                v = GetMinUtilityMove(v, u);
                beta = Math.Min(beta, v.Utility);
                if (alpha >= beta)
                {
                    if (lastMove != null)
                    {
                        return new UtilityGameMove(lastMove.Location, lastMove.GameSymbol, v.Utility);
                    }
                    return v;
                }
            }
            if (lastMove != null)
            {
                return new UtilityGameMove(lastMove.Location, lastMove.GameSymbol, v.Utility);
            }
            return v;
        }

        public override GameMove MakeMove(GameState gs)
        {
            PlayerSymbol = gs.CurrentSymbol;
            var move = MaxValue(gs, Int32.MinValue, Int32.MaxValue);
              return new GameMove(move.GameMove.Location, move.GameMove.GameSymbol);
        }
    }
}
