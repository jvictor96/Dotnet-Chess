namespace DotnetChess.Matches.core;
using Microsoft.EntityFrameworkCore;
public class MatchDbContext : DbContext, IMatchPersistence
{
    public MatchDbContext(DbContextOptions<MatchDbContext> options) : base(options) { }

    public DbSet<Match> Matches {get; set;}

    public IEnumerable<Match> ListMatches()
    {
        return Matches.ToList();
    }

    public Match? LoadMatch(Guid id)
    {
        return Matches.FirstOrDefault(m => id == m.Id);
    }

    public void SaveMatch(Match match)
    {
        Matches.Add(match);
    }
}