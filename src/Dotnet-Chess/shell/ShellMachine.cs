public class ShellMachine
{
    public enum State
    {
        Reading,
        Listing,
        Changing,
        Playing,
        Resigning,
        Challenging
    }
    private readonly Dictionary<State, KeyboardHandler> playerHandlers;
    private State currentState, nextState;

    public ShellMachine(Dictionary<State, KeyboardHandler> playerHandlers)
    {
        this.playerHandlers = playerHandlers;
    }

    public void Run()
    {
        currentState = State.Reading;
        // Main loop for the shell machine
        while (true)
        {
            nextState = playerHandlers[currentState].HandleKeyboard();
            currentState = nextState;
        }
    }
}