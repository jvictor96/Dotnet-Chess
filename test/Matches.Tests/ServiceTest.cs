using DotnetChess.Matches.core;
using NUnit.Framework;

public class ServiceTeste
{
    MatchService matchService;
    IPlayerClient playerClient;

    [SetUp]
    public void Setup()
    {
        IMatchPersistence persistence = new InMemoryBoards();
        playerClient = new InMemoryPlayers(new List<Player> {
            new Player("jose", "jose@email.com"),
            new Player("eugenia", "eugenia@email.com")});
        matchService = new MatchService(persistence, playerClient);
        matchService.ChallengePlayer("jose", "eugenia", "a2a3");
    }

    [TestCase("e2e4")]
    [TestCase("d2d4")]
    [TestCase("b1c3")]
    public void GivenValidMovementThenChallenge(String movement)
    {
        Match? match = matchService.ChallengePlayer("jose", "eugenia", movement);
        Assert.NotNull(match);
        Assert.That(match.GetHistory().Count(), Is.EqualTo(1));
        
    }

    [TestCase("a1a3")]
    [TestCase("a2b3")]
    public void GivenInvalidMovementThenChallenge(String movement)
    {
        Match? match = matchService.ChallengePlayer("jose", "eugenia", movement);
        Assert.NotNull(match);
        Assert.That(match.GetHistory().Count(), Is.EqualTo(0));
    }

    [TestCase("marcia")]
    [TestCase("pedro")]
    public void GivenNonPlayerThenChallenge(String player)
    {
        Match? match = matchService.ChallengePlayer(player, "eugenia", "a2a3");
        Assert.Null(match);
        
    }

    [TestCase("jose")]
    [TestCase("eugenia")]
    public void GivenPlayerThenList(string player)
    {
        List<Match> matches = matchService.GetMatchesForPlayer(player).ToList();
        Assert.That(matches.Count(), Is.EqualTo(1));
        
    }

    [TestCase("pedro")]
    [TestCase("marcia")]
    public void GivenNoonPlayerThenList(string player)
    {
        List<Match> matches = matchService.GetMatchesForPlayer(player).ToList();
        Assert.That(matches.Count(), Is.EqualTo(0));
    }

    [Test]
    public void MakeMovementRightTurn()
    {
        Match match = matchService.GetMatchesForPlayer("eugenia").First();
        Match? movedMatch = matchService.MakeMove(match.Id, "eugenia", "e7e5");
        Assert.That(match.GetHistory().Count(), Is.EqualTo(2));
    }

    [Test]
    public void MakeMovementWrongTurn()
    {
        Match match = matchService.GetMatchesForPlayer("jose").First();
        Match? movedMatch = matchService.MakeMove(match.Id, "jose", "f2f3");
        Assert.Null(movedMatch);
    }

    [Test]
    public void ResignTest()
    {
        Match match = matchService.GetMatchesForPlayer("jose").First();
        Match? resignedMatch = matchService.ResignMatch(match.Id, "jose");
        Assert.That(resignedMatch.GetPlayers().winner, Is.EqualTo("eugenia"));
    }
}