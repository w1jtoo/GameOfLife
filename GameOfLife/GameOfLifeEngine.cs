namespace GameOfLife;

public class GameOfLifeEngine
{
    private readonly HashSet<Cell> Cells = new();

    public void Update(int mapWidth, int mapHeight)
    {
        var cellsForDeleting = new List<Cell>();
        var newCells = new List<Cell>();

        foreach (var cell in Cells)
        {
            if (GetCountOfAliveNeighbours(cell, mapWidth, mapHeight) is < 2 or > 3)
                cellsForDeleting.Add(cell);

            foreach (var neighbour in cell.GetNeighbourCells(mapWidth, mapHeight))
                if (GetCountOfAliveNeighbours(neighbour, mapWidth, mapHeight) == 3)
                    newCells.Add(neighbour);
        }

        foreach (var cellForDeleting in cellsForDeleting) Remove(cellForDeleting);
        Add(newCells);
    }

    public int GetCountOfAliveNeighbours(Cell cell, int mapWidth, int mapHeight)
    {
        var count = 0;
        foreach (var neighbour in cell.GetNeighbourCells(mapWidth, mapHeight))
            if (Contains(neighbour))
                count++;

        return count;
    }

    public void Add(List<Cell> cells)
    {
        foreach (var cell in cells) Cells.Add(cell);
    }

    public bool Contains(Cell cell)
    {
        return Cells.Contains(cell);
    }

    public List<Cell> GetCells()
    {
        return Cells.ToList();
    }

    public void Remove(Cell cell)
    {
        Cells.Remove(cell);
    }
}