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

    public List<Cell> GetNeighbourCells(int mapWidth, int mapHeight)
    {
        var neighbours = new List<Cell>();

        for (var xd = -1; xd <= 1; xd++)
            for (var yd = -1; yd <= 1; yd++)
            {
                if (xd == 0 && yd == 0)
                    continue;
                int cellX = X + xd;
                int cellY = Y + yd;
                if(cellX >= mapWidth)
                    cellX = 0;
                if (cellY >= mapHeight)
                    cellY = 0;
                if(cellX < 0)
                    cellX = mapWidth - 1;
                if (cellY < 0)
                    cellY = mapHeight - 1;
                neighbours.Add(new Cell(cellX, cellY));
            }

        return neighbours;
    }
}