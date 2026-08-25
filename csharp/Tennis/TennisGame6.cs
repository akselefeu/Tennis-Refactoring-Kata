namespace Tennis;

public class TennisGame6 : ITennisGame
{
    private Player6 _player1;
    private Player6 _player2;


    public TennisGame6(string player1Name, string player2Name)
    {
        _player1 = new Player6(player1Name);
        _player2 = new Player6(player2Name);
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
        string result;
        if (_player1.Score == _player2.Score)
        {
            result = TieScore(_player1.Score);
        }
        else if (_player1.Score >= 4 || _player2.Score >= 4)
        {
            result = EndGameScore(_player1, _player2);
        }
        else
        {
            result = RegularScore(_player1, _player2);
        }
        return result;
    }

    private static string TieScore(int score)
    {
        return score < 3 ? $"{ScoreName(score)}-All" : "Deuce";
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

    private static string RegularScore(Player6 player1, Player6 player2)
    {
        return $"{ScoreName(player1.Score)}-{ScoreName(player2.Score)}";

    }

    private static string EndGameScore(Player6 player1, Player6 player2)
    {
        string endGameScore;

        switch (player1.Score - player2.Score)
        {
            case 1:
                endGameScore = $"Advantage {player1.Name}";
                break;
            case -1:
                endGameScore = $"Advantage {player2.Name}";
                break;
            case >= 2:
                endGameScore = $"Win for {player1.Name}";
                break;
            default:
                endGameScore = $"Win for {player2.Name}";
                break;
        }
        return endGameScore;
    }
    public class Player6
    {
        public string Name { get; }
        public int Score { get; private set; }

        public Player6(string name)
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