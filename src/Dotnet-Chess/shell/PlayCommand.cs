public class PlayCommand : KeyboardHandler
{
    private readonly Keyboard keyboard;

    public PlayCommand(IMatchPersistence boardPersistence, Keyboard keyboard)
    {
        this.keyboard = keyboard;
    }

    public ShellMachine.State HandleKeyboard()
    {
        return ShellMachine.State.Reading;
    }
}