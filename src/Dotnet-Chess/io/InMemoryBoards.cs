using board;

public class InMemoryBoards : IMatchPersistence
{
    private Dictionary<int, Match> matches = new Dictionary<int, Match>();

    public void SaveMatch(Match match)
    {
        matches[match.Id] = match;
    }

    public Match LoadMatch(int id)
    {
        return matches[id];
    }
    public IEnumerable<Match> ListMatches()
    {
        return matches.Values;
    }
}