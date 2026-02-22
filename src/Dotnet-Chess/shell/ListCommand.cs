using board;

public class ListCommand : KeyboardHandler
{
    private readonly IMatchPersistence boardPersistence;

    public ListCommand(IMatchPersistence boardPersistence)
    {
        this.boardPersistence = boardPersistence;
    }

    public static void FormattedListGames(List<Match> matches)
    {
        matches.ForEach(match =>
        {
            Console.WriteLine($"Game ID: {match.Id}, White: {match.GetPlayers().white}, Black: {match.GetPlayers().black}, Winner: {match.GetPlayers().winner ?? "N/A"}");
        });
    }

    public ShellMachine.State HandleKeyboard()
    {
        FormattedListGames(boardPersistence.ListMatches().ToList());
        return ShellMachine.State.Reading;
    }
}