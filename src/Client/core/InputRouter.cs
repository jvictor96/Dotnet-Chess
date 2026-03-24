public class InputRouter
{
    private readonly IPlayerClient playerClient;
    private readonly IMatchClient matchClient;

    public InputRouter(IPlayerClient playerClient, IMatchClient matchClient)
    {
        this.playerClient = playerClient;
        this.matchClient = matchClient;
    }

    private static readonly Dictionary<string, Action<string[]>> Commands = new()
    {
        { "make_move", args => matchClient.MakeMove(args[0], args[1], args[2]) },
        { "create_player", args => playerClient.CreatePlayer(args[0]) },
        { "login", args => playerClient.Login(args[0], args[1]) },
        { "get_matches", args => matchClient.GetMatchesForPlayer(args[0]) },
        { "resign_match", args => matchClient.ResignMatch(args[0], args[1]) },
        { "challenge_player", args => matchClient.ChallengePlayer(args[0], args[1]) }
    };

    public void RouteInput(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return;

        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var command = parts[0].ToLower();
        var args = parts.Skip(1).ToArray();

        if (Commands.TryGetValue(command, out var action))
        {
            try {
                action(args);
            } catch (IndexOutOfRangeException) {
                Console.WriteLine($"Erro: O comando '{command}' exige mais argumentos.");
            }
        }
        else {
            Console.WriteLine("Unknown command");
        }
    }
}