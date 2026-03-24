public class IMatchClient
{
    List<Match> GetMatchesForPlayer(string player);
    Match ResignMatch(string matchId, string player);
    Match MakeMove(string matchId, string player, string movement);
    Match ChallengePlayer(string challenger, string opponent);
}