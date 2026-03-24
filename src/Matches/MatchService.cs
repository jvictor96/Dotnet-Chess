using board;
public class MatchService
{
    private readonly IMatchPersistence matchPersistence;


    public MatchService(IMatchPersistence matchPersistence)
    {
        this.matchPersistence = matchPersistence;
    }

    public IEnumerable<Match> GetMatchesForPlayer(string player)
    {
        return matchPersistence.ListMatches().Where(m => m.GetPlayers().white == player || m.GetPlayers().black == player);
    }

    public Match? ResignMatch(string matchId, string player)
    {
        Match? match = matchPersistence.LoadMatch(int.Parse(matchId));
        match?.Resign(player);
        return match;
    }

    public Match? MakeMove(string matchId, string player, string movement)
    {
        Match? match = matchPersistence.LoadMatch(int.Parse(matchId));
        if(match == null) return null;
        if(!match.IsRightTurnForPlayer(player)) return null;
        Match? movedMatch = match.move(match.buildMovementAttempt(movement));
        if(movedMatch != null) matchPersistence.SaveMatch(movedMatch);
        return movedMatch;
    }

    public Match? ChallengePlayer(string challenger, string opponent, string movement)
    {
        Match match = new Match(new Players(challenger, opponent, "null"));
        Match? movedMatch = match.move(match.buildMovementAttempt(movement));
        matchPersistence.SaveMatch(movedMatch ?? match);
        return movedMatch ?? match;
    }
}