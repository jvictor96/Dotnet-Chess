using NUnit.Framework;
using board;

public class PawnTest
{
    Match? match;

    [SetUp]
    public void Setup()
    {
        match = new Match();
        ValidMovement movement = match.buildMovementAttempt("b7b3").ToValidMovement(bypassValidation: true);
        movement.Apply();
        movement = match.buildMovementAttempt("g2g3").ToValidMovement(bypassValidation: true);
        movement.Apply();
        movement = match.buildMovementAttempt("d2d6").ToValidMovement(bypassValidation: true);
        movement.Apply();
    }

    [TestCase("a2a3")]
    [TestCase("a2a4")]
    [TestCase("c2c3")]
    [TestCase("c2c4")]
    [TestCase("g3g4")]
    public void TestPawnValidMovement(String movement)
    {
        Assert.That(match.GetBoard().GetPieceAt(Position.FromString(movement.Substring(2,2))), Is.Null);
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match, Is.Not.Null);
    }

    [TestCase("a2a5")]
    [TestCase("c2d3")]
    [TestCase("d6e6")]
    [TestCase("g3g5")]
    public void TestPawnInvalidMovement(String movement)
    {
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match, Is.Null);
    }

    [TestCase("b2b4")]
    public void TestPawnBlockedMovement(String movement)
    {
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match, Is.Null);
    }

    [TestCase("a2b3")]
    [TestCase("d6e7")]
    public void TestPawnCaptures(String movement)
    {
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match.GetBoard().GetPieceAt(Position.FromString(movement.Substring(2,2))).GetSymbol(), Is.EqualTo("P"));
    }
}