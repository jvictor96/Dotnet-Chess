using DotnetChess.Matches.core;

public interface IMatchClient
{
    public  List<Match> GetMatchesForPlayer(string player);
    public Match? ResignMatch(string matchId, string player);
    public Match? MakeMove(string matchId, string player, string movement);
    public Match? ChallengePlayer(string challenger, string opponent, string movement);
}