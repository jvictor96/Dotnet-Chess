using DotnetChess.Matches.core;

public class InMemoryPlayers : IPlayerClient
{
    private readonly List<Player> players;

    public InMemoryPlayers(List<Player> players)
    {
        this.players = players;
    }

    public Player? GetPlayer(string name)
    {
        return players.FirstOrDefault(p => p.Name == name);
    }
}