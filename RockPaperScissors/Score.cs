using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockPaperScissors
{
    class Score
    {
        private readonly Dictionary<string, int> _points = new Dictionary<string, int>();

        public void Add(string name, int points)
        {
            if (!_points.ContainsKey(name)) _points.Add(name, 0);
            _points[name] += points;
        }

        public override string ToString()
        {
            var txt = new StringBuilder();
            foreach (KeyValuePair<string, int> score in _points.OrderByDescending(key => key.Value))
            {
                txt.AppendLine(score.Key + " " + score.Value.ToString().PadLeft(5));
            }
            return txt.ToString();
        }
    }
}
