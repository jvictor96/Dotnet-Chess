public class MainLoop
{
    private readonly InputRouter inputRouter;
    private readonly IKeyboard keyboard;
    private readonly IGameView gameView;

    public MainLoop(IKeyboard keyboard, IGameView gameView, IPlayerClient playerClient, IMatchClient matchClient)
    {
        this.keyboard = keyboard;
        this.gameView = gameView;
        this.inputRouter = new InputRouter(playerClient, matchClient);
    }

    public void Run()
    {
        while (true)
        {
            string input = keyboard.Read("Enter command: ");
            inputRouter.RouteInput(input);
            gameView.Display();
        }
    }
}