using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameOfLife;

public class Cell
{
    public readonly int X;
    public readonly int Y;
    public readonly Color Color;

    private readonly Color _defaultColor = Color.White;

    public Cell(int x, int y)
    {
        X = x;
        Y = y;
        Color = _defaultColor;
    }

    public Cell(int x, int y, Color color)
    {
        X = x;
        Y = y;
        Color = color;
    }

    public Cell(int x, int y, int r, int g, int b)
    {
        X = x;
        Y = y;
        Color = Color.FromArgb(red: r, green: g, blue: b);
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