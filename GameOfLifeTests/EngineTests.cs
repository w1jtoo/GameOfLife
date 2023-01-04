using System.Collections.Generic;
using System.Drawing;
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
    public void GetBack_OnlyOneIteration()
    {
        var cells = new List<Cell> {new(1, 0), new(1, 1), new(1, 2), new(8, 5), new(8, 6), 
                                    new(8, 7), new(5, 5), new(5, 6), new(6, 6), new(6, 7)}; 
        Engine.Add(cells);
        
        Engine.Update();
        Engine.GetBack();
        cells.Should().BeEquivalentTo(Engine.GetCells());
    }

    [Test]
    public void GetBack_FewIterations()
    {
        var cells = new List<Cell> {new(1, 0), new(1, 1), new(1, 2), new(8, 5), new(8, 6), 
                                    new(8, 7), new(5, 5), new(5, 6), new(6, 6), new(6, 7)}; 
        Engine.Add(cells);
        for(var iterations = 2; iterations < 30; iterations++)
        {
            for (var i = 0; i < iterations; i++) 
                Engine.Update();
            for (var i = 0; i < iterations; i++) 
                Engine.GetBack();
            cells.Should().BeEquivalentTo(Engine.GetCells());
        }
    }

    [Test]
    public void GetBack_WhenZeroIterations()
    {
        var cells = new List<Cell> {new(1, 0), new(1, 1), new(1, 2), new(8, 5), new(8, 6), 
                                    new(8, 7), new(5, 5), new(5, 6), new(6, 6), new(6, 7)}; 
        Engine.Add(cells);
        Engine.GetBack();
        cells.Should().BeEquivalentTo(Engine.GetCells());
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

    [TestCase(0, 0, 0)]
    [TestCase(10, 10, 10)]
    [TestCase(50, 50, 50)]
    [TestCase(100, 100, 100)]
    [TestCase(200, 200, 200)]
    public void EqualCell_ShouldCompareUsingXAndYAndColor(int r, int g, int b)
    {
        Engine.Add(new List<Cell> { new(0, 0, r, g, b) });
        Engine.Contains(new Cell(0, 0, r, g, b)).Should().Be(true);
    }

    [Test]
    public void CheckCell_DefaultColor()
    {
        Engine.Add(new List<Cell> { new (0,0)});
        Engine.Contains(new Cell(0, 0, Color.White)).Should().Be(true);
    }
}