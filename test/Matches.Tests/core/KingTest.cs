using NUnit.Framework;
using board;

public class KingTest
{
    Match? match;

    [SetUp]
    public void Setup()
    {
        match = new Match();
        ValidMovement movement = match.buildMovementAttempt("e1d4").ToValidMovement(bypassValidation: true);
        movement.Apply();
        movement = match.buildMovementAttempt("e7e5").ToValidMovement(bypassValidation: true);
        movement.Apply();
        movement = match.buildMovementAttempt("e2e3").ToValidMovement(bypassValidation: true);
        movement.Apply();
    }

    [TestCase("d4d3")]
    [TestCase("d4d5")]
    [TestCase("d4c4")]
    [TestCase("d4e4")]
    [TestCase("d4c4")]
    public void TestKingValidMovement(String movement)
    {
        Assert.That(match.GetBoard().GetPieceAt(Position.FromString(movement.Substring(2,2))), Is.Null);
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match, Is.Not.Null);
    }

    [TestCase("d4a7")]
    [TestCase("d4b5")]
    [TestCase("d4b3")]
    public void TestKingInvalidMovement(String movement)
    {
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match, Is.Null);
    }

    [TestCase("d4e3")]
    public void TestKingBlockedMovement(String movement)
    {
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match, Is.Null);
    }

    [TestCase("d4e5")]
    public void TestKingCaptures(String movement)
    {
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match.GetBoard().GetPieceAt(Position.FromString(movement.Substring(2,2))).GetSymbol(), Is.EqualTo("K"));
    }
}