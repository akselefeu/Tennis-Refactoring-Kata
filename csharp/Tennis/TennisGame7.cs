namespace Tennis;

public class TennisGame7 : ITennisGame
{
    private Player7 _player1;
    private Player7 _player2;

    public TennisGame7(string player1Name, string player2Name)
    {
        _player1 = new Player7(player1Name);
        _player2 = new Player7(player2Name);
    }

    public void WonPoint(string playerName)
    {
        if (_player1.Name == playerName)
            _player1.AddPoint();
        else if (_player2.Name == playerName)
            _player2.AddPoint();
    }

    public string GetScore()
    {
        string result = "Current score: ";

        if (_player1.Score == _player2.Score)
        {
            result += TieGame(_player1, _player2);
        }
        else if (_player1.Score >= 4 || _player2.Score >= 4)
        {
            // end-game score
            result += EndGameScore(_player1, _player2);
        }
        else
        {
            // regular score
            result += _player1.Score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                _ => "Forty"
            };

            result += "-";

            result += _player2.Score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                _ => "Forty"
            };
        }

        return result + ", enjoy your game!";
    }

    private static string EndGameScore(Player7 player1, Player7 player2)
    {
        switch (player1.Score - player2.Score)
        {
            case 1:
                return $"Advantage {player1.Name}";
            case -1:
                return $"Advantage {player2.Name}";
            case >= 2:
                return $"Win for {player1.Name}";
            default:
                return $"Win for {player2.Name}";
        }
    }
    
    
    private static string ScoreName(int score)
    {
        string scoretext = score switch
        {
            0 => "Love",
            1 => "Fifteen",
            2 => "Thirty",
            _ => "Forty"
        };
        return scoretext;
    }
    private static string TieGame(Player7 player1, Player7 player2)
    {
        return player1.Score < 3 ? $"{ScoreName(player1.Score)}-All" : "Deuce";
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