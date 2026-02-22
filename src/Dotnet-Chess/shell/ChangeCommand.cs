using board;

public class ChangeCommand : KeyboardHandler
{
    private readonly IMatchPersistence boardPersistence;
    private readonly Keyboard keyboard;
    private readonly string user;
    private readonly List<string> movementBus;
    private readonly IMessageCrossingFactory messageCrossingFactory;
    private readonly IGameViewer gameViewer;
    private Task? game;
    private CancellationTokenSource cancellationSource;

    public ChangeCommand(IGameViewer gameViewer, IMatchPersistence boardPersistence, Keyboard keyboard, string user, List<string> movementBus, IMessageCrossingFactory messageCrossingFactory)
    {
        this.boardPersistence = boardPersistence;
        this.keyboard = keyboard;
        this.user = user;
        this.messageCrossingFactory = messageCrossingFactory;
        this.movementBus = movementBus;
        this.gameViewer = gameViewer;
        cancellationSource = new CancellationTokenSource();
    }

    public ShellMachine.State HandleKeyboard()
    {
        if(game != null) cancellationSource.Cancel();
        ListCommand.FormattedListGames(boardPersistence.ListMatches().ToList());
        string input = keyboard.Read("Enter the game ID to change:");
        if (int.TryParse(input, out int gameId))
        {
            Match match = boardPersistence.LoadMatch(gameId);
            GameMachine.State state = match.IsRightTurnForPlayer(user) ? GameMachine.State.YourTurn : GameMachine.State.OpponentTurn;
            IMessageCrossing messageCrossing = messageCrossingFactory.GetMessageCrossing();
            GameMachine gameMachine = new GameMachine(new Dictionary<GameMachine.State, MovementHandler>
            {
                {GameMachine.State.YourTurn, new YourHandler(movementBus, boardPersistence, messageCrossing, gameId, gameViewer)},
                {GameMachine.State.OpponentTurn, new OpponentHandler(boardPersistence, messageCrossing, gameId, gameViewer)}
            });
            
            game = Task.Run(() => gameMachine.Start(state, cancellationSource.Token));
        }
        return ShellMachine.State.Reading;
    }
}