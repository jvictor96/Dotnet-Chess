namespace DotnetChess.Players;

public class PlayerService
{
    private readonly IPLayerPersistence playerPersistence;


    public PlayerService(IPLayerPersistence playerPersistence)
    {
        this.playerPersistence = playerPersistence;
    }

    public Player? CreatePlayer(string name, string email)
    {
        return playerPersistence.SavePlayer(new Player(name, email));
    }

    public Player? GetPlayer(string name)
    {
        return playerPersistence.LoadPlayer(name);
    }

    public List<Player>? GetAllPlayers()
    {
        return playerPersistence.LoadAllPlayers();
    }

    public Player? Login(string name, string password)
    {
        return playerPersistence.LoadPlayer(name);
    }
}