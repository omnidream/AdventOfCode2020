using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day7
{
    class Program
    {
        private static readonly Dictionary<string, Dictionary<string, int>> bagContent = new Dictionary<string, Dictionary<string, int>>();
        public static string MyBagColor { get; set; } = "shiny gold";
        private static readonly Regex carryBagRegEx = new Regex(@"(\w+ \w+) bags contain");
        private static readonly Regex bagContentRegEx = new Regex(@"(\d+) (\w+ \w+) bags?[,.]");
        private static string[] puzzleInput = System.IO.File.ReadAllLines(@"C:\Users\gusta\source\repos\AdventOfCode2020\Day7\puzzleInput.txt");
        static void Main(string[] args)
        {
            Console.WriteLine(PartOne());
        }

        private static int PartOne()
        {
            MakeBagTree();
            return 0;
        }

        private static void MakeBagTree()
        {
            foreach (var line in puzzleInput)
            {
                var contentDict = new Dictionary<string, int>();
                var bagColor = carryBagRegEx.Match(line).Groups[1].Value;
                foreach (Match match in bagContentRegEx.Matches(line))
                {
                    var contentBagColor = match.Groups[2].Value;
                    var numberOfBags = int.Parse(match.Groups[1].Value);
                    contentDict.Add(contentBagColor, numberOfBags);
                }
                bagContent.Add(bagColor, contentDict);
            }
        }
    }
}

