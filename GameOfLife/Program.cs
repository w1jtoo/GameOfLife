using System.Runtime.Intrinsics.X86;
using GameOfLife;

class Program
{
    const int horizontalSize = 20;
    const int verticalSize = 10;

    private static void Main()
    {
        var engine = new GameOfLifeEngine();

        var cells = new List<Cell> {new(1, 0), new(1, 1), new(1, 2), new(8, 5), new(8, 6),
                                    new(8, 7), new(5, 5), new(5, 6), new(6, 6), new(6, 7)};
        engine.Add(cells);

        ConsoleKeyInfo key;

        Console.WriteLine("Hello!");
        Console.WriteLine("Welcome to \"Game Of Life\"!\n");
        Console.WriteLine("Press 'Enter' if you want to look at the game journey step-by-step");
        Console.WriteLine("Press any key if you just want to look at the game");
        key = Console.ReadKey();
        engine.JourneyModeFlag = (key.Key == ConsoleKey.Enter);

        while (true)
        {
            Console.Clear();
            if (engine.JourneyModeFlag)
            {
                var iterations = engine.GetCountOfIterations();
                Console.Write("After ");
                Console.Write(iterations);
                Console.WriteLine(" iteration(s):");
                printEngine(engine);
                Console.WriteLine("Press 'Right' to go to the next iteration");
                Console.WriteLine("Press 'Left' to go to the previous iteration");
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.RightArrow) engine.Update();
                else if (key.Key == ConsoleKey.LeftArrow) engine.GetBack();
            }
            else
            {
                printEngine(engine);
                engine.Update();
                Thread.Sleep(500);
            }
        }

        static void printEngine(GameOfLifeEngine engine)
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
        }
    }
}