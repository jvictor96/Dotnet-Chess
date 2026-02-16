using NUnit.Framework;
using board;

public class KnightTest
{
    Match? match;

    [SetUp]
    public void Setup()
    {
        match = new Match();
        ValidMovement movement = match.buildMovementAttempt("b1c3").ToValidMovement(bypassValidation: true);
        movement.Apply();
        movement = match.buildMovementAttempt("g1g6").ToValidMovement(bypassValidation: true);
        movement.Apply();
    }

    [TestCase("c3a4")]
    [TestCase("c3b5")]
    [TestCase("c3d5")]
    [TestCase("c3b1")]
    public void TestKnightValidMovement(String movement)
    {
        Assert.That(match.GetBoard().GetPieceAt(Position.FromString(movement.Substring(2,2))), Is.Null);
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match, Is.Not.Null);
    }

    [TestCase("c3c4")]
    [TestCase("c3b3")]
    [TestCase("c3c5")]
    [TestCase("c3e3")]
    public void TestKnightInvalidMovement(String movement)
    {
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match, Is.Null);
    }

    [TestCase("g6f8")]
    [TestCase("g6h8")]
    [TestCase("g6e7")]
    public void TestKnightCaptures(String movement)
    {
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match, Is.Not.Null);
    }
}