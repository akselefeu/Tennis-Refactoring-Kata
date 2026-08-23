using System;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            if (m_score1 == m_score2)
            {
                return GetEqualScore(m_score1);
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                return GetAdvantageOrWinScore(m_score1, m_score2);
            }
            else
            {
                return GetScoreName(m_score1) + "-" + GetScoreName(m_score2);
            }
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
            switch (score)
            {
                case 0:
                    return "Love-All";
                case 1:
                    return "Fifteen-All";
                case 2:
                    return "Thirty-All";
                case 3:
                    return "Deuce";
                default:
                    return "Deuce";
            }
        }

        private static string GetAdvantageOrWinScore(int score1, int score2)
        {
            var minusResult = score1 - score2;
            if (minusResult == 1) return "Advantage player1";
            else if (minusResult == -1) return "Advantage player2";
            else if (minusResult >= 2) return "Win for player1";
            return "Win for player2";       
        }
    }
}

