using NUnit.Framework;
using board;

public class IntegrationTest
{
    Match? match;
    Keyboard keyboard;

    [SetUp]
    public void Setup()
    {
        string user = "testUser";
        IMessageCrossingFactory factory = new InMemoryMessageCrossingFactory();
        IMatchPersistence persistence = new InMemoryBoards();
        IGameViewer viewer = new NoViewAdapter();
        List<string> messageBus = new List<string>();
        keyboard = new InMemoryKeyboard();
        CommandReader reader = new CommandReader(keyboard);
        ListCommand listCommand = new ListCommand(persistence);
        ChangeCommand changeCommand = new ChangeCommand(viewer, persistence, keyboard, user, messageBus, factory);
        PlayCommand playCommand = new PlayCommand(persistence, keyboard, messageBus);
        ResignCommand resignCommand = new ResignCommand(keyboard, persistence, user);
        ChallengeCommand challengeCommand = new ChallengeCommand(keyboard, persistence, user);
        ShellMachine machine = new ShellMachine(new Dictionary<ShellMachine.State, KeyboardHandler>
        {
            { ShellMachine.State.Reading, reader },
            { ShellMachine.State.Listing, listCommand },
            { ShellMachine.State.Changing, changeCommand },
            { ShellMachine.State.Playing, playCommand },
            { ShellMachine.State.Resigning, resignCommand },
            { ShellMachine.State.Challenging, challengeCommand }
        });
    }

    public void TestBishopValidMovement()
    {
    }
}