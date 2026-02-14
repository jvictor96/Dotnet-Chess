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
        return new List<bool>() {
            movement.to.x == movement.from.x && movement.to.y == movement.from.y + (GetColor() == Color.WHITE ? 1 : -1),
            movement.to.x == movement.from.x && ((GetColor() == Color.WHITE && movement.from.y == 2 && movement.to.y == 4) || (GetColor() == Color.BLACK && movement.from.y == 7 && movement.to.y == 5)),
            Math.Abs(movement.to.x - movement.from.x) == 1 && movement.to.y == movement.from.y + (GetColor() == Color.WHITE ? 1 : -1) && movement.GetPieceAtDestination() != null && movement.GetPieceAtDestination()?.GetColor() != GetColor()
        }.Any(b => b);
    }
    public override bool IsValidRoque(MovementAttempt movement) {
        return false;
    }
    public override List<Position> GetAllPossibleDestinations() {
        return new List<Position>() {
            new Position(position.x, position.y + (GetColor() == Color.WHITE ? 1 : -1)),
            new Position(position.x, position.y + (GetColor() == Color.WHITE ? 2 : -2)),
            new Position(position.x + 1, position.y + (GetColor() == Color.WHITE ? 1 : -1)),
            new Position(position.x - 1, position.y + (GetColor() == Color.WHITE ? 1 : -1))
        };
    }
    public override List<Position> GetPlacesOnThePath(Position position) {
        return Math.Abs(this.position.y - position.y) > 1 ? new List<Position>() {
            new Position(this.position.x, this.position.y + (GetColor() == Color.WHITE ? 1 : -1))
        } : new List<Position>();
    }
    public override String GetSymbol() {
        return "P";
    }
}

public class Bishop : Piece
{
    public Bishop(Position position, Color color) : base(position, color)
    {}
    public static bool IsDiagonalMovement(Position from, Position to) {
        int dx = Math.Abs(to.x - from.x);
        int dy = Math.Abs(to.y - from.y);
        return dx == dy && dx != 0;
    }
    public override bool ValidateMovement(MovementAttempt movement) {
        return IsDiagonalMovement(movement.from, movement.to);
    }
    public override bool IsValidRoque(MovementAttempt movement) {
        return false;
    }

    public static List<Position> GetPossibleDiagonalPositions(Position position) {
        int y0_down = position.y - position.x + 1;
        int y0_up = position.y + position.x - 1;
        List<Position> diagonal_up = Enumerable.Range(1, 8).Select(i => new Position(1 + i, y0_down + i)).ToList();
        List<Position> diagonal_down = Enumerable.Range(1, 8).Select(i => new Position(1 + i, y0_up - i)).ToList();
        return diagonal_up.Concat(diagonal_down).Where(p => p.x >= 1 && p.x <= 8 && p.y >= 1 && p.y <= 8).ToList();
    }
    public static List<Position> GetPlacesOnTheDiagonalPath(Position from, Position to) {
        int dx = Math.Abs(to.x - from.x);
        int min_x = Math.Min(to.x, from.x);
        int dy = to.y - from.y;
        return Enumerable.Range(min_x + 1, dx - 1).Select(i => new Position(i, from.y + i * dy / dx)).ToList();
    }
    public override List<Position> GetAllPossibleDestinations() {
        return GetPossibleDiagonalPositions(position);
    }
    public override List<Position> GetPlacesOnThePath(Position destination) {
        return GetPlacesOnTheDiagonalPath(position, destination);
    }
    public override String GetSymbol() {
        return "B";
    }
}

