using DotnetChess.Matches.core;

public interface IPlayerClient
{
    Player? GetPlayer(string name);
}