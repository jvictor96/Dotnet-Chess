namespace DotnetChess.Matches.core;

public class Position
{
    public int x, y;
    public Position(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public static Position FromString (String serialized)
    {
        char charA = 'a';
        return new Position((int)serialized.ElementAt(0) - (int)charA + 1, int.Parse(serialized.Substring(1,1)));
    }

    public bool Equals(Position? other)
    {
        if (ReferenceEquals(this, other)) return true;
        if (other is null) return false;
        return x == other.x && y == other.y;
    }

    public override bool Equals(object? obj)
        => Equals(obj as Position);

    public override int GetHashCode()
        => HashCode.Combine(x, y);
}