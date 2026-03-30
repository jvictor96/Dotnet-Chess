using DotnetChess.Matches.core;
using Microsoft.EntityFrameworkCore;

public class PlayerDbContext : DbContext, IPlayerClient
{
    public PlayerDbContext(DbContextOptions<PlayerDbContext> options) : base(options) { }
    public DbSet<Player> Players {get; set;}

    public Player? GetPlayer(string name)
    {
        return Players.FirstOrDefault(p => p.Name == name);
    }
}