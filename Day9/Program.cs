using System;
using System.Collections.Generic;
using System.Linq;

namespace Day9
{

    class Program
    {
        public static IEnumerable<int> Range(int min, int lim) => Enumerable.Range(min, lim - min);
        private static string puzzleSearchPath = (@"C:\Users\gusta\source\repos\AdventOfCode2020\Day9\puzzleInput.txt");
        private static string[] puzzleInput = System.IO.File.ReadAllLines(puzzleSearchPath);
        private static long[] input = Array.ConvertAll(puzzleInput, long.Parse);

        static void Main(string[] args)
        {
            Console.WriteLine($"Part one: {PartOne()}");
            //Console.WriteLine($"Part two: {PartTwo()}"); Fan.
        }

        private static long PartOne()
        {
            bool Error(int i) => (
                from j in Range(i - 25, i)
                from k in Range(j + 1, i)
                select input[j] + input[k]
            ).All(sum => sum != input[i]);
            return input[Range(25, input.Length).First(Error)];
        }

        private static int PartTwo()
        {
            return 0;
        }
    }
}
