public class ChallengeCommand : KeyboardHandler
{
    private readonly GameMachine gameMachine;

    public ChallengeCommand(GameMachine gameMachine)
    {
        this.gameMachine = gameMachine;
    }

    public ShellMachine.State HandleKeyboard()
    {
        gameMachine.Run(GameMachine.State.YourTurn);
        return ShellMachine.State.Listing;
    }
}