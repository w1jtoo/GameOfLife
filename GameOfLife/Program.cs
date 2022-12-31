using GameOfLife;

var engine = new GameOfLifeEngine();

var cells = new List<Cell> {new(1, 0), new(1, 1), new(1, 2), new(8, 5), new(8, 6), 
                            new(8, 7), new(5, 5), new(5, 6), new(6, 6), new(6, 7)}; 
engine.Add(cells);

ConsoleKeyInfo key;

while (true)
{  
    Console.Clear();
    var iterations = engine.GetCountOfIterations();
    Console.Write("After "); //вместо true/false
    Console.Write(iterations); //будем взвращать кол-во итераций, после которых
    Console.WriteLine(" iteration(s):"); //поле преобрело текущий вид
    printEngine(engine);
    key = Console.ReadKey();
    if (key.Key == ConsoleKey.RightArrow) engine.Update();
    else if (key.Key == ConsoleKey.LeftArrow) engine.GetBack();
}

static void printEngine(GameOfLifeEngine engine)
{
    var horizontalSize = 20;
    var verticalSize = 10;  
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