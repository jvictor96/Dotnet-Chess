public class Movement
{
    public Position from, to;
    public Dictionary<Position, Piece>? pieces;
    public Piece? piece;
    public Movement(Position from, Position to, Dictionary<Position, Piece> pieces)
    {
        this.from = from;
        this.to = to;
        this.pieces = pieces;
        try
        {
            piece = pieces[from];
        }
        catch (KeyNotFoundException)
        {
            piece = null;
        }
    }

    public static Movement fromString(String serialized, Dictionary<Position, Piece> pieces)
    {
        return new Movement(
            Position.fromString(serialized.Substring(0,2)), 
            Position.fromString(serialized.Substring(2,2)), 
            pieces);
    }

    public bool IsMovementValid()
    {
        return new List<bool>() {
            IsMovementInsideTheBoard(),
            IsValidPieceWise(),
            IsPAthFree()
        }.All(b => b);
    }

    private bool IsMovementInsideTheBoard()
    {
        return true;
    }

    private bool IsValidPieceWise()
    {
        return true;
    }

    private bool IsPAthFree()
    {
        return true;
    }
}