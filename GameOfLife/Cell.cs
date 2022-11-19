namespace GameOfLife;

public class Cell
{
    public readonly int X;
    public readonly int Y;

    public Cell(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Cell cell)
            return X == cell.X && Y == cell.Y;
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public List<Cell> GetNeighbourCells()
    {
        var neighbours = new List<Cell>();

        for (var xd = -1; xd <= 1; xd++)
        for (var yd = -1; yd <= 1; yd++)
        {
            if (xd == 0 && yd == 0)
                continue;
            neighbours.Add(new Cell(X + xd, Y + yd));
        }

        return neighbours;
    }
}