public class Rook : Piece
{
    public Rook(Position position, Color color) : base(position, color)
    {}
    public static bool IsHorizontalOrVerticalMovement(Position from, Position to) {
        return to.x == from.x || to.y == from.y;
    }
    public override bool ValidateMovement(MovementAttempt movement) {
        return IsHorizontalOrVerticalMovement(movement.from, movement.to);
    }
    public override bool IsValidRoque(MovementAttempt movement) {
        return false;
    }
    public static List<Position> GetPossibleHorizontalAndVerticalPositions(Position position) {
        List<Position> horizontal = Enumerable.Range(1, 8).Where(x => x != position.x).Select(x => new Position(x, position.y)).ToList();
        List<Position> vertical = Enumerable.Range(1, 8).Where(y => y != position.y).Select(y => new Position(position.x, y)).ToList();
        return horizontal.Concat(vertical).ToList();
    }
    public static List<Position> GetPlacesOnTheHorizontalOrVerticalPath(Position from, Position to) {
        if(to.x == from.x)
        if(to.y > from.y) return Enumerable.Range(from.y + 1, to.y - from.y - 1).Select(y => new Position(from.x, y)).ToList();
        else return Enumerable.Range(to.y + 1, from.y - to.y - 1).Select(y => new Position(from.x, y)).ToList();
        if(to.y == from.y)
        if(to.x > from.x) return Enumerable.Range(from.x + 1, to.x - from.x - 1).Select(x => new Position(x, from.y)).ToList();
        else return Enumerable.Range(to.x + 1, from.x - to.x - 1).Select(x => new Position(x, from.y)).ToList();
        return new List<Position>();
    }
    public override List<Position> GetAllPossibleDestinations() {
        return GetPossibleHorizontalAndVerticalPositions(position);
    }
    public override List<Position> GetPlacesOnThePath(Position destination) {
        return GetPlacesOnTheHorizontalOrVerticalPath(position, destination);
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
        return Rook.IsHorizontalOrVerticalMovement(movement.from, movement.to) || Bishop.IsDiagonalMovement(movement.from, movement.to);
    }
    public override bool IsValidRoque(MovementAttempt movement) {
        return false;
    }
    public override List<Position> GetAllPossibleDestinations() {
        return Rook.GetPossibleHorizontalAndVerticalPositions(position).Concat(
            Bishop.GetPossibleDiagonalPositions(position)).ToList();
    }
    public override List<Position> GetPlacesOnThePath(Position destination) {
        if(Rook.IsHorizontalOrVerticalMovement(position, destination)) {
            return Rook.GetPlacesOnTheHorizontalOrVerticalPath(position, destination);
        } else if(Bishop.IsDiagonalMovement(position, destination)) {
            return Bishop.GetPlacesOnTheDiagonalPath(position, destination);
        }
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
        return (Math.Abs(movement.to.x - movement.from.x) == 2 && Math.Abs(movement.to.y - movement.from.y) == 1) ||
            (Math.Abs(movement.to.x - movement.from.x) == 1 && Math.Abs(movement.to.y - movement.from.y) == 2);
    }
    public override bool IsValidRoque(MovementAttempt movement) {
        return false;
    }
    public override List<Position> GetAllPossibleDestinations() {
        return new List<Position>()
        {
            new Position(position.x + 2, position.y + 1),
            new Position(position.x + 2, position.y - 1),
            new Position(position.x - 2, position.y + 1),
            new Position(position.x - 2, position.y - 1),
            new Position(position.x + 1, position.y + 2),
            new Position(position.x + 1, position.y - 2),
            new Position(position.x - 1, position.y + 2),
            new Position(position.x - 1, position.y - 2)
        };
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
        return new List<bool> {
            Math.Abs(movement.to.x - movement.from.x) <= 1,
            Math.Abs(movement.to.y - movement.from.y) <= 1,
        }.All(x => x);
    }
    public override bool IsValidRoque(MovementAttempt movement) {
        return false;
    }
    public override List<Position> GetAllPossibleDestinations() {
        return Enumerable.Range(-1, 3).SelectMany(dx => Enumerable.Range(-1, 3).Select(dy => new Position(position.x + dx, position.y + dy))).ToList();
    }
    public override List<Position> GetPlacesOnThePath(Position position) {
        return new List<Position>();
    }
    public override String GetSymbol() {
        return "K";
    }
}