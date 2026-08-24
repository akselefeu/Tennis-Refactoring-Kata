using System;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private readonly Player1 _player1;
        private readonly Player1 _player2;

        public TennisGame1(string player1Name, string player2Name)
        {
            _player1 = new Player1(player1Name);
            _player2 = new Player1(player2Name);
        }

        public void WonPoint(string playerName)
        {
            if (_player1.Name == playerName)
                _player1.AddPoint();
            if (_player2.Name == playerName)
            {
                _player2.AddPoint();
            }
        }

        public string GetScore()
        {
            if (_player1.Score == _player2.Score)
            {
                return GetEqualScore(_player1.Score);
            }
            if (_player1.Score >= 4 || _player2.Score >= 4)
            {
                return GetAdvantageOrWinScore(_player1, _player2);
            }
            
            return GetScoreName(_player1.Score) + "-" + GetScoreName(_player2.Score);
        }

        private static string GetScoreName(int score)
        {
            switch (score)
            {
                case 0:
                    return "Love";
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
                case 3:
                    return "Forty";
                default:
                    throw new ArgumentOutOfRangeException(nameof(score));
            }
        }

        private static string GetEqualScore(int score)
        {
            if (score <= 2)
            {
                return $"{GetScoreName(score)}-All";
            }
            return "Deuce";
        }

        private static string GetAdvantageOrWinScore(Player1 player1, Player1 player2)
        {
            var minusResult = player1.Score - player2.Score;
            if (minusResult == 1) return $"Advantage {player1.Name}";
            if (minusResult == -1) return $"Advantage {player2.Name}";
            if (minusResult >= 2) return $"Win for {player1.Name}";
            return $"Win for {player2.Name}";
        }
    }
    public class Player1
    {
        public string Name { get; }
        public int Score { get; private set; }

        public Player1(string name)
        {
            Name = name;
            Score = 0;
        }

        public void AddPoint()
        {
            Score++;
        }
    }
}

