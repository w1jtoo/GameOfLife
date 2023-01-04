using FluentAssertions;
using GameOfLife;

namespace GameOfLifeTests;

public class EngineTests
{
    private static readonly Cell ZeroCell = new(0, 0);

    private static GameOfLifeEngine Engine = new();

    [SetUp]
    public void SetUp()
    {
        Engine = new GameOfLifeEngine();
    }

    [Test]
    public void AddCell_ShouldAddZeroCell()
    {
        Engine.Add(new List<Cell> { ZeroCell });
        Engine.GetCells().Should().Contain(ZeroCell);
    }

    [Test]
    public void EqualCell_ShouldCompareUsingXAndY()
    {
        var newReferenceOnZeroCell = new Cell(0, 0);
        ZeroCell.Should().Be(newReferenceOnZeroCell);
    }

    [Test]
    public void ContainCell_ShouldAddCell()
    {
        Engine.Add(new List<Cell> { ZeroCell });
        Engine.Contains(ZeroCell).Should().BeTrue();
    }

    [Test]
    public void GetCountOfAliveNeighbours_ShouldNotCountSelfSell()
    {
        Engine.Add(new List<Cell> { ZeroCell });
        Engine.GetCountOfAliveNeighbours(ZeroCell).Should().Be(0);
    }

    [TestCase(0, 1)]
    [TestCase(1, 1)]
    [TestCase(1, 0)]
    [TestCase(-1, 1)]
    [TestCase(-1, -1)]
    [TestCase(1, -1)]
    [TestCase(0, -1)]
    [TestCase(-1, 0)]
    public void GetCountOfAliveNeighbours_ShouldNotCountSelfSell(int x, int y)
    {
        Engine.Add(new List<Cell> { ZeroCell });
        Engine.GetCountOfAliveNeighbours(new Cell(x, y)).Should().Be(1);
    }

    [Test]
    public void Update_ShouldDelete_AloneCells()
    {
        Engine.Add(new List<Cell> { ZeroCell });
        Engine.Update();
        Engine.GetCells().Should().BeEmpty();
    }

    [Test]
    public void Update_ShouldNotDelete_CellsWithThreeNeighbours()
    {
        Engine.Add(new List<Cell> { new(0, 0) });
        Engine.Add(new List<Cell> { new(0, 1) });
        Engine.Add(new List<Cell> { new(0, 2) });

        var cellWithThreeNeighbours = new List<Cell> { new(1, 1) };
        Engine.Add(cellWithThreeNeighbours);

        Engine.Update();

        Engine.GetCells().Should().Contain(cellWithThreeNeighbours);
    }

    [Test]
    public void Update_ShouldDelete_CellsWithMoreThanThreeNeighbours()
    {
        Engine.Add(new List<Cell> { new(0, 0) });
        Engine.Add(new List<Cell> { new(0, 1) });
        Engine.Add(new List<Cell> { new(0, 2) });
        Engine.Add(new List<Cell> { new(1, 2) });
        Engine.Add(new List<Cell> { new(1, 1) });

        Engine.Update();

        Engine.GetCells().Should().NotContain(new Cell(1, 1));
        Engine.GetCells().Should().NotContain(new Cell(0, 1));
    }

    [Test]
    public void GetNeighbours_ShouldReturnAllNearlyCells()
    {
        var neighbours = (new Cell(0, 0)).GetNeighbourCells();

        neighbours.Should().Contain(new Cell(-1, -1));
        neighbours.Should().Contain(new Cell(-1, 0));
        neighbours.Should().Contain(new Cell(-1, 1));

        neighbours.Should().Contain(new Cell(0, -1));
        neighbours.Should().Contain(new Cell(0, 1));

        neighbours.Should().Contain(new Cell(1, -1));
        neighbours.Should().Contain(new Cell(1, 0));
        neighbours.Should().Contain(new Cell(1, 1));
    }

    [TestCase(2, 2, 3, 3)]
    public void PeriodicalGetNeighbours_ShouldContainNeighboursOfBoarderSells(int x, int y, int mapWidth, int mapHeight)
    {
        var engine = new PeriodiñEngine(mapWidth,mapHeight);
        var cell = new Cell(2, 2);
        var neighbours = engine.GetNeighbours(cell);

        neighbours.Should().Contain(new Cell(2, 0));
        neighbours.Should().Contain(new Cell(0, 2));
        neighbours.Should().Contain(new Cell(0, 0));
    }
}