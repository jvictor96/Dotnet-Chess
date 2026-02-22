using board;

public class ResignCommand : KeyboardHandler
{
    private readonly Keyboard keyboard;
    private readonly IMatchPersistence boardPersistence;
    private readonly string user;

    public ResignCommand(Keyboard keyboard, IMatchPersistence boardPersistence, string user)
    {
        this.user = user;
        this.keyboard = keyboard;
        this.boardPersistence = boardPersistence;
    }

    public ShellMachine.State HandleKeyboard()
    {
        ListCommand.FormattedListGames(boardPersistence.ListMatches().ToList());
        string input = keyboard.Read("Enter the game ID to resign:");
        if (int.TryParse(input, out int gameId))
        {
            Match match = boardPersistence.LoadMatch(gameId);
            string? black = match.GetPlayers().black;
            string? white = match.GetPlayers().white;
            if ( black == null || white == null ) return ShellMachine.State.Reading;
            string winner = black == user ? white : black;
            match.SetWinner(winner);
        }
        return ShellMachine.State.Reading;
    }
}