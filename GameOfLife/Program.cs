using GameOfLife;

var engine = new PeriodicEngine(10,10);

engine.Add(new List<Cell> { new(5, 3) });
engine.Add(new List<Cell> { new(4, 3) });
engine.Add(new List<Cell> { new(4, 4) });
engine.Add(new List<Cell> { new(3, 4) });
engine.Add(new List<Cell> { new(3, 2) });


const int horizontalSize = 10;
const int verticalSize = 10;
while (true)
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