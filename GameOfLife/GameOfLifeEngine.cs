namespace GameOfLife;

public class GameOfLifeEngine
{
    private readonly HashSet<Cell> Cells = new();
    private readonly List<int> HistoryConfigurationHashes = new();
    public bool IsGameEnded { get; private set; }

    public GameOfLifeEngine()
    {
        IsGameEnded = false;
    }
    public void Update()
    {
        var hashCode = GetGameHashCode();
        if (HistoryConfigurationHashes.Contains(hashCode))
            IsGameEnded = true;
        else
            HistoryConfigurationHashes.Add(hashCode);

        var cellsForDeleting = new List<Cell>();
        var newCells = new List<Cell>();

        foreach (var cell in Cells)
        {
            if (GetCountOfAliveNeighbours(cell) is < 2 or > 3)
                cellsForDeleting.Add(cell);

            foreach (var neighbour in cell.GetNeighbourCells())
                if (GetCountOfAliveNeighbours(neighbour) == 3)
                    newCells.Add(neighbour);
        }

        foreach (var cellForDeleting in cellsForDeleting) Remove(cellForDeleting);
        Add(newCells);
    }

    public int GetCountOfAliveNeighbours(Cell cell)
    {
        var count = 0;
        foreach (var neighbour in cell.GetNeighbourCells())
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
    
    public int GetGameHashCode()
    {
        var hashCode = Cells.Count;
        foreach (Cell cell in Cells)
        {
            hashCode = unchecked(hashCode * 314159 + cell.GetHashCode());
        }

        return hashCode;
    }
}