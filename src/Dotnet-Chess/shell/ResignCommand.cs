public class ResignCommand : KeyboardHandler
{
    private readonly Keyboard keyboard;

    public ResignCommand(Keyboard keyboard)
    {
        this.keyboard = keyboard;
    }

    public ShellMachine.State HandleKeyboard()
    {
        string input = keyboard.Read("Enter the game ID to resign:");
        return ShellMachine.State.Reading;
    }
}