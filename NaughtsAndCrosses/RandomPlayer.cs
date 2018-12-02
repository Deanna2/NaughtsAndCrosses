using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaughtsAndCrosses
{
    class RandomPlayer : Player
    {
        private Random Random { get;}

        public RandomPlayer(string name) : base(name)
        {
            Random = new Random();
        }

        public override GameMove MakeMove(GameState gameState)
        {
            var moves = gameState.GetMoves();
            int numberOfMoves = moves.Count;
            int moveIndex = Random.Next(numberOfMoves);
            return moves[moveIndex];
        }
    }
}
