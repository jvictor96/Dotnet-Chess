using System.Text.RegularExpressions;

public class MatchService
{
    private readonly IMatchPersistence matchPersistence;


    public MatchService(IMatchPersistence matchPersistence)
    {
        this.matchPersistence = matchPersistence;
    }

    public List<Match> GetMatchesForPlayer(string player)
    {
        return new List<Match>();
    }

    public Match? ResignMatch(string matchId, string player)
    {
        return null;
    }

    public Match? MakeMove(string matchId, string player, string movement)
    {
        return null;
    }

    public Match? ChallengePlayer(string challenger, string opponent)
    {
        return null;
    }
}