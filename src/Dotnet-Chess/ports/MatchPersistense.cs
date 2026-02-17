using board;

public interface IMatchPersistence
{
    void SaveMatch(Match match);
    Match LoadMatch(int id);
    IEnumerable<Match> ListMatches();
}