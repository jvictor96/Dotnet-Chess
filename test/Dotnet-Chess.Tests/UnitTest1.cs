using NUnit.Framework;
using board;

public class Tests
{
    Board board;

    [SetUp]
    public void Setup()
    {
        board = new Board();
    }

    [Test]
    public void Test1()
    {
        Assert.That(board.pieces, Has.Count.EqualTo(32));
        Assert.Pass();
    }
}