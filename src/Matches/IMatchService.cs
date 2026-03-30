using DotnetChess.Matches.core;

public interface IMatchService
{
    public IEnumerable<Match> GetMatchesForPlayer(string player);

    public Match? ResignMatch(Guid matchId, string player);

    public Match? MakeMove(Guid matchId, string player, string movement);

    public Match? ChallengePlayer(string challenger, string opponent, string movement);
}