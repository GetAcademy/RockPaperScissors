using System;
using System.Collections.Generic;

namespace RockPaperScissors
{
    class Game
    {
        private static bool _debug = true;
        private readonly Score _score;

        public Game(List<Player> players)
        {
            _score = new Score();
            foreach (var player1 in players)
                foreach (var player2 in players)
                    if (player1 != player2)
                        Play(player1, player2);
        }

        private void Play(Player player1, Player player2)
        {
            Gesture gesture1 = 0, gesture2 = 0;
            while (gesture1 == gesture2)
            {
                if (_debug)
                {
                    Console.WriteLine($"Uavgjort:         {gesture1.ToString()} vs {gesture2.ToString()}");
                }
                gesture1 = player1.GetGesture();
                gesture2 = player2.GetGesture();
                _score.Add(player1.Name, 1);
                _score.Add(player2.Name, 1);
            }

            var winnerIsPlayer1 = WinnerIsPlayer1(gesture1, gesture2);
            var name = winnerIsPlayer1 ? player1.Name : player2.Name;
            _score.Add(name, 2);
            var no = winnerIsPlayer1 ? "1" : "2";
            if (_debug)
            {
                Console.WriteLine($"Spiller {no} vinner: {gesture1.ToString()} vs {gesture2.ToString()}");
            }
        }

        private bool WinnerIsPlayer1(Gesture gesture1, Gesture gesture2)
        {
            return gesture1 == Gesture.Paper && gesture2 == Gesture.Rock
                || gesture1 == Gesture.Rock && gesture2 == Gesture.Scissors
                || gesture1 == Gesture.Scissors && gesture2 == Gesture.Paper;
        }

        public static Score PlayFullRound(List<Player> players)
        {
            var game = new Game(players);
            return game._score;
        }
    }
}
