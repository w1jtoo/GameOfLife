using FluentAssertions;
using GameOfLife;

namespace GameOfLifeTests;
public class PeriodicEngineTests
{
    [TestCase(3, 3)]
    [TestCase(4, 4)]
    [TestCase(5, 3)]
    [TestCase(4, 6)]
    public void PeriodicalGetNeighbours_ShouldContainNeighboursOfRightBottomBoarderSells(int mapWidth, int mapHeight)
    {
        var engine = new PeriodicEngine(mapWidth, mapHeight);
        var x = mapWidth - 1;
        var y = mapHeight - 1;
        var neighboursOfRightBottom = engine.GetNeighbours(new Cell(x, y));

        neighboursOfRightBottom.Should().Contain(new Cell(y, 0));
        neighboursOfRightBottom.Should().Contain(new Cell(0, x));
        neighboursOfRightBottom.Should().Contain(new Cell(0, 0));
    }

    [TestCase(3, 3)]
    [TestCase(5, 3)]
    [TestCase(4, 6)]
    public void PeriodicalGetNeighbours_ShouldContainNeighboursOfLeftTopBoarderSells(int mapWidth, int mapHeight)
    {
        var engine = new PeriodicEngine(mapWidth, mapHeight);
        var x = mapWidth - 1;
        var y = mapHeight - 1;
        var neighboursOfLeftTop = engine.GetNeighbours(new Cell(0, 0));

        neighboursOfLeftTop.Should().Contain(new Cell(y, 0));
        neighboursOfLeftTop.Should().Contain(new Cell(0, x));
        neighboursOfLeftTop.Should().Contain(new Cell(y, x));
    }
}