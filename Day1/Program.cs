using System;
using System.Collections.Generic;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string puzzleSearchPath = (@"C:\Users\gusta\source\repos\AdventOfCode2020\Day1\puzzleInput.txt");
            List<int> myPuzzleInput = new List<int>();
            myPuzzleInput = ConvertToNumberList(System.IO.File.ReadAllLines(puzzleSearchPath), myPuzzleInput);
            Console.WriteLine(FindTheMagicNumber(myPuzzleInput));
        }

        private static List<int> ConvertToNumberList(string[] stringArray, List<int> myPuzzleInput)
        {
            foreach (var number in stringArray)
            {
                myPuzzleInput.Add(Int32.Parse(number));
            }
            return myPuzzleInput;
        }

        private static int FindTheMagicNumber(List<int> myPuzzleInput)
        {
            foreach (var number in myPuzzleInput)
            {
                foreach (var numberTwo in myPuzzleInput)
                {
                    foreach (var numberThree in myPuzzleInput)
                    {
                        if (IsItCorrect(number + numberTwo + numberThree))
                            return (number * numberTwo * numberThree);
                    }
                }
            }
            return 0;
        }

        private static bool IsItCorrect(int number)
        {
            if (number == 2020)
                return true;
            else
                return false;
        }

    }
}
