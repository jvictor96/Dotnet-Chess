namespace DotnetChess.Players;

public class Player
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int Score { get; set; }
    public List<int> Games { get; set; }

    public Player(string name, string email)
    {
        Name = name;
        Email = email;

        Score = 0;
        Games = new List<int>();
    }

    public void AddScore(int points)
    {
        Score += points;
    }

    public int GetTotalGames()
    {
        return Games.Count;
    }
}