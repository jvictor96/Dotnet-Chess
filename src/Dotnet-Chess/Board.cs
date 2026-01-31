namespace board;

public class Board
{
    public List<Piece> pieces;
    List<Movement> movements;
    Dictionary<Position, Piece> positions;
    public bool legal;
    String? white, black, winner;
    public Board()
    {
        movements = new List<Movement>();
        pieces = Enumerable.Range(0, 8).Select(i => new Pawn(new Position(i, 2), Color.WHITE)).Cast<Piece>().ToList();
        pieces.AddRange(Enumerable.Range(0, 8).Select(i => new Pawn(new Position(i, 7), Color.BLACK)).Cast<Piece>().ToList());
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
        UpdatePositions(movement);
    }

    public void UpdatePositions(Movement movement)
    {
        
    }

    public Board moveWithoutValidation()
    {
        return this;
    }

    public Board move()
    {
        return this;
    }

}