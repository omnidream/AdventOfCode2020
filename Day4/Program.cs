using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day4
    class Program
    {
        public static List<Passport> MyPassportList { get; set; } = new List<Passport>();
        static void Main(string[] args)
        {
            string puzzleSearchPath = (@"C:\Users\gusta\source\repos\AdventOfCode2020\Day4\puzzleInput.txt");
            string[] puzzleInput = System.IO.File.ReadAllLines(puzzleSearchPath);
            string[] separatedPassportInfo = SeparatePassportInfo(CleanPassportInfo(puzzleInput));
            MakePassportObjects(separatedPassportInfo);
            Console.WriteLine(CountValidPassports());
        }

        private static string CleanPassportInfo(string[] puzzleInput)
        {
            string myNewString = "";
            foreach (var line in puzzleInput)
            {
                if (line == "")
                    myNewString += " *** ";
                else
                    myNewString += line + " ";
            }
            return myNewString;
        }

        private static string[] SeparatePassportInfo(string myString)
        {
            string[] myNewString = myString.Split(" *** ");
            return myNewString;
        }

        private static int CountValidPassports()
        {
            int validPassports = 0;
            foreach (var passport in MyPassportList)
            {
                if (IsItAValidPassport(passport))
                    if(passport.ValidateAllFields(passport))
                        validPassports++;
            }
            return validPassports;
        }

        private static bool IsItAValidPassport(Passport passport)
        {
            foreach (var propp in passport.GetType().GetProperties())
            {
                string value = (string)propp.GetValue(passport);
                if (value == null && propp.Name != "Cid")
                    return false;
            }
            return true;
        }

        private static void MakePassportObjects(string[] separatedPassportInfo)
        {
            foreach (var passport in separatedPassportInfo)
            {
                Passport myPassport = new Passport();
                string[] myPassportInfo = passport.Split(new string[] { " ", "  "}, StringSplitOptions.RemoveEmptyEntries);
                AddKeysAndValues(myPassportInfo);
            }
        }

        private static void AddKeysAndValues(string[] myPassportInfo)
        {
            Passport myPassport = new Passport();
            foreach (var info in myPassportInfo)
            {
                string key = GetKey(info);
                string value = GetValue(info);
                AddToMyPassport(key, value, myPassport);
            }
            MyPassportList.Add(myPassport);
        }

        private static string GetKey(string info)
        {
            return info.Substring(0, info.IndexOf(":"));
        }

        private static string GetValue(string info)
        {
            string sub = info.Substring((info.IndexOf(":")+1));
            return sub;
        }

        private static void AddToMyPassport(string key, string value, Passport myPassport)
        {
            switch (key)
            {
                case "byr":
                    myPassport.Byr = value;
                    break;
                case "iyr":
                    myPassport.Iyr = value;
                    break;
                case "eyr":
                    myPassport.Eyr = value;
                    break;
                case "hgt":
                    myPassport.Hgt = value;
                    break;
                case "hcl":
                    myPassport.Hcl = value;
                    break;
                case "ecl":
                    myPassport.Ecl = value;
                    break;
                case "pid":
                    myPassport.Pid = value;
                    break;
                case "cid":
                    myPassport.Cid = value;
                    break;
                default:
                    break;
            }
        }
    }
}

