using FluentAssertions;
using GameOfLife;

namespace GameOfLifeTests;

public class GameEndTests
{
    [Test]
    public void IsGameEnded_ShouldBeTrue_EmptyFieldByNoAliveCells()
    {
        var engine = new GameOfLifeEngine();
        for (var i = 0; i < 2; i++)
            engine.Update();
        engine.IsGameEnded.Should().BeTrue();
    }
    
    [Test]
    public void IsGameEnded_ShouldBeTrue_EmptyFieldByOneAliveCells()
    {
        var engine = new GameOfLifeEngine();
        engine.Add(new List<Cell>() {new Cell(0, 0)});
        for (var i = 0; i < 3; i++)
            engine.Update();
        engine.IsGameEnded.Should().BeTrue();
    }
    
    [Test]
    public void IsGameEnded_ShouldBeTrue_ConstantFieldByFourAliveCellsInSquare()
    {
        var engine = new GameOfLifeEngine();
        engine.Add(new List<Cell>()
        {
            new Cell(0, 0), 
            new Cell(0, 1),
            new Cell(1, 0),
            new Cell(1, 1)
        });
        for (var i = 0; i < 3; i++)
            engine.Update();
        engine.IsGameEnded.Should().BeTrue();
    }
    
    [Test]
    public void IsGameEnded_ShouldBeTrue_LoopedFieldByThreeAliveCellsInRow()
    {
        var engine = new GameOfLifeEngine();
        engine.Add(new List<Cell>()
        {
            new Cell(0, 0), 
            new Cell(0, 1),
            new Cell(0, 2)
        });
        for (var i = 0; i < 4; i++)
            engine.Update();
        engine.IsGameEnded.Should().BeTrue();
    }
    
    [Test]
    public void IsGameEnded_ShouldBeFalse_GliderFormWithHundredUpdates()
    {
        var engine = new GameOfLifeEngine();
        engine.Add(new List<Cell>()
        {
            new Cell(0, 0), 
            new Cell(0, 1),
            new Cell(0, 2),
            new Cell(1, 2),
            new Cell(2, 1)
        });
        for (var i = 0; i < 100; i++)
            engine.Update();
        engine.IsGameEnded.Should().BeFalse();
    }
}