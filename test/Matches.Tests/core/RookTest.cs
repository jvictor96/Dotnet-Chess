using NUnit.Framework;
using board;

public class RookTest
{
    Match? match;

    [SetUp]
    public void Setup()
    {
        match = new Match();
        ValidMovement movement = match.buildMovementAttempt("a1d4").ToValidMovement(bypassValidation: true);
        movement.Apply();
        movement = match.buildMovementAttempt("h1e4").ToValidMovement(bypassValidation: true);
        movement.Apply();
    }

    [TestCase("e4f4")]
    [TestCase("d4c4")]
    [TestCase("d4d3")]
    [TestCase("d4d5")]
    public void TestRookValidMovement(String movement)
    {
        Assert.That(match.GetBoard().GetPieceAt(Position.FromString(movement.Substring(2,2))), Is.Null);
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match, Is.Not.Null);
    }

    [TestCase("e4f5")]
    [TestCase("d4c5")]
    [TestCase("d4e5")]
    [TestCase("d4a3")]
    public void TestRookInvalidMovement(String movement)
    {
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match, Is.Null);
    }

    [TestCase("e4d4")]
    [TestCase("d4f4")]
    [TestCase("d4d8")]
    [TestCase("e4a4")]
    [TestCase("e4e2")]
    public void TestRookBlockedMovement(String movement)
    {
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match, Is.Null);
    }

    [TestCase("e4e7")]
    [TestCase("d4d7")]
    public void TestRookBCaptures(String movement)
    {
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match, Is.Not.Null);
    }
}