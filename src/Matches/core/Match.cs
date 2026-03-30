namespace DotnetChess.Matches.core;

public class Match
{
    private History history;
    private Board board;
    private Players players;
    public Guid Id { get; set; }
    public Match(Players? players = null)
    {
        Id = Guid.NewGuid();
        history = new History();
        board = new Board();
        this.players = players ?? new Players("null", "null", "null");
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

    public History GetHistory()
    {
        return history;
    }

    public MovementAttempt buildMovementAttempt(String movement)
    {
        return MovementAttempt.FromString(movement, board);
    }

    public bool IsRightTurnForPlayer(string player)
    {
        Color color = player == players.white ? Color.WHITE : Color.BLACK;
        return ! history.WrongTurn(color);
    }

    public Match? move(MovementAttempt movementAttempt)
    {
        ValidMovement? validMovement = movementAttempt.ToValidMovement();
        if(validMovement == null) return null;
        Color color = validMovement.GetColor();
        if(history.WrongTurn(color)) return null;
        history.AddMove(validMovement);
        validMovement.Apply();
        Color opponentColor = color == Color.WHITE ? Color.BLACK : Color.WHITE;
        bool checkmate = board.IsPlayerInCheck(opponentColor) &&
            board.IsItMate(opponentColor) &&
                SetWinner(color == Color.BLACK ? players.black : players.white);
        return this;
    }

    public bool SetWinner(string winner)
    {
        players.winner = winner;
        return true;
    }

    public void Resign(string player)
    {
        SetWinner(player == players.white ? players.black : players.white);
    }
}