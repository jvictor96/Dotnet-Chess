public class PlayerClient : IPlayerClient
{
    private readonly PlayerService playerService;

    public PlayerClient(PlayerService playerService)
    {
        this.playerService = playerService;
    }

    public Player CreatePlayer(string name)
    {
        return playerService.CreatePlayer(name);
    }

    public Player Login(string name, string password)
    {
        return playerService.Login(name, password);
    }
}