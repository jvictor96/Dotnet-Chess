public class Position
{
    int x, y;
    public Position(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public static Position fromString (String serialized)
    {
        return new Position(serialized.ElementAt(0), int.Parse(serialized.Substring(1,1)));
    }
}