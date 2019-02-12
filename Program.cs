using System;
using GenerationLib;

namespace CaveGeneratorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int seed = System.Environment.TickCount;
            int timeStart = System.Environment.TickCount;
            float ratio = 0.3f;

            Console.Out.WriteLine("Seed: " + seed);
            Console.Out.WriteLine();

            Console.Out.WriteLine("Without Connecting Rooms");
            CaveGenerator caveFactory = new CaveGenerator(79, 50, seed, ratio);
            caveFactory.GenerateMap(false);
            PrintMap(caveFactory);

            Console.Out.WriteLine("With Connecting Rooms");
            caveFactory = new CaveGenerator(79, 50, seed, ratio);
            caveFactory.GenerateMap(true);
            PrintMap(caveFactory);

            Console.Out.WriteLine();
            Console.Out.WriteLine("Time To Generate: " + ((System.Environment.TickCount - timeStart) / 1000).ToString() + "s");

            Console.In.ReadLine();
        }
        public static void PrintMap(CaveGenerator map)
        {
            for (int row = 1; row <= map.Map.Rows; row++) {
                for (int column = 1; column <= map.Map.Columns; column++) {
                    if (map.Map.GetTile(column, row) == CaveGenerator.TileWall || map.Map.GetTile(column, row) == CaveGenerator.TilePermanantWall) {
                        Console.Write("#");
                    } else {
                        Console.Write(".");
                    }
                } //column

                Console.Write(System.Environment.NewLine);
            } //row
        } // PrintGrid 
    }
}
