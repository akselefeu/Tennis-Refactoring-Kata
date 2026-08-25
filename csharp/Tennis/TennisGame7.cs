namespace Tennis;

public class TennisGame7 : ITennisGame
{
    private int player1Score;
    private int player2Score;
    private string player1Name;
    private string player2Name;

    public TennisGame7(string player1Name, string player2Name)
    {
        this.player1Name = player1Name;
        this.player2Name = player2Name;
    }

    public void WonPoint(string playerName)
    {
        if (playerName == player1Name)
            player1Score++;
        else
            player2Score++;
    }

    public string GetScore()
    {
        string result = "Current score: ";

        if (player1Score == player2Score)
        {
            // tie score
            switch (player1Score)
            {
                case 0:
                    result += "Love-All";
                    break;
                case 1:
                    result += "Fifteen-All";
                    break;
                case 2:
                    result += "Thirty-All";
                    break;
                default:
                    result += "Deuce";
                    break;
            }
        }
        else if (player1Score >= 4 || player2Score >= 4)
        {
            // end-game score
            switch (player1Score - player2Score)
            {
                case 1:
                    result += $"Advantage {player1Name}";
                    break;
                case -1:
                    result += $"Advantage {player2Name}";
                    break;
                case >= 2:
                    result += $"Win for {player1Name}";
                    break;
                default:
                    result += $"Win for {player2Name}";
                    break;
            }
        }
        else
        {
            // regular score
            result += player1Score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                _ => "Forty"
            };

            result += "-";

            result += player2Score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                _ => "Forty"
            };
        }

        return result + ", enjoy your game!";
    }
}

public class Player7
{
    public string Name { get; }
    public int Score { get; private set; }

    public Player7(string name)
    {
        Name = name;
        Score = 0;
    }

    public void AddPoint()
    {
        Score++;
    }
}