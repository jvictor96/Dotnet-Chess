public class PlayerService
{
    private readonly IPLayerPersistence playerPersistence;


    public PlayerService(IPLayerPersistence playerPersistence)
    {
        this.playerPersistence = playerPersistence;
    }

    public void CreatePlayer(string name, string email)
    {
    }

    public Player? GetPlayer(string name)
    {
        return null;
    }

    public List<Player>? GetAllPlayers()
    {
        return null;
    }

    public Player? Login(string name)
    {
        return null;
    }
}