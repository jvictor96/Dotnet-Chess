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

    public void Run(State beginningState)
    {
        currentState = beginningState;
        while (true)
        {
            nextState = handlers[currentState].HandleMovement();
            currentState = nextState;
        }
    }
}