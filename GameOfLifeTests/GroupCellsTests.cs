using FluentAssertions;
using GameOfLife;

namespace GameOfLifeTests;

public class GroupCellsTests
{
    private static GameOfLifeEngine Engine = new();

    [SetUp]
    public void SetUp()
    {
        Engine = new GameOfLifeEngine();
    }

    [TestCase(0, 0)]
    [TestCase(21, 1)]
    [TestCase(41, 4)]
    [TestCase(64, 1)]
    [TestCase(88, 8)]
    public void GroupSquareTests(int x, int y)
    {
        Engine.Add(new GroupSquare(Engine, x, y));
        Engine.Contains(new Cell(x, y)).Should().Be(false);
        Engine.Contains(new Cell(x + 1, y + 1)).Should().Be(true);
        Engine.Contains(new Cell(x + 2, y + 1)).Should().Be(true);
        Engine.Contains(new Cell(x + 1, y + 2)).Should().Be(true);
        Engine.Contains(new Cell(x + 2, y + 2)).Should().Be(true);
    }

    [TestCase(0, 20)]
    [TestCase(21, 21)]
    [TestCase(41, 24)]
    [TestCase(64, 21)]
    [TestCase(88, 28)]
    public void GroupLoafTests(int x, int y)
    {
        Engine.Add(new GroupLoaf(Engine, x, y));
        Engine.Contains(new Cell(x + 1, y + 1)).Should().Be(false);
        Engine.Contains(new Cell(x + 1, y + 2)).Should().Be(true);
        Engine.Contains(new Cell(x + 2, y + 4)).Should().Be(true);
        Engine.Contains(new Cell(x + 1, y + 3)).Should().Be(true);
        Engine.Contains(new Cell(x + 3, y + 2)).Should().Be(true);
    }
}