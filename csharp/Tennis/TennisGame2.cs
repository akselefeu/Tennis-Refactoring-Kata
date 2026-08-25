namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {

        private Player2 player1;
        private Player2 player2;
        

        public TennisGame2(string player1Name, string player2Name)
        {
            player1 = new Player2(player1Name);
            player2 = new Player2(player2Name);
        }

        public string GetScore()
        {
            if (player1.Score == player2.Score && player1.Score < 3)
            {
                return EqualAndNotDeuce(player1.Score);
            }
            if (player1.Score == player2.Score && player1.Score > 2)
                return "Deuce";

            if (player1.Score > 0 && player2.Score == 0 && player1.Score < 4)
            {
                return DetermineScoreNameNormal(player1.Score, player2.Score);
            }
            if (player2.Score > 0 && player1.Score == 0 && player2.Score < 4)
            {
                return DetermineScoreNameNormal(player1.Score, player2.Score);
            }

            if (player1.Score > player2.Score && player1.Score < 4 && player2.Score > 0)
            {
                return DetermineScoreNameNormal(player1.Score, player2.Score);
            }
            if (player2.Score > player1.Score && player2.Score < 4 && player1.Score > 0)
            {
                return DetermineScoreNameNormal(player1.Score, player2.Score);
            }

            if (player1.Score > player2.Score && player2.Score >= 3 && (player1.Score - player2.Score) == 1)
            {
                return $"Advantage {player1.Name}";
            }

            if (player2.Score > player1.Score && player1.Score >= 3 && (player2.Score - player1.Score) == 1)
            {
                return $"Advantage {player2.Name}";
            }

            if (player1.Score >= 4 && (player1.Score - player2.Score) >= 2)
            {
                return $"Win for {player1.Name}";
            }
            if (player2.Score >= 4 && (player2.Score - player1.Score) >= 2)
            {
                return $"Win for {player2.Name}";
            }
            return "";
        }
        

        public void WonPoint(string player)
        {
            if (player == player1.Name)
                player1.AddPoint();
            else if (player == player2.Name)
                player2.AddPoint();
        }

        private static string GetPointName(int point)
        {
            switch (point)
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

        private static string EqualAndNotDeuce(int pPoint)
        {
            string score = GetPointName(pPoint);
            score += "-All";
            return score;
        }

        private static string DetermineScoreNameNormal(int player1score, int player2score)
        {
            string p1Res = "";
            string p2Res = "";

            if (player1score > player2score)
            {
                p1Res = GetPointName(player1score);
                p2Res = GetPointName(player2score);
                string score = p1Res + "-" + p2Res;
                return score; 
            }
            if (player1score < player2score)
            {
                p2Res = GetPointName(player2score);
                p1Res = GetPointName(player1score);
                string score = p1Res + "-" + p2Res;
                return score;
            }

            return "";
        }
    }
    public class Player2
    {
        public string Name { get; }
        public int Score { get; private set; }

        public Player2(string name)
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