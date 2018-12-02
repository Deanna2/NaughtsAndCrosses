using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaughtsAndCrosses
{
    class Program
    {
        static void Main(string[] args)
        {
            var player1 = new CombinedStrategiesPlayer("player1");
            var player2 = new ModifiedAlphaBetaPlayer("player2!");
            GameRunner gameRunner = new GameRunner(player1, player2);
            var results = gameRunner.PlayGame(1000) ;

            Console.WriteLine(results.ToString());
            Console.ReadKey();
            //var player = new SimpleMonteCarloPlayer("Monty");
            //var gs = new GameState();
            //player.PlayerSymbol = GameSymbol.Naught;
            //gs.GameBoard[4] = GameSymbol.Naught;
            //player.GetWins(gs, 50);
        }
    }
}
