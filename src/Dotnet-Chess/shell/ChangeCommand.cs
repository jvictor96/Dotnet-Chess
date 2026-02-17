using board;

public class ChangeCommand : KeyboardHandler
{
    private readonly IMatchPersistence boardPersistence;
    private readonly Keyboard keyboard;

    public ChangeCommand(IMatchPersistence boardPersistence, Keyboard keyboard)
    {
        this.boardPersistence = boardPersistence;
        this.keyboard = keyboard;
    }

    public ShellMachine.State HandleKeyboard()
    {
        string input = keyboard.Read("Enter the game ID to change:");
        if (int.TryParse(input, out int gameId))
        {
        }
        else
        {
        }
        return ShellMachine.State.Reading;
    }
}