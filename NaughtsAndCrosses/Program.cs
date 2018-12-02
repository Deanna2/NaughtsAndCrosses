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
            var player1 = new CombinedStrategiesPlayer("Combined Strategies Player");
            var player2 = new ModifiedMiniMaxPlayer("Modified Minimax Player");
            GameRunner gameRunner = new GameRunner(player1, player2);
            var results = gameRunner.PlayGame(1000) ;

            Console.WriteLine(results.ToString());
            Console.ReadKey();
        }
    }
}
