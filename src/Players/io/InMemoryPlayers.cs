namespace DotnetChess.Players;

public class InMemoryPlayers : IPLayerPersistence
{
    private readonly Dictionary<string, Player> players = new Dictionary<string, Player>();

    public Player? SavePlayer(Player player)
    {
        if (players.ContainsKey(player.Name))
        return null;
        players[player.Name] = player;
        return player;
    }

    public Player? LoadPlayer(string name)
    {
        players.TryGetValue(name, out var player);
        return player;
    }

    public List<Player> LoadAllPlayers()
    {
        return players.Values.ToList();
    }
}