using DotnetChess.Matches.core;

public interface IMatchPersistence
{
    void SaveMatch(Match match);
    Match? LoadMatch(Guid id);
    IEnumerable<Match> ListMatches();
}