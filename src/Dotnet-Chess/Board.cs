namespace board;

public class Board
{
    public List<Piece> pieces;
    List<Movement> movements;
    public Dictionary<Position, Piece> positions;
    public bool legal;
    String? white, black, winner;
    public Board()
    {
        movements = new List<Movement>();
        pieces = Enumerable.Range(0, 8).Select(i => new Pawn(new Position(i, 2), Color.WHITE)).Cast<Piece>().ToList();
        pieces.AddRange(Enumerable.Range(0, 8).Select(i => new Pawn(new Position(i, 7), Color.BLACK)).Cast<Piece>().ToList());
        pieces.Add(new Rook(new Position(1,1),Color.WHITE));
        pieces.Add(new Rook(new Position(8,1),Color.WHITE));
        pieces.Add(new Rook(new Position(1,8),Color.BLACK));
        pieces.Add(new Rook(new Position(8,8),Color.BLACK));
        pieces.Add(new Knight(new Position(2,1),Color.WHITE));
        pieces.Add(new Knight(new Position(7,1),Color.WHITE));
        pieces.Add(new Knight(new Position(2,8),Color.BLACK));
        pieces.Add(new Knight(new Position(7,8),Color.BLACK));
        pieces.Add(new Bishop(new Position(3,1),Color.WHITE));
        pieces.Add(new Bishop(new Position(6,1),Color.WHITE));
        pieces.Add(new Bishop(new Position(3,8),Color.BLACK));
        pieces.Add(new Bishop(new Position(6,8),Color.BLACK));
        pieces.Add(new Queen(new Position(4,1),Color.WHITE));
        pieces.Add(new King(new Position(5,1),Color.WHITE));
        pieces.Add(new Queen(new Position(4,8),Color.BLACK));
        pieces.Add(new King(new Position(5,8),Color.BLACK));
        positions = pieces.ToDictionary(piece => piece.position);
    }

    public Piece? GetPieceAt(String position)
    {
        return positions.GetValueOrDefault(Position.fromString(position));
    }

    public Movement buildMovement(String movement)
    {
        return Movement.fromString(movement, positions);
    }

    public void UpdatePositionsAndHistory(Movement movement)
    {
        movement.pieces = null;
        movements.Add(movement);
        UpdatePositions(movement);
    }

    public void UpdatePositions(Movement movement)
    {
        if (movement.piece == null) return;
        movement.piece.position = movement.to;
        positions[movement.to] = movement.piece;
        pieces = positions.Select(kvp => kvp.Value).Cast<Piece>().ToList();
    }

    public Board moveWithoutValidation(Movement movement)
    {
        UpdatePositions(movement);
        return this;
    }

    public Board move(Movement movement)
    {
        return this;
    }

}