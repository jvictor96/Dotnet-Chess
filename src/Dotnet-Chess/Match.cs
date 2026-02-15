namespace board;

public class Match
{
    private History history;
    private Board board;
    private Players players;
    public Match(Players? players = null)
    {
        history = new History();
        board = new Board();
        this.players = players ?? new Players(null, null, null);
    }
    public Match(Players players, Board board, History history)
    {
        this.history = history;
        this.board = board;
        this.players = players;
    }

    public Board GetBoard()
    {
        return board;
    }

    public Players GetPlayers()
    {
        return players;
    }

    public MovementAttempt buildMovementAttempt(String movement)
    {
        return MovementAttempt.FromString(movement, board);
    }

    public Match? move(MovementAttempt movementAttempt)
    {
        ValidMovement? validMovement = movementAttempt.ToValidMovement();
        if(validMovement == null) return null;
        Color color = validMovement.GetColor();
        if(history.WrongTurn(color)) return null;
        history.AddMove(validMovement);
        validMovement.Apply();
        return this;
    }

}