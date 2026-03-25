using NUnit.Framework;
namespace DotnetChess.Matches.core;
public class CheckTest
{
    Match? pastor, kingInCheck, blackBishopOut, blackBishopOutAndKingOpen;

    [SetUp]
    public void Setup()
    {
        pastor = new Match(players: new Players("jose", "maria", ""));
        ValidMovement movement = pastor.buildMovementAttempt("d1f3").ToValidMovement(bypassValidation: true);
        movement.Apply();
        movement = pastor.buildMovementAttempt("f1c4").ToValidMovement(bypassValidation: true);
        movement.Apply();
        kingInCheck = new Match();
        movement = kingInCheck.buildMovementAttempt("d2d4").ToValidMovement(bypassValidation: true);
        movement.Apply();
        movement = kingInCheck.buildMovementAttempt("e2e4").ToValidMovement(bypassValidation: true);
        movement.Apply();
        movement = kingInCheck.buildMovementAttempt("f8b4").ToValidMovement(bypassValidation: true);
        movement.Apply();
        blackBishopOut = new Match();
        movement = blackBishopOut.buildMovementAttempt("f8b4").ToValidMovement(bypassValidation: true);
        movement.Apply();
        blackBishopOutAndKingOpen = new Match();
        movement = blackBishopOutAndKingOpen.buildMovementAttempt("e2e4").ToValidMovement(bypassValidation: true);
        movement.Apply();
        movement = blackBishopOutAndKingOpen.buildMovementAttempt("c8g4").ToValidMovement(bypassValidation: true);
        movement.Apply();
    }

    [Test]
    public void TestKingMovesOutOfCheck()
    {
        kingInCheck = kingInCheck.move(kingInCheck.buildMovementAttempt("e1e2"));
        Assert.That(kingInCheck, Is.Not.Null);
    }

    [Test]
    public void TestKingMovesStillInCheck()
    {
        kingInCheck = kingInCheck.move(kingInCheck.buildMovementAttempt("e1d2"));
        Assert.That(kingInCheck, Is.Null);
    }

    [Test]
    public void CheckIsBlockedByQueen()
    {
        kingInCheck = kingInCheck.move(kingInCheck.buildMovementAttempt("d1d2"));
        Assert.That(kingInCheck, Is.Not.Null);
    }

    [Test]
    public void QueenMovesButStillInCheck()
    {
        kingInCheck = kingInCheck.move(kingInCheck.buildMovementAttempt("d1d3"));
        Assert.That(kingInCheck, Is.Null);
    }

    [Test]
    public void TestPawnMovesButPutsKingInCheck()
    {
        blackBishopOut = blackBishopOut.move(blackBishopOut.buildMovementAttempt("d2d3"));
        Assert.That(blackBishopOut, Is.Null);
    }

    [Test]
    public void TestKingGoesToCheck()
    {
        blackBishopOutAndKingOpen = blackBishopOutAndKingOpen.move(blackBishopOutAndKingOpen.buildMovementAttempt("d1d2"));
        Assert.That(blackBishopOutAndKingOpen, Is.Null);
    }

    [Test]
    public void TestCheckMate()
    {
        pastor = pastor.move(pastor.buildMovementAttempt("f3f7"));
        Assert.That(pastor, Is.Not.Null);
        Assert.That(pastor.GetPlayers().winner, Is.EqualTo("jose"));
    }
}