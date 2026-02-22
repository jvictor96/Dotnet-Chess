public class GameMachine
{
    public enum State
    {
        YourTurn,
        OpponentTurn
    }
    State currentState, nextState;

    private readonly Dictionary<State, MovementHandler> handlers;

    public GameMachine(Dictionary<State, MovementHandler> handlers)
    {
        this.handlers = handlers;
    }

    public void Start(State beginningState, CancellationToken cancellationToken)
    {
        currentState = beginningState;
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();
            nextState = handlers[currentState].HandleMovement();
            currentState = nextState;
        }
    }
}