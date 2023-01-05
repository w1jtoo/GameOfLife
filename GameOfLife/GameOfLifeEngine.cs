﻿using System.Collections.Immutable;

namespace GameOfLife;

public class GameOfLifeEngine
{
    private readonly HashSet<Cell> Cells = new();
    private readonly List<int> HistoryConfigurationHashes = new();
    private Stack<ImmutableHashSet<Cell>> CellIterations = new();
    public bool JourneyModeFlag = true;
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

        var oldCells = new HashSet<Cell>();
        foreach (var cell in Cells) oldCells.Add(cell);
        if (JourneyModeFlag) CellIterations.Push(oldCells.ToImmutableHashSet());

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

    public void GetBack()
    {
        if (CellIterations.Count() == 0) return;
        var lastEngine = CellIterations.Pop();
        Cells.Clear();
        Add(lastEngine.ToList());
    }

    public int GetCountOfAliveNeighbours(Cell cell)
    {
        var count = 0;
        foreach (var neighbour in cell.GetNeighbourCells())
            if (Contains(neighbour))
                count++;

        return count;
    }

    public int GetCountOfIterations()
    {
        return CellIterations.Count();
    }

    public void Add(List<Cell> cells)
    {
        foreach (var cell in cells) Cells.Add(cell);
    }

    public void Add(params Cell[] cells)
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

    private void Remove(Cell cell)
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