public class InputRouter
{
    private readonly IPlayerClient playerClient;
    private readonly IMatchClient matchClient;
    private readonly Dictionary<string, Action<string[]>> Commands;
    public static readonly string MOVE_COMMAND = "make_move";
    public static readonly string CREATE_PLAYER_COMMAND = "create_player";
    public static readonly string LOGIN_COMMAND = "login";
    public static readonly string GET_MATCHES_COMMAND = "get_matches";
    public static readonly string RESIGN_MATCH_COMMAND = "resign_match";
    public static readonly string CHALLENGE_PLAYER_COMMAND = "challenge_player";

    public InputRouter(IPlayerClient playerClient, IMatchClient matchClient)
    {
        this.playerClient = playerClient;
        this.matchClient = matchClient;
        Commands = new Dictionary<string, Action<string[]>>
        {
            { MOVE_COMMAND, args => matchClient.MakeMove(args[0], args[1], args[2]) },
            { CREATE_PLAYER_COMMAND, args => playerClient.CreatePlayer(args[0], args[1]) },
            { LOGIN_COMMAND, args => playerClient.Login(args[0], args[1]) },
            { GET_MATCHES_COMMAND, args => matchClient.GetMatchesForPlayer(args[0]) },
            { RESIGN_MATCH_COMMAND, args => matchClient.ResignMatch(args[0], args[1]) },
            { CHALLENGE_PLAYER_COMMAND, args => matchClient.ChallengePlayer(args[0], args[1], args[2]) }
        };
    }

    public List<string> GetAvailableCommands()
    {
        return Commands.Keys.ToList();
    }

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