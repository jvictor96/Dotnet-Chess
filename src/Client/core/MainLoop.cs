using board;
public class MainLoop
{
    private readonly InputRouter inputRouter;
    private readonly IKeyboard keyboard;
    private readonly IGameViewer gameView;
    private Match? match;

    public MainLoop(IKeyboard keyboard, IGameViewer gameView, IPlayerClient playerClient, IMatchClient matchClient)
    {
        this.keyboard = keyboard;
        this.gameView = gameView;
        this.inputRouter = new InputRouter(playerClient, matchClient);
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Available commands:");
            inputRouter.GetAvailableCommands().ForEach(cmd => Console.Write($" {cmd}"));
            Console.WriteLine();
            string input = keyboard.Read("Enter command: ");

            inputRouter.RouteInput(input);
            if (match != null)
                gameView.DisplayBoard(match.GetBoard());
        }
    }
}