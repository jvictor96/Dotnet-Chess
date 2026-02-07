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
        Piece? piece = GetPiece();
        if(piece == null) return false;
        return new List<bool>() {
            piece.ValidateMovement(this),
            IsMovementInsideTheBoard(),
            IsDestinationFree(),
            IsDestinationOtherThanOrigin(),
            !IsPlayerInCheck(),
            IsPathFree()
        }.All(b => b);
    }

    private bool IsPlayerInCheck()
    {
        return false;
    }

    private bool IsDestinationOtherThanOrigin()
    {
        return true;
    }

    private bool IsMovementInsideTheBoard()
    {
        return true;
    }

    private bool IsDestinationFree()
    {
        return board.GetPieceAt(to) == null || board.GetPieceAt(to)?.GetColor() != GetPiece()?.GetColor();
    }

    private bool IsPathFree()
    {
        Piece? piece = GetPiece();
        if(piece == null) return false;
        List<Position> positions = piece.GetPlacesOnThePath(to);
        return !positions.Select(board.GetPieceAt).Any(p => p != null);
    }
}