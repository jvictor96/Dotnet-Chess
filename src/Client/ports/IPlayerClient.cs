using DotnetChess.Players;

public interface IPlayerClient 
{
    Player? CreatePlayer(string name, string email);
    Player? Login(string name, string password);
}