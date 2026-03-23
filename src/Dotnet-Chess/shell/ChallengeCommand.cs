using board;

public class ChallengeCommand : KeyboardHandler
{
    private readonly Keyboard keyboard;
    private readonly IMatchPersistence matchPersistence;
    private readonly string user;

    public ChallengeCommand(Keyboard keyboard, IMatchPersistence matchPersistence, string user)
    {
        this.keyboard = keyboard;
        this.matchPersistence = matchPersistence;
        this.user = user;
    }

    public ShellMachine.State HandleKeyboard()
    {
        string opponent = keyboard.Read("Who will you play against? ");
        Match match = new Match(new Players(user, opponent, "null"));
        match.Id = matchPersistence.GetNextId();
        matchPersistence.SaveMatch(match);
        return ShellMachine.State.Listing;
    }
}