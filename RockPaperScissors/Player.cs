using System;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissors
{
    class Player
    {
        public string Name { get; }
        private readonly Random _random;


        public Player(int n)
        {
            _random = new Random();
            Name = (GetType().Name + " " + n).PadRight(14);
        }

        public static List<Player> CreatePlayers()
        {
            var players = new List<Player>();
            players.AddRange(Enumerable.Range(1, 10).Select(n => new Player(n)));
            return players;
        }

        public Gesture GetGesture()
        {
            return (Gesture) _random.Next(3);
        }
    }
}
