using System;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private Player3 player1;
        private Player3 player2;

        public TennisGame3(string player1Name, string player2Name)
        {
            player1 = new Player3(player1Name);
            player2 = new Player3(player2Name);
        }

        public string GetScore()
        {
            if ((player1.Score < 4 && player2.Score < 4) && (player1.Score + player2.Score < 6)) 
            {
                return (player1.Score == player2.Score) ? GetScoreName(player1.Score) + "-All" : GetScoreName(player1.Score) + "-" + GetScoreName(player2.Score);
            }

            if (player1.Score == player2.Score)
            {
                return "Deuce";
            }

            return AdvantageOrWin(player1, player2);
        }

        public void WonPoint(string playerName)
        {
            if (player1.Name == playerName)
                player1.AddPoint();
            else if (player2.Name == playerName)
                player2.AddPoint();
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
                    return "";
            }
        }
        private static string AdvantageOrWin(Player3 player1, Player3 player2)
        {
            string s = player1.Score > player2.Score ? player1.Name : player2.Name;
            return Math.Abs(player1.Score - player2.Score) == 1 ? "Advantage " + s : "Win for " + s;
        }
        
        

    }
    public class Player3
    {
        public string Name { get; }
        public int Score { get; private set; }

        public Player3(string name)
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