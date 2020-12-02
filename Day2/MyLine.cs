using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Day2
{
    public class MyLine
    {
        public int MinChar { get; set; }
        public int MaxChar { get; set; }
        public char MyChar { get; set; }
        public string MyPassword { get; set; }

        public MyLine(string line)
        {
                GetMinMaxChar(line);
                GetChar(line);
                GetPassword(line);
        }

        private void GetMinMaxChar(string line)
        {
            string[] numbers = Regex.Split(line, @"\D+");
            MinChar = int.Parse(numbers[0]);
            MaxChar = int.Parse(numbers[1]);
        }

        private void GetChar(string line)
        {
            MyChar = line[FindIndexOfChar(line, ':') - 1];
        }

        private int FindIndexOfChar(string line, char findThis)
        {
            for(int i = 0; i < line.Length; i++)
            {
                if (line[i] == findThis)
                {
                    return i;
                }
            }
            return 0;
        }

        private void GetPassword(string line)
        {
            int startIndex = FindIndexOfChar(line, ':') + 2;
            MyPassword = line.Substring(startIndex);
        }




    }
}
