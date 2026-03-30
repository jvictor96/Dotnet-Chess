namespace DotnetChess.Matches.core;
public class MatchService: IMatchService
{
    private readonly IMatchPersistence matchPersistence;
    private readonly IPlayerClient playerClient;


    public MatchService(IMatchPersistence matchPersistence, IPlayerClient playerClient)
    {
        this.matchPersistence = matchPersistence;
        this.playerClient = playerClient;
    }

    public IEnumerable<Match> GetMatchesForPlayer(string player)
    {
        return matchPersistence.ListMatches().Where(m => m.GetPlayers().white == player || m.GetPlayers().black == player);
    }
    public Match? ResignMatch(Guid matchId, string player)
    {
        Match? match = matchPersistence.LoadMatch(matchId);
        match?.Resign(player);
        return match;
    }

    public Match? MakeMove(Guid matchId, string player, string movement)
    {
        Match? match = matchPersistence.LoadMatch(matchId);
        if(match == null) return null;
        if(!match.IsRightTurnForPlayer(player)) return null;
        Match? movedMatch = match.move(match.buildMovementAttempt(movement));
        if(movedMatch != null) matchPersistence.SaveMatch(movedMatch);
        return movedMatch;
    }

    public Match? ChallengePlayer(string challenger, string opponent, string movement)
    {
        Player? challengerPlayer = playerClient.GetPlayer(challenger);
        Player? opponentPlayer = playerClient.GetPlayer(opponent);
        if (challengerPlayer == null || opponentPlayer == null) return null;

        Match match = new Match(new Players(challenger, opponent, ""));
        Match? movedMatch = match.move(match.buildMovementAttempt(movement));
        matchPersistence.SaveMatch(movedMatch ?? match);
        return movedMatch ?? match;
    }
}