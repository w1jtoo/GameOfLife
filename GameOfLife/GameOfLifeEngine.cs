namespace GameOfLife;

public class GameOfLifeEngine
{
    private readonly HashSet<Cell> Cells = new();

    public void Update()
    {
        var cellsForDeleting = new List<Cell>();
        var newCells = new List<Cell>();

        foreach (var cell in Cells)
        {
            if (GetCountOfAliveNeighbours(cell) is < 2 or > 3)
                cellsForDeleting.Add(cell);

            foreach (var neighbour in GetNeighbours(cell))
                if (GetCountOfAliveNeighbours(neighbour) == 3)
                    newCells.Add(neighbour);
        }

        foreach (var cellForDeleting in cellsForDeleting) Remove(cellForDeleting);
        Add(newCells);
    }

    public int GetCountOfAliveNeighbours(Cell cell)
    {
        var count = 0;
        foreach (var neighbour in GetNeighbours(cell))
            if (Contains(neighbour))
                count++;

        return count;
    }

    protected virtual List<Cell> GetNeighbours(Cell cell)
    {
        return cell.GetNeighbourCells();
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

public class PeriodicEngine : GameOfLifeEngine
{
    public int MapWidth { get; private set; }
    public int MapHeight { get; private set; }
    public PeriodicEngine(int mapWidth, int mapHeight)
    {
        MapWidth = mapWidth;
        MapHeight = mapHeight;
    }
    protected override List<Cell> GetNeighbours(Cell cell)
    {
        var neighbours = new List<Cell>();
        var x = cell.X;
        var y = cell.Y;
        for (var xd = -1; xd <= 1; xd++)
        for (var yd = -1; yd <= 1; yd++)
        {
            if (xd == 0 && yd == 0)
                    continue;
            var cellX = x + xd;
            var cellY = y + yd;
            if(cellX >= MapWidth)
                cellX = 0;
            if (cellY >= MapHeight)
                cellY = 0;
            if(cellX < 0)
                cellX = MapWidth - 1;
            if (cellY < 0)
                cellY = MapHeight - 1;
            neighbours.Add(new Cell(cellX, cellY));
        }

        return neighbours;
    }
}