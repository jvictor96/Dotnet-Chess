using NUnit.Framework;
using board;

public class GeneralTest
{
    Match match;

    [SetUp]
    public void Setup()
    {
        match = new Match();
    }

    [TestCase("g2g3", "g7g6", "a7a6")]
    [TestCase("g2g3", "a2a3")]
    [TestCase("g7g6")]
    public void TestBadTurn(params string[] movements)
    {
        foreach (var movement in movements)
        {
            match = match.move(match.buildMovementAttempt(movement));
        }
        Assert.That(match, Is.Null);
    }

    [TestCase("g2g3", "g7g6", "a2a3")]
    [TestCase("g2g3", "g7g6", "a2a3", "b8c6")]
    public void TestGoodTurn(params string[] movements)
    {
        foreach (var movement in movements)
        {
            match = match.move(match.buildMovementAttempt(movement));
        }
        Assert.That(match, Is.Not.Null);
    }
}