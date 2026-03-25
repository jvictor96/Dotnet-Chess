namespace DotnetChess.Players;

public interface IPLayerPersistence
{
    Player? SavePlayer(Player player);
    Player? LoadPlayer(string name);
    List<Player> LoadAllPlayers();
}