using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day8
{//2307, 2345, 2511 va för höga
    class Program
    {
        private static int myAcc = 0;
        private static int pos = 0;
        private static List<Tuple<string, int>> myBootCode = new List<Tuple<string, int>>();
        private static List<int> usedComs = new List<int>();
        static void Main(string[] args)
        {
            string puzzleSearchPath = (@"C:\Users\gusta\source\repos\AdventOfCode2020\Day8\puzzleInput.txt");
            string[] puzzleInput = System.IO.File.ReadAllLines(puzzleSearchPath);
            MakeBootCode(puzzleInput);
            Console.WriteLine($"Part one, Acc value: {PartOne()}");
            PartTwo();
        }

        private static void MakeBootCode(string[] puzzleInput)
        {
            Regex comRegex = new Regex("[a-z]{3}");
            Regex valueRegEx = new Regex("[+-]\\d+");

            foreach (var comLine in puzzleInput)
            {
                var com = comRegex.Match(comLine);
                var value = valueRegEx.Match(comLine);
                myBootCode.Add(new Tuple<string, int>(com.Value, Int32.Parse(value.Value)));
            }
        }

        private static int PartOne()
        {
            MoveSteps(1);
            while(true)
            {
                if (IsEndPartOne() || IsEndPartTwo())
                    return myAcc;
                else if (pos > myBootCode.Count-1)
                    break;
                usedComs.Add(pos);
                DoAction();
            }
            return myAcc;
        }
        
        private static void PartTwo()
        {
            Changing("jmp", "nop");
            Changing("nop", "jmp");
            Console.WriteLine(myAcc);
        }

        private static void Changing(string change, string changeTo)
        {
            foreach (var com in myBootCode.ToArray())
            {
                int index = 0;
                if (com.Item1 == change)
                {
                    Tuple<string, int> myBackupTuple = com;
                    index = myBootCode.IndexOf(com);
                    myBootCode.Insert(myBootCode.IndexOf(com), new Tuple<string, int>(changeTo, com.Item2));
                    myBootCode.Remove(com);
                    PartOne();
                    myBootCode.RemoveAt(index);
                    myBootCode.Insert(index, myBackupTuple);
                }
            }
        }

        private static void MoveSteps(int newSteps)
        {
            pos = pos + newSteps;
        }

        private static void DoAction()
        {
            
            if (myBootCode[pos].Item1 == "acc")
            {
                ChangeAcc(myBootCode[pos].Item2);
                MoveSteps(1);
            }
            else if (myBootCode[pos].Item1 == "jmp")
                MoveSteps(myBootCode[pos].Item2);
            else
                MoveSteps(1);
        }

        private static void ChangeAcc(int addValue)
        {
            myAcc = myAcc + addValue;
        }

        private static bool IsEndPartOne()
        {
            bool returnValue = false;
            if (IsUsed())
                returnValue = true;
            return returnValue;
        }

        private static bool IsEndPartTwo()
        {
            bool returnValue = false;
            if (pos == myBootCode.Count-1)
                returnValue = true;
            return returnValue;
        }

        private static bool IsUsed()
        {
            bool returnValue = false;
            if (usedComs.Contains(pos))
                returnValue = true;
            return returnValue;
        }
    }
}
