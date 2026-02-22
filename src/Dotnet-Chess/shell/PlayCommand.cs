public class PlayCommand : KeyboardHandler
{
    private readonly Keyboard keyboard;
    private readonly List<string> messageBus;

    public PlayCommand(IMatchPersistence boardPersistence, Keyboard keyboard, List<string> messageBus)
    {
        this.keyboard = keyboard;
        this.messageBus = messageBus;
    }

    public ShellMachine.State HandleKeyboard()
    {
        messageBus.Add(keyboard.Read("Which movement? "));
        return ShellMachine.State.Reading;
    }
}