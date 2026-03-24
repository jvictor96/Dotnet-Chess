public class ValidMovement
{
    public Position from, to;
    private Piece piece;
    Board board;
    public ValidMovement(Position from, Position to, Piece piece, Board board)
    {
        this.from = from;
        this.to = to;
        this.piece = piece;
        this.board = board;
    }

    public void Apply()
    {
        piece.setPosition(to);
        board.Apply(this);
    } 

    public Color GetColor()
    {
        return piece.GetColor();
    }
}