public interface IPlayerClient 
{
    Player CreatePlayer(string name);
    Player Login(string name, string password);
}