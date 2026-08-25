using System;

namespace Tennis
{
    public class TennisGame5 : ITennisGame
    {
        private readonly Player5 _player1;
        private readonly Player5 _player2;

        public TennisGame5(string player1Name, string player2Name)
        {
            _player1 = new Player5(player1Name);
            _player2 = new Player5(player2Name);
        }

        public void WonPoint(string playerName)
        {
            if (_player1.Name == playerName)
                _player1.AddPoint();
            else if (_player2.Name == playerName)
                _player2.AddPoint();
            else
                throw new ArgumentException("Invalid player name.");
        }

        public string GetScore()
        {
            while (_player1.Score > 4 || _player2.Score > 4)
            {
                _player1.DecreasePoint();
                _player2.DecreasePoint();
            }
            
            if (_player1.Score < 0 || _player2.Score < 0)
                throw new ArgumentException("Invalid score.");

            return ScoreCalculator(_player1, _player2);
        }

        private static string ScoreCalculator(Player5 player1, Player5 player2)
        {
            if (player1.Score == player2.Score)
            {
                return player1.Score >= 3 ? "Deuce" : $"{ScoreName(player1.Score)}-All";
            }
            
            if (Math.Max(player1.Score, player2.Score) < 4)
            {
                return $"{ScoreName(player1.Score)}-{ScoreName(player2.Score)}";
            }
            
            int diff = player1.Score - player2.Score;
            return Math.Abs(diff) == 1
                ? AdvantageScore(player1, player2)
                : WinScore(player1, player2);
        }

        private static string AdvantageScore(Player5 player1, Player5 player2)
        {
            return player1.Score > player2.Score
                ? $"Advantage {player1.Name}"
                : $"Advantage {player2.Name}";
        }

        private static string WinScore(Player5 player1, Player5 player2)
        {
            return player1.Score > player2.Score
                ? $"Win for {player1.Name}"
                : $"Win for {player2.Name}";
        }

        private static string ScoreName(int score)
        {
            return score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => throw new ArgumentException("Invalid score.")
            };
        }
    }

    public class Player5
    {
        public string Name { get; }
        public int Score { get; private set; }

        public Player5(string name)
        {
            Name = name;
            Score = 0;
        }

        public void AddPoint() => Score++;

        public void DecreasePoint() => Score--;
    }
}