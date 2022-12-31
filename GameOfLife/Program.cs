using System.Runtime.Intrinsics.X86;
using GameOfLife;

class Program
{
    static GameOfLifeEngine engine = new GameOfLifeEngine();
    const int horizontalSize = 20;
    const int verticalSize = 10;
    public static (int, int) Coordinates
    {
        set
        {
            if (value.Item2 >= horizontalSize || value.Item2 < 0 || value.Item1 < 0 || value.Item1 >= verticalSize)
                throw new Exception();
            engine.Add(new List<Cell> { new(value.Item1, value.Item2) });
        }
    }

    private static void Main()
    {
        Coordinates = (1, 0);
        Coordinates = (1, 1);
        Coordinates = (1, 2);
        Coordinates = (8, 5);
        Coordinates = (8, 6);
        Coordinates = (8, 7);
        Coordinates = (5, 5);
        Coordinates = (5, 6);
        Coordinates = (6, 6);
        Coordinates = (6, 7);
        Coordinates = (1, 0);
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
    }
}