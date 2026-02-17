public class ListCommand : KeyboardHandler
{
    private readonly IMatchPersistence boardPersistence;

    public ListCommand(IMatchPersistence boardPersistence)
    {
        this.boardPersistence = boardPersistence;
    }

    public ShellMachine.State HandleKeyboard()
    {
        Console.WriteLine("Listing games...");
        boardPersistence.ListMatches().ToList().ForEach(match =>
        {
            Console.WriteLine($"Game ID: {match.Id}, White: {match.GetPlayers().white}, Black: {match.GetPlayers().black}, Winner: {match.GetPlayers().winner ?? "N/A"}");
        });
        return ShellMachine.State.Reading;
    }
}