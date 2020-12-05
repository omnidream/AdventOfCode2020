using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Program
    {
        public static List<int> mySeatsList = new List<int>();

        static void Main(string[] args)
        {
            string puzzleSearchPath = (@"C:\Users\gusta\source\repos\AdventOfCode2020\Day5\puzzleInput.txt");
            string[] puzzleInput = System.IO.File.ReadAllLines(puzzleSearchPath);
            Console.WriteLine(PartOne(puzzleInput));
            Console.WriteLine(PartTwo());
        }
        public static int PartOne(string[] puzzleInput)
        {
            int highestSeatId = 0;
            int colDivider;
            int column;
            int seatId;
            int rowDivider;
            int row;

            foreach (string line in puzzleInput)
            {
                rowDivider = 64;
                colDivider = 4;
                row = 0;
                column = 0;

                for (int i = 0; i <= 6; i++)
                {
                    if (line[i] == 'B')
                        row += rowDivider;
                    rowDivider /= 2;
                }

                for (int i = 7; i <= 9; i++)
                {
                    if (line[i] == 'R')
                        column += colDivider;
                    colDivider /= 2;
                }

                seatId = row * 8 + column;
                mySeatsList.Add(seatId);

                if (seatId > highestSeatId)
                    highestSeatId = seatId;
            }
            return highestSeatId;
        }

        public static int PartTwo()
        {
            int min = mySeatsList.Min(t => t);
            foreach (int x in mySeatsList.OrderBy(t => t))
            {
                if (x != min)
                    return min;
                min++;
            }
            return -1;
        }
    }
}