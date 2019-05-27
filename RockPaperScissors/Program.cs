using System;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = Player.CreatePlayers();
            var score = Game.PlayFullRound(players);
            Console.WriteLine(score);
        }
    }
}
