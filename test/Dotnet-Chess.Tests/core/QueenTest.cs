using NUnit.Framework;
using board;

public class QueenTest
{
    Match? match;

    [SetUp]
    public void Setup()
    {
        match = new Match();
        ValidMovement movement = match.buildMovementAttempt("d1d4").ToValidMovement(bypassValidation: true);
        movement.Apply();
    }

    [TestCase("d4d3")]
    [TestCase("d4d5")]
    [TestCase("d4c4")]
    [TestCase("d4c5")]
    [TestCase("d4e3")]
    [TestCase("d4e5")]
    public void TestQueenValidMovement(String movement)
    {
        Assert.That(match.GetBoard().GetPieceAt(Position.FromString(movement.Substring(2,2))), Is.Null);
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match, Is.Not.Null);
    }

    [TestCase("d4g5")]
    [TestCase("d4g3")]
    [TestCase("d4b5")]
    [TestCase("d4b3")]
    public void TestQueenInvalidMovement(String movement)
    {
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match, Is.Null);
    }

    [TestCase("d4h8")]
    [TestCase("d4d8")]
    [TestCase("d4d2")]
    [TestCase("d4d1")]
    [TestCase("d4a1")]
    public void TestQueenBlockedMovement(String movement)
    {
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match, Is.Null);
    }

    [TestCase("d4g7")]
    [TestCase("d4a7")]
    [TestCase("d4d7")]
    public void TestQueenCaptures(String movement)
    {
        match = match.move(match.buildMovementAttempt(movement));
        Assert.That(match.GetBoard().GetPieceAt(Position.FromString(movement.Substring(2,2))).GetSymbol(), Is.EqualTo("Q"));
    }
}