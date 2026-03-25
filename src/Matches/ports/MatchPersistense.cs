using DotnetChess.Matches.core;

public interface IMatchPersistence
{
    void SaveMatch(Match match);
    Match LoadMatch(int id);
    IEnumerable<Match> ListMatches();
    int GetNextId();
}