public class Board
{
    Dictionary<Position, Piece> positions;
    public Board(Dictionary<Position, Piece> positions)
    {
        this.positions = positions;
    }

    public Board()
    {
        List<Piece> pieces = Enumerable.Range(1, 9).Select(i => new Pawn(new Position(i, 2), Color.WHITE)).Cast<Piece>().ToList();
        pieces.AddRange(Enumerable.Range(1, 9).Select(i => new Pawn(new Position(i, 7), Color.BLACK)).Cast<Piece>().ToList());
        pieces.Add(new Rook(new Position(1,1),Color.WHITE));
        pieces.Add(new Knight(new Position(2,1),Color.WHITE));
        pieces.Add(new Bishop(new Position(3,1),Color.WHITE));
        pieces.Add(new Queen(new Position(4,1),Color.WHITE));
        pieces.Add(new King(new Position(5,1),Color.WHITE));
        pieces.Add(new Bishop(new Position(6,1),Color.WHITE));
        pieces.Add(new Knight(new Position(7,1),Color.WHITE));
        pieces.Add(new Rook(new Position(8,1),Color.WHITE));
        pieces.Add(new Rook(new Position(1,8),Color.BLACK));
        pieces.Add(new Knight(new Position(2,8),Color.BLACK));
        pieces.Add(new Bishop(new Position(3,8),Color.BLACK));
        pieces.Add(new Queen(new Position(4,8),Color.BLACK));
        pieces.Add(new King(new Position(5,8),Color.BLACK));
        pieces.Add(new Bishop(new Position(6,8),Color.BLACK));
        pieces.Add(new Knight(new Position(7,8),Color.BLACK));
        pieces.Add(new Rook(new Position(8,8),Color.BLACK));
        positions = pieces.ToDictionary(piece => piece.GetPosition());
    }

    public Piece? GetPieceAt(Position position)
    {
        return positions.GetValueOrDefault(position);
    }

    public void Apply(ValidMovement movement)
    {
        positions[movement.to] = positions[movement.from];
        positions.Remove(movement.from);
    }
}