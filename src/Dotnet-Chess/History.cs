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

    public bool RightTurn(Color color)
    {
        return (movements.Count % 2 == 1 && color == Color.WHITE) || (movements.Count % 2 == 0 && color == Color.BLACK);
    }
}