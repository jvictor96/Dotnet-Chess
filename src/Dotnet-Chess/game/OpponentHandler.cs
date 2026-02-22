public class OpponentHandler : MovementHandler
{
    private readonly IMatchPersistence persistence;
    private readonly IMessageCrossing messageCrossing;
    private readonly int id;
    private readonly IGameViewer gameViewer;

    public OpponentHandler(IMatchPersistence persistence, IMessageCrossing messageCrossing, int id, IGameViewer gameViewer)
    {
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