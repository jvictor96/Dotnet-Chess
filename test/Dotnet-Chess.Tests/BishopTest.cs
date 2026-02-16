using NUnit.Framework;
using board;

public class BishopTest
{
    Match? match;

    [SetUp]
    public void Setup()
    {
        match = new Match();
        ValidMovement movement = match.buildMovementAttempt("c1d4").ToValidMovement(bypassValidation: true);
        movement.Apply();
        movement = match.buildMovementAttempt("f1e4").ToValidMovement(bypassValidation: true);
        movement.Apply();
    }

    [TestCase("e4f5")]
    [TestCase("d4c5")]
    [TestCase("d4e3")]
    [TestCase("d4e5")]
    public void TestBishopValidMovement(String movement)
    {
        Assert.That(match.GetBoard().GetPieceAt(Position.FromString(movement.Substring(2,2))), Is.Null);
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match, Is.Not.Null);
    }

    [TestCase("e4f4")]
    [TestCase("d4c4")]
    [TestCase("d4d5")]
    [TestCase("d4a3")]
    public void TestBishopInvalidMovement(String movement)
    {
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match, Is.Null);
    }

    [TestCase("d4h8")]
    [TestCase("e4a8")]
    [TestCase("e4c2")]
    public void TestBishopBlockedMovement(String movement)
    {
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match, Is.Null);
    }

    [TestCase("e4b7")]
    [TestCase("d4g7")]
    public void TestBishopCaptures(String movement)
    {
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match.GetBoard().GetPieceAt(Position.FromString(movement.Substring(2,2))).GetSymbol(), Is.EqualTo("B"));
    }
}