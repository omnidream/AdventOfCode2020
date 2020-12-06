using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            string puzzleSearchPath = (@"C:\Users\gusta\source\repos\AdventOfCode2020\Day6\puzzleInput.txt");
            string[] puzzleInput = System.IO.File.ReadAllLines(puzzleSearchPath);
            List<string> myAnswersList = GetAnswers(puzzleInput);
            int sum = PartOne(myAnswersList);
            Console.WriteLine($"Part 1: {sum}");
            sum = PartTwo(myAnswersList);
            Console.WriteLine($"Part 1: {sum}");
        }

        private static List<string> GetAnswers(string[] puzzleInput)
        {
            List<string> myAnswersList = new List<string>();
            string answersData = String.Empty;
            foreach (string data in puzzleInput)
            {
                if (data == String.Empty)
                {
                    answersData.Trim();
                    myAnswersList.Add(answersData);
                    answersData = String.Empty;
                    continue;
                }
                answersData = answersData + " " + data;
            }
            myAnswersList.Add(answersData);
            return myAnswersList;
        }

        private static int PartOne(List<string> answers)
        {
            int sum = 0;
            foreach (string ans in answers)
            {
                var temp = ans.Replace(" ", "").Distinct();
                var count = temp.Count();
                sum += count;
            }
            return sum;
        }

        private static int PartTwo(List<string> myAnswers)
        {
            int sum = 0;
            foreach (string answer in myAnswers)
            {
                List<char> answersList = new List<char>();
                var temp = answer.Split(" ").Select(x => x.Distinct().ToList()).Where(x => x.Count > 0).ToList();
                for (int i = 0; i < temp.Count; i++)
                {
                    var a = temp[i];
                    if (i == 0)
                        answersList.AddRange(a);
                    else
                        answersList = new List<char>(answersList.Intersect(a).ToList());
                }
                sum += answersList.Count;
            }
            return sum;
        }
    }
}