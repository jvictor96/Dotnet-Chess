public class CommandReader : KeyboardHandler
{
    private readonly Keyboard keyboard;

    public CommandReader(Keyboard keyboard)
    {
        this.keyboard = keyboard;
    }

    public ShellMachine.State HandleKeyboard()
    {
        string command = keyboard.Read("Enter command: ");
        return command switch
        {
            "list" => ShellMachine.State.Listing,
            "change" => ShellMachine.State.Changing,
            "play" => ShellMachine.State.Playing,
            "resign" => ShellMachine.State.Resigning,
            "challenge" => ShellMachine.State.Challenging,
            _ => ShellMachine.State.Reading
        };
    }
}