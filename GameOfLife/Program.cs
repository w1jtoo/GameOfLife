using GameOfLife;

var engine = new GameOfLifeEngine();

engine.Add(new List<Cell> { new(1, 2) });
engine.Add(new List<Cell> { new(3, 1) });
engine.Add(new List<Cell> { new(2, 3) });
engine.Add(new List<Cell> { new(3, 2) });
engine.Add(new List<Cell> { new(3, 3) });




const int horizontalSize = 10;
const int verticalSize = 10;
while (true)
{
    var horizontalBorder = new string(Enumerable.Repeat('#', horizontalSize + 2).ToArray());
    Console.WriteLine(horizontalBorder);
    for (var x = 0; x < verticalSize; x++)
    {
        Console.Write('#');
        for (var y = 0; y < horizontalSize; y++)
            Console.Write(engine.Contains(new Cell(x, y)) ? 'o' : '.');
        Console.Write('#');
        Console.WriteLine();
    }

    Console.WriteLine(horizontalBorder);
    engine.Update(horizontalSize, verticalSize);
    Thread.Sleep(800);
    Console.Clear();
}