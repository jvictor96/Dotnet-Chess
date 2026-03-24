public interface IPLayerPersistence
{
    void SavePlayer(Player player);
    Player LoadPlayer(string name);
    List<Player> LoadAllPlayers();
}