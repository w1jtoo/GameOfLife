namespace GameOfLife
{
    public abstract class GroupCellsBase
    {
        public int XStart { get; set;}
        public int YStart { get; set;}
        public GameOfLifeEngine Engine { get; set;}

        public GroupCellsBase(GameOfLifeEngine engine, int xStart, int yStart)
        {
            Engine = engine;
            XStart = xStart;
            YStart = yStart;
        }

        public void Add(int x, int y)
        {
            Engine.Add(new List<Cell> {new Cell(XStart + x, YStart + y)});
        }

        public abstract void Create();
    }


    public class GroupSquare : GroupCellsBase
    {
        public int XStart { get; set; }
        public int YStart { get; set; }
        public GameOfLifeEngine Engine { get; set; }

        public GroupSquare(GameOfLifeEngine engine, int xStart, int yStart):
            base(engine, xStart, yStart) {}

        public override void Create()
        {
            Add(1, 1);
            Add(1, 2);
            Add(2, 1);
            Add(2, 2);
        }
    }

    public class GroupLoaf : GroupCellsBase
    {
        public int XStart { get; set; }
        public int YStart { get; set; }
        public GameOfLifeEngine Engine { get; set; }

        public GroupLoaf(GameOfLifeEngine engine, int xStart, int yStart):
            base(engine, xStart, yStart) {}

        public override void Create()
        {
            Add(1, 2);
            Add(2, 1);
            Add(1, 3);
            Add(2, 4);
            Add(3, 4);
            Add(4, 3);
            Add(3, 2);
        }
    }

    public class GroupBeeHive : GroupCellsBase
    {
        public int XStart { get; set; }
        public int YStart { get; set; }
        public GameOfLifeEngine Engine { get; set; }

        public GroupBeeHive(GameOfLifeEngine engine, int xStart, int yStart):
            base(engine, xStart, yStart) {}

        public override void Create()
        {
            Add(3, 1);
            Add(1, 2);
            Add(2, 1);
            Add(2, 3);
            Add(3, 3);
            Add(4, 2);
        }
    }

    public class GroupBoat : GroupCellsBase
    {
        public int XStart { get; set; }
        public int YStart { get; set; }
        public GameOfLifeEngine Engine { get; set; }

        public GroupBoat(GameOfLifeEngine engine, int xStart, int yStart):
            base(engine, xStart, yStart) {}

        public override void Create()
        {
            Add(1, 2);
            Add(2, 1);
            Add(1, 1);
            Add(2, 3);
            Add(3, 2);
        }
    }

    public class GroupTub : GroupCellsBase
    {
        public int XStart { get; set; }
        public int YStart { get; set; }
        public GameOfLifeEngine Engine { get; set; }

        public GroupTub(GameOfLifeEngine engine, int xStart, int yStart):
            base(engine, xStart, yStart) {}

        public override void Create()
        {
            Add(1, 2);
            Add(2, 1);
            Add(2, 3);
            Add(3, 2);
        }
    }

    public class GroupBlinker : GroupCellsBase
    {
        public int XStart { get; set; }
        public int YStart { get; set; }
        public GameOfLifeEngine Engine { get; set; }

        public GroupBlinker(GameOfLifeEngine engine, int xStart, int yStart):
            base(engine, xStart, yStart) {}

        public override void Create()
        {
            Add(2, 1);
            Add(2, 2);
            Add(2, 3);
        }
    }

    public class GroupToad : GroupCellsBase
    {
        public int XStart { get; set; }
        public int YStart { get; set; }
        public GameOfLifeEngine Engine { get; set; }

        public GroupToad(GameOfLifeEngine engine, int xStart, int yStart):
            base(engine, xStart, yStart) {}

        public override void Create()
        {
            Add(2, 1);
            Add(3, 1);
            Add(4, 2);
            Add(1, 3);
            Add(2, 4);
            Add(3, 4);
        }
    }

    public class GroupBeacon : GroupCellsBase
    {
        public int XStart { get; set; }
        public int YStart { get; set; }
        public GameOfLifeEngine Engine { get; set; }

        public GroupBeacon(GameOfLifeEngine engine, int xStart, int yStart):
            base(engine, xStart, yStart) {}

        public override void Create()
        {
            Add(2, 1);
            Add(1, 1);
            Add(1, 2);
            Add(2, 2);
            Add(3, 3);
            Add(3, 4);
            Add(4, 3);
            Add(4, 4);
        }
    }

    public class GroupPulsar : GroupCellsBase
    {
        public int XStart { get; set; }
        public int YStart { get; set; }
        public GameOfLifeEngine Engine { get; set; }

        public GroupPulsar(GameOfLifeEngine engine, int xStart, int yStart):
            base(engine, xStart, yStart) {}

        public override void Create()
        {
            Add(2, 4); Add(2, 5); Add(2, 6);
            Add(2, 10); Add(2, 11); Add(2, 12);
            Add(7, 4); Add(7, 5); Add(7, 6);
            Add(7, 10); Add(7, 11); Add(7, 12);
            Add(9, 4); Add(9, 5); Add(9, 6);
            Add(9, 10); Add(9, 11); Add(9, 12);
            Add(14, 4); Add(14, 5); Add(14, 6);
            Add(14, 10); Add(14, 11); Add(14, 12);
            Add(4, 2); Add(5, 2); Add(6, 2);
            Add(10, 2); Add(11, 2); Add(12, 2);
            Add(4, 7); Add(5, 7); Add(6, 7);
            Add(10, 7); Add(11, 7); Add(12, 7);
            Add(4, 9); Add(5, 9); Add(6, 9);
            Add(10, 9); Add(11, 9); Add(12, 9);
            Add(4, 14); Add(5, 14); Add(6, 14);
            Add(10, 14); Add(11, 14); Add(12, 14);
        }
    }

    public class GroupSurpriseHa : GroupCellsBase
    {
        public int XStart { get; set; }
        public int YStart { get; set; }
        public GameOfLifeEngine Engine { get; set; }

        public GroupSurpriseHa(GameOfLifeEngine engine, int xStart, int yStart):
            base(engine, xStart, yStart) {}

        public override void Create()
        {
            Add(2, 4); Add(3, 4); Add(4, 4); Add(8, 4); Add(9, 4); Add(10, 4) ;
            Add(4, 2); Add(4, 7); Add(8, 2); Add(8, 7) ;
            Add(2, 5); Add(3, 5); Add(4, 5); Add(8, 5); Add(9, 5); Add(10, 5) ;
            Add(1, 3); Add(5, 3); Add(6, 3); Add(7, 3); Add(11, 3) ;
            Add(1, 6); Add(5, 6); Add(6, 6); Add(7, 6); Add(11, 6) ;
            Add(2, 3); Add(3, 3); Add(4, 3); Add(8, 3); Add(9, 3); Add(10, 3) ;
        }
    }

    public class GroupPentaDecathlon : GroupCellsBase
    {
        public int XStart { get; set; }
        public int YStart { get; set; }
        public GameOfLifeEngine Engine { get; set; }

        public GroupPentaDecathlon(GameOfLifeEngine engine, int xStart, int yStart):
            base(engine, xStart, yStart) {}

        public override void Create()
        {
            Add(5, 5); Add(5, 6); Add(5, 7) ;
            Add(6, 5); Add(6, 7) ;
            Add(7, 5); Add(7, 6); Add(7, 7) ;
            Add(8, 5); Add(8, 6); Add(8, 7) ;
            Add(9, 5); Add(9, 6); Add(9, 7) ;
            Add(10, 5); Add(10, 6); Add(10, 7) ;
            Add(11, 5); Add(11, 7) ;
            Add(12, 5); Add(12, 6); Add(12, 7) ;
        }
    }

    public class GroupSurpriseHaHa : GroupCellsBase
    {
        public int XStart { get; set; }
        public int YStart { get; set; }
        public GameOfLifeEngine Engine { get; set; }

        public GroupSurpriseHaHa(GameOfLifeEngine engine, int xStart, int yStart):
            base(engine, xStart, yStart) {}

        public override void Create()
        {
            Add(1, 1); Add(1, 3); Add(2, 1); Add(2, 3); Add(3, 2);
            Add(5, 1); Add(5, 3); Add(6, 1); Add(6, 3); Add(7, 2);
            Add(1, 6); Add(1, 8); Add(2, 6); Add(2, 8); Add(3, 7);
            Add(5, 6); Add(5, 8); Add(6, 6); Add(6, 8); Add(7, 7);
            Add(3, 4); Add(3, 5); Add(4, 4); Add(4, 5);
            Add(7, 4); Add(7, 5); Add(8, 4); Add(8, 5);
        }
    }

    public class GroupGlider : GroupCellsBase
    {
        public int XStart { get; set; }
        public int YStart { get; set; }
        public GameOfLifeEngine Engine { get; set; }

        public GroupGlider(GameOfLifeEngine engine, int xStart, int yStart):
            base(engine, xStart, yStart) {}

        public override void Create()
        {
            Add(1, 1);
            Add(2, 2);
            Add(3, 2);
            Add(2, 3);
            Add(3, 1);
        }
    }

    public class GroupLightWeightSpaceship : GroupCellsBase
    {
        public int XStart { get; set; }
        public int YStart { get; set; }
        public GameOfLifeEngine Engine { get; set; }

        public GroupLightWeightSpaceship(GameOfLifeEngine engine, int xStart, int yStart):
            base(engine, xStart, yStart) {}

        public override void Create()
        {
            Add(1, 2); Add(2, 1); Add(4, 1);
            Add(1, 3); Add(1, 4); Add(1, 5);
            Add(2, 5); Add(3, 5); Add(4, 4);
        }
    }

    public class GroupMiddleWeightSpaceship : GroupCellsBase
    {
        public int XStart { get; set; }
        public int YStart { get; set; }
        public GameOfLifeEngine Engine { get; set; }

        public GroupMiddleWeightSpaceship(GameOfLifeEngine engine, int xStart, int yStart):
            base(engine, xStart, yStart) {}

        public override void Create()
        {
            Add(1, 2); Add(2, 1); Add(4, 1);
            Add(1, 3); Add(1, 4); Add(1, 5); Add(1, 6);
            Add(2, 6); Add(3, 6); Add(4, 5); Add(5, 3);
        }
    }

    public class GroupHeavyWeightSpaceship : GroupCellsBase
    {
        public int XStart { get; set; }
        public int YStart { get; set; }
        public GameOfLifeEngine Engine { get; set; }

        public GroupHeavyWeightSpaceship(GameOfLifeEngine engine, int xStart, int yStart):
            base(engine, xStart, yStart) {}

        public override void Create()
        {
            Add(1, 2); Add(2, 1); Add(4, 1);
            Add(1, 3); Add(1, 4); Add(1, 5); Add(1, 6); Add(1, 7);
            Add(2, 7); Add(3, 7); Add(4, 6); Add(5, 4); Add(5, 3);
        }
    }
}
