namespace DotnetChess.Matches.core;

public class Players
{
    public string black, white;
    public string? winner;
    public Players(string white, string black,  string winner)
    {
        this.winner = winner;
        this.black = black;
        this.white = white;
    }
}