using DotnetChess.Players;
public class PlayerClient : IPlayerClient
{
    private readonly PlayerService playerService;

    public PlayerClient(PlayerService playerService)
    {
        this.playerService = playerService;
    }

    public Player? CreatePlayer(string name, string email)
    {
        return playerService.CreatePlayer(name, email);
    }

    public Player? Login(string name, string password)
    {
        return playerService.Login(name, password);
    }
}