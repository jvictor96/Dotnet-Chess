public class MovementAttempt
{
    public Position from, to;
    public Board board;
    public MovementAttempt(Position from, Position to, Board board)
    {
        this.from = from;
        this.to = to;
        this.board = board;
    }
    public Piece? GetPieceAtDestination()
    {
        return board.GetPieceAt(to);
    }

    public static MovementAttempt FromString(string serialized, Board board)
    {
        return new MovementAttempt(
            Position.FromString(serialized.Substring(0,2)), 
            Position.FromString(serialized.Substring(2,2)), 
            board);
    }

    public ValidMovement? ToValidMovement(bool bypassValidation = false, bool bypassCheckValidation = false)
    {
        Piece? piece = GetPiece();
        if(piece == null) return null;
        if(!bypassValidation && !IsMovementValid(bypassCheckValidation)) return null;
        return new ValidMovement(from, to, piece, board);
    }

    public Piece? GetPiece()
    {
        return board.GetPieceAt(from);
    }

    private bool IsMovementValid(bool bypassCheckValidation = false)
    {
        Piece? piece = GetPiece();
    if(piece == null || !IsDestinationFree()) return false;
        return new List<bool>() {
            piece.ValidateMovement(this),
            IsMovementInsideTheBoard(),
            IsDestinationOtherThanOrigin(),
            bypassCheckValidation || !WillPlayerBeInCheck(),
            IsPathFree()
        }.All(b => b);
    }

    private bool WillPlayerBeInCheck()
    {
        Board hypotheticalBoard = new Board(board.GetPieces().ToDictionary(p => new Position(p.GetPosition().x, p.GetPosition().y), p => Piece.CloneFactory(p)));
        MovementAttempt hypotheticalMovement = new MovementAttempt(from, to, hypotheticalBoard);
        if (hypotheticalMovement.ToValidMovement(bypassValidation: true) is ValidMovement m)  m.Apply();
        else return true;
        return hypotheticalBoard.IsPlayerInCheck(GetPiece()!.GetColor());
    }

    private bool IsDestinationOtherThanOrigin()
    {
        return to.x != from.x || to.y != from.y;
    }

    private bool IsMovementInsideTheBoard()
    {
        return to.x >= 1 && to.x <= 8 && to.y >= 1 && to.y <= 8;
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