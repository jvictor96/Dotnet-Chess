public enum Color
{
    BLACK, WHITE
}

public abstract class Piece
{
    protected Position position;        
    private Color color;

    public Piece(Position position, Color color)
    {
        this.position = position;
        this.color = color;
    }        

    public Position GetPosition()
    {
        return position;
    }  

    public Color GetColor()
    {
        return color;
    }

    public void setPosition(Position position)
    {
        this.position = position;
    }

    public abstract bool ValidateMovement(MovementAttempt movement);
    public abstract bool IsValidRoque(MovementAttempt movement);
    public abstract List<Position> GetAllPossibleDestinations();
    public abstract List<Position> GetPlacesOnThePath(Position position);
    public abstract String GetSymbol();
}

public class Pawn : Piece
{
    public Pawn(Position position, Color color) : base(position, color)
    {}
    public override bool ValidateMovement(MovementAttempt movement) {
        return false;
    }
    public override bool IsValidRoque(MovementAttempt movement) {
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
    public override bool ValidateMovement(MovementAttempt movement) {
        return false;
    }
    public override bool IsValidRoque(MovementAttempt movement) {
        return false;
    }
    public override List<Position> GetAllPossibleDestinations() {
        return new List<Position>();
    }
    public override List<Position> GetPlacesOnThePath(Position position) {
        return new List<Position>();
    }
    public override String GetSymbol() {
        return "B";
    }
}

public class Rook : Piece
{
    public Rook(Position position, Color color) : base(position, color)
    {}
    public override bool ValidateMovement(MovementAttempt movement) {
        if(movement.to.x == movement.from.x) return true;
        if(movement.to.y == movement.from.y) return true;
        return false;
    }
    public override bool IsValidRoque(MovementAttempt movement) {
        return false;
    }
    public override List<Position> GetAllPossibleDestinations() {
        return new List<Position>();
    }
    public override List<Position> GetPlacesOnThePath(Position destination) {
        if(destination.x == position.x)
        if(destination.y > position.y) return Enumerable.Range(position.y + 1, destination.y - position.y - 1).Select(y => new Position(position.x, y)).ToList();
        else return Enumerable.Range(destination.y + 1, position.y - destination.y - 1).Select(y => new Position(position.x, y)).ToList();
        if(destination.y == position.y)
        if(destination.x > position.x) return Enumerable.Range(position.x + 1, destination.x - position.x - 1).Select(x => new Position(x, position.y)).ToList();
        else return Enumerable.Range(destination.x + 1, position.x - destination.x - 1).Select(x => new Position(x, position.y)).ToList();
        return new List<Position>();
    }
    public override String GetSymbol() {
        return "R";
    }
}

public class Queen : Piece
{
    public Queen(Position position, Color color) : base(position, color)
    {}
    public override bool ValidateMovement(MovementAttempt movement) {
        return false;
    }
    public override bool IsValidRoque(MovementAttempt movement) {
        return false;
    }
    public override List<Position> GetAllPossibleDestinations() {
        return new List<Position>();
    }
    public override List<Position> GetPlacesOnThePath(Position position) {
        return new List<Position>();
    }
    public override String GetSymbol() {
        return "Q";
    }
}

public class Knight : Piece
{
    public Knight(Position position, Color color) : base(position, color)
    {}
    public override bool ValidateMovement(MovementAttempt movement) {
        return false;
    }
    public override bool IsValidRoque(MovementAttempt movement) {
        return false;
    }
    public override List<Position> GetAllPossibleDestinations() {
        return new List<Position>();
    }
    public override List<Position> GetPlacesOnThePath(Position position) {
        return new List<Position>();
    }
    public override String GetSymbol() {
        return "N";
    }
}

public class King : Piece
{
    public King(Position position, Color color) : base(position, color)
    {}
    public override bool ValidateMovement(MovementAttempt movement) {
        return false;
    }
    public override bool IsValidRoque(MovementAttempt movement) {
        return false;
    }
    public override List<Position> GetAllPossibleDestinations() {
        return new List<Position>();
    }
    public override List<Position> GetPlacesOnThePath(Position position) {
        return new List<Position>();
    }
    public override String GetSymbol() {
        return "K";
    }
}