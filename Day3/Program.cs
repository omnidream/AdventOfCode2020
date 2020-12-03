using System;

namespace Day3
{
    class Program
    {
        private static string[] slope;
        private static int trees;
        private static int x = 0;
        private static int y = 0;
        
        static void Main(string[] args)
        {
            string puzzleSearchPath = (@"C:\Users\gusta\source\repos\AdventOfCode2020\Day3\puzzleInput.txt");
            slope = System.IO.File.ReadAllLines(puzzleSearchPath);
            //GoDownhill(3, 1);
            PartTwo();
        }

        private static int GoDownhill(int right, int down)
        {
            ResetValues();
            while(y != slope.Length - 1)
            {
                MoveRight(right, down);
                MoveDown(right, down);
                DidIHitATree();
            }
            Console.WriteLine($"Du träffade {trees}.");
            return trees;
        }

        private static void ResetValues()
        {
            x = 0;
            y = 0;
            trees = 0;
        }

        private static void PartTwo()
        {
            long one = GoDownhill(1, 1);
            long two = GoDownhill(3, 1);
            long three = GoDownhill(5, 1);
            long four = GoDownhill(7, 1);
            long five = GoDownhill(1, 2);
            Console.WriteLine($"Du kommer multiplicerat träffa {one * two * three * four * five} träd.");
        }

        private static bool OutOfBounds(int right)
        {
            if ((x + right) >= (slope[0].Length))
                return true;
            else
                return false;
        }

        private static void MoveRight(int right, int down)
        {
            if (OutOfBounds(right))
                x = (x + right) - (slope[0].Length);
            else
                x = x + right;
        }

        private static void MoveDown(int right, int down)
        {
            if((y + 1) < slope.Length)
                y = y + down;
        }

        private static void DidIHitATree()
        {
            if (slope[y][x] == '#')
                trees++;
        }
    }
}
