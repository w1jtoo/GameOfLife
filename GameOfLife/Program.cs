using GameOfLife;

var engine = new GameOfLifeEngine();

engine.Add(new List<Cell> { new(1, 0) });
engine.Add(new List<Cell> { new(1, 1) });
engine.Add(new List<Cell> { new(1, 2) });

engine.Add(new List<Cell> { new(8, 5) });
engine.Add(new List<Cell> { new(8, 6) });
engine.Add(new List<Cell> { new(8, 7) });

engine.Add(new List<Cell> { new(5, 5) });
engine.Add(new List<Cell> { new(5, 6) });
engine.Add(new List<Cell> { new(5, 6) });
engine.Add(new List<Cell> { new(6, 6) });
engine.Add(new List<Cell> { new(6, 7) });


const int horizontalSize = 20;
const int verticalSize = 10;
while (!engine.IsGameEnded)
{
    var horizontalBorder = new string(Enumerable.Repeat('#', horizontalSize + 2).ToArray());
    Console.WriteLine(horizontalBorder);
    for (var x = 0; x < verticalSize; x++)
    {
        Console.Write('#');
        for (var y = 0; y < horizontalSize; y++) Console.Write(engine.Contains(new Cell(x, y)) ? 'o' : '.');
        Console.Write('#');
        Console.WriteLine();
    }

    Console.WriteLine(horizontalBorder);
    engine.Update();
    Thread.Sleep(800);
    Console.Clear();
}