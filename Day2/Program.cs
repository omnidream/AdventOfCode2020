using System;
using System.Collections.Generic;

namespace Day2
{
    class Program
    {
        public static List<MyLine> MyLinesList { get; set; } = new List<MyLine>();
        static void Main(string[] args)
        {
            
            string puzzleSearchPath = (@"C:\Users\gusta\source\repos\AdventOfCode2020\Day2\puzzleInput.txt");
            string[] lines = System.IO.File.ReadAllLines(puzzleSearchPath);
            AddToLineList(lines);
            Console.WriteLine($"Antal validerade lösenord från del 1: {NumberOfValidPasswordsPartOne()}");
            Console.WriteLine($"Antal validerade lösenord från del 2: {NumberOfValidPasswordsPartTwo()}");
        }

        private static void AddToLineList(string[] lines)
        {
            foreach (string line in lines)
            {
                MyLine myLine = new MyLine(line);
                MyLinesList.Add(myLine);
            }
        }

        private static int NumberOfValidPasswordsPartOne()
        {
            int numberOfValidPasswords = 0;
            foreach (var line in MyLinesList)
            {
                if (IsItAValidPassword(line))
                    numberOfValidPasswords++;
            }
            return numberOfValidPasswords;
        }

        private static bool IsItAValidPassword(MyLine line)
        {
            bool returnValue = false;
            int numberOfChars = CountChars(line);

            if (numberOfChars >= line.MinChar && numberOfChars <= line.MaxChar)
                returnValue = true;
            return returnValue;
        }

        private static int CountChars(MyLine line)
        {
            int numberOfChars = 0;
            for(int i = 0; i < line.MyPassword.Length; i++)
            {
                if (line.MyPassword[i] == line.MyChar)
                    numberOfChars++;
            }
            return numberOfChars;
        }

        private static int NumberOfValidPasswordsPartTwo()
        {
            int numberOfValidPasswords = 0;
            foreach (var line in MyLinesList)
            {
                bool first = IsCharCorrect(line, (line.MinChar-1));
                bool secound = IsCharCorrect(line, (line.MaxChar-1));

                if (first == true && secound == false)
                    numberOfValidPasswords++;
                else if(secound == true && first == false)
                    numberOfValidPasswords++;
            }
            return numberOfValidPasswords;
        }

        private static bool IsCharCorrect(MyLine line, int index)
        {
            bool returnValue = false;
            if (line.MyPassword[index] == line.MyChar)
                returnValue = true;
            return returnValue;
        }





    }
}
