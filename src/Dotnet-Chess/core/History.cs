public class History
{
    private List<ValidMovement> movements;

    public History()
    {
        movements = new List<ValidMovement>();
    }

    public History(List<ValidMovement> movements)
    {
        this.movements = movements;
    }

    public bool WrongTurn(Color color)
    {
        return (movements.Count % 2 == 1 && color == Color.WHITE) || (movements.Count % 2 == 0 && color == Color.BLACK);
    }

    public void AddMove(ValidMovement movement)
    {
        movements.Add(movement);
    }
}