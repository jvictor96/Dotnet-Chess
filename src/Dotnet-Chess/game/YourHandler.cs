public class YourHandler : MovementHandler
{

    private readonly List<string> movementBus;
    private readonly IMatchPersistence persistence;
    private readonly IMessageCrossing messageCrossing;
    private readonly int id;
    private readonly IGameViewer gameViewer;

    public YourHandler(List<string> movementBus, IMatchPersistence persistence, IMessageCrossing messageCrossing, int id, IGameViewer gameViewer)
    {
        this.movementBus = movementBus;
        this. persistence = persistence;
        this.messageCrossing = messageCrossing;
        this.id = id;
        this.gameViewer = gameViewer;
    }

    public GameMachine.State HandleMovement()
    {
        throw new NotImplementedException();
    }
}