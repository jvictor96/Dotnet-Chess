using DotnetChess.Matches.core;

public class MatchClient : IMatchClient
{
    private readonly MatchService matchService;

    public MatchClient(MatchService matchService)
    {
        this.matchService = matchService;
    }

    public List<Match> GetMatchesForPlayer(string player)
    {
        return matchService.GetMatchesForPlayer(player).ToList();
    }

    public Match? ResignMatch(string matchId, string player)
    {
        return matchService.ResignMatch(matchId, player);
    }

    public Match? MakeMove(string matchId, string player, string movement)
    {
        return matchService.MakeMove(matchId, player, movement);
    }

    public Match? ChallengePlayer(string challenger, string opponent, string movement)
    {
        return matchService.ChallengePlayer(challenger, opponent, movement);
    }
}