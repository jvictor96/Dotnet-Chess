using DotnetChess.Matches.core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IMatchService, MatchService>();
builder.Services.AddDbContext<MatchDbContext>(options => 
    options.UseInMemoryDatabase("MatchDb"));
builder.Services.AddDbContext<PlayerDbContext>(options => 
    options.UseInMemoryDatabase("PlayerDb"));

builder.Services.AddScoped<IMatchPersistence>(provider => 
    provider.GetRequiredService<MatchDbContext>());
builder.Services.AddScoped<IPlayerClient>(provider => 
    provider.GetRequiredService<PlayerDbContext>());

var app = builder.Build();

app.MapControllers();
app.Run();