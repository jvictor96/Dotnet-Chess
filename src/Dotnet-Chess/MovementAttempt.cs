public class MovementAttempt
{
    public Position from, to;
    private Board board;
    public MovementAttempt(Position from, Position to, Board board)
    {
        this.from = from;
        this.to = to;
        this.board = board;
    }

    public static MovementAttempt FromString(string serialized, Board board)
    {
        return new MovementAttempt(
            Position.FromString(serialized.Substring(0,2)), 
            Position.FromString(serialized.Substring(2,2)), 
            board);
    }

    public ValidMovement? ToValidMovement(bool bypassValidation = false)
    {
        Piece? piece = GetPiece();
        if(piece == null) return null;
        if(!bypassValidation && !IsMovementValid()) return null;
        return new ValidMovement(from, to, piece, board);
    }

    public Piece? GetPiece()
    {
        return board.GetPieceAt(from);
    }

    private bool IsMovementValid()
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