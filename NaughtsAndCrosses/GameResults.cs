using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaughtsAndCrosses
{
    class GameResults
    {
        public string PlayerName1 { get; set; }
        public string PlayerName2 { get; set; }

        public int PlayerScore1 { get; set; }
        public int PlayerScore2 { get; set; }
        public int Draw { get; set; }

        public GameResults(string playerName1, string playerName2)
        {
            PlayerName1 = playerName1;
            PlayerName2 = playerName2;
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            Draw = 0;
        }

        public override string ToString()
        {
            return $"{PlayerName1}: {PlayerScore1}, {PlayerName2}: {PlayerScore2}, Draws: {Draw}";
        }
    }
}
