public enum Color
{
    BLACK, WHITE
}

public abstract class Piece
{
    public Position position;        
    public Color color;

    public Piece(Position position, Color color)
    {
        this.position = position;
        this.color = color;
    }        

    public abstract bool ValidateMovement(Movement movement, Dictionary<Position, Piece> positions);
    public abstract bool IsValidRoque(Movement movement, Dictionary<Position, Piece> positions);
    public abstract List<Position> GetAllPossibleDestinations();
    public abstract List<Position> GetPlacesOnThePath(Position position);
    public abstract String GetSymbol();
}

public class Pawn : Piece
{
    public Pawn(Position position, Color color) : base(position, color)
    {}
    public override bool ValidateMovement(Movement movement, Dictionary<Position, Piece> positions) {
        return false;
    }
    public override bool IsValidRoque(Movement movement, Dictionary<Position, Piece> positions) {
        return false;
    }
    public override List<Position> GetAllPossibleDestinations() {
        return new List<Position>();
    }
    public override List<Position> GetPlacesOnThePath(Position position) {
        return new List<Position>();
    }
    public override String GetSymbol() {
        return "P";
    }
}

public class Bishop : Piece
{
    public Bishop(Position position, Color color) : base(position, color)
    {}
    public override bool ValidateMovement(Movement movement, Dictionary<Position, Piece> positions) {
        return false;
    }
    public override bool IsValidRoque(Movement movement, Dictionary<Position, Piece> positions) {
        return false;
    }
    public override List<Position> GetAllPossibleDestinations() {
        return new List<Position>();
    }
    public override List<Position> GetPlacesOnThePath(Position position) {
        return new List<Position>();
    }
    public override String GetSymbol() {
        return "P";
    }
}

public class Rook : Piece
{
    public Rook(Position position, Color color) : base(position, color)
    {}
    public override bool ValidateMovement(Movement movement, Dictionary<Position, Piece> positions) {
        return false;
    }
    public override bool IsValidRoque(Movement movement, Dictionary<Position, Piece> positions) {
        return false;
    }
    public override List<Position> GetAllPossibleDestinations() {
        return new List<Position>();
    }
    public override List<Position> GetPlacesOnThePath(Position position) {
        return new List<Position>();
    }
    public override String GetSymbol() {
        return "P";
    }
}

public class Queen : Piece
{
    public Queen(Position position, Color color) : base(position, color)
    {}
    public override bool ValidateMovement(Movement movement, Dictionary<Position, Piece> positions) {
        return false;
    }
    public override bool IsValidRoque(Movement movement, Dictionary<Position, Piece> positions) {
        return false;
    }
    public override List<Position> GetAllPossibleDestinations() {
        return new List<Position>();
    }
    public override List<Position> GetPlacesOnThePath(Position position) {
        return new List<Position>();
    }
    public override String GetSymbol() {
        return "P";
    }
}

public class Knight : Piece
{
    public Knight(Position position, Color color) : base(position, color)
    {}
    public override bool ValidateMovement(Movement movement, Dictionary<Position, Piece> positions) {
        return false;
    }
    public override bool IsValidRoque(Movement movement, Dictionary<Position, Piece> positions) {
        return false;
    }
    public override List<Position> GetAllPossibleDestinations() {
        return new List<Position>();
    }
    public override List<Position> GetPlacesOnThePath(Position position) {
        return new List<Position>();
    }
    public override String GetSymbol() {
        return "P";
    }
}

public class King : Piece
{
    public King(Position position, Color color) : base(position, color)
    {}
    public override bool ValidateMovement(Movement movement, Dictionary<Position, Piece> positions) {
        return false;
    }
    public override bool IsValidRoque(Movement movement, Dictionary<Position, Piece> positions) {
        return false;
    }
    public override List<Position> GetAllPossibleDestinations() {
        return new List<Position>();
    }
    public override List<Position> GetPlacesOnThePath(Position position) {
        return new List<Position>();
    }
    public override String GetSymbol() {
        return "P";
    }
}