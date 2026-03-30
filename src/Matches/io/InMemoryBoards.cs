namespace DotnetChess.Matches.core;

public class InMemoryBoards : IMatchPersistence
{
    private Dictionary<Guid, Match> matches = new Dictionary<Guid, Match>();
    private int nextId;

    public void SaveMatch(Match match)
    {
        matches[match.Id] = match;
    }

    public Match LoadMatch(Guid id)
    {
        return matches[id];
    }
    public IEnumerable<Match> ListMatches()
    {
        return matches.Values;
    }
